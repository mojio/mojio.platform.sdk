#region copyright
/******************************************************************************
* Moj.io Inc. CONFIDENTIAL
* 2017 Copyright Moj.io Inc.
* All Rights Reserved.
* 
* NOTICE:  All information contained herein is, and remains, the property of 
* Moj.io Inc. and its suppliers, if any.  The intellectual and technical 
* concepts contained herein are proprietary to Moj.io Inc. and its suppliers
* and may be covered by Patents, pending patents, and are protected by trade
* secret or copyright law.
*
* Dissemination of this information or reproduction of this material is strictly
* forbidden unless prior written permission is obtained from Moj.io Inc.
*******************************************************************************/
#endregion

using Mojio.Platform.SDK.Bot.Contracts;
using Mojio.Platform.SDK.Contracts;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK.Bot
{
    public class BotClient : IBotClient
    {
        private readonly ISerializer _serializer;
        private readonly IDIContainer _container;

        public BotClient(ISerializer serializer, IDIContainer container)
        {
            _serializer = serializer;
            _container = container;
        }

        //public BotClient()
        //{
        //}

        public string Url { get; set; }

        public async Task<IPlatformResponse<IMessage>> SendMessage(IMessage input, string mojioApiToken = null)
        {
            var r = _container.Resolve<IPlatformResponse<IMessage>>();

            var bot = _container.Resolve<IChannelAccount>("bot");
            if (!input.Participants.Contains(bot))
            {
                input.Participants.Add(bot);
            }
            if (!input.Participants.Contains(input.From))
            {
                input.Participants.Add(input.From);
            }

            var _client = new HttpClient();

            _client.BaseAddress = new Uri(Url);
            _client.DefaultRequestHeaders.TryAddWithoutValidation("X-SkipAuth", "true");
            _client.DefaultRequestHeaders.TryAddWithoutValidation("X-Chat-Off", "true");
            _client.DefaultRequestHeaders.TryAddWithoutValidation("X-Wolf-Off", "true");

            var request = new HttpRequestMessage(HttpMethod.Post, "/api/messages");

            if (!string.IsNullOrEmpty(mojioApiToken))
            {
                request.Headers.Add("MojioAPIToken", mojioApiToken);
            }

            var json = _serializer.SerializeToString(input);

            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            var requestSw = new Stopwatch();
            requestSw.Start();

            var sendResult = await _client.SendAsync(request);

            r.RequestDurationMS = requestSw.ElapsedMilliseconds;
            requestSw.Stop();

            var body = await sendResult.Content.ReadAsStringAsync();
            r.Response = _serializer.Deserialize<IMessage>(body);

            try
            {
                var cookie = (from h in sendResult.Headers where h.Key == "Set-Cookie" select h.Value.FirstOrDefault()).FirstOrDefault();
                if (cookie != null)
                {
                    r.ARRAffinityInstance = (from c in cookie.Split(';') where c.StartsWith("") select c.Split('=').LastOrDefault()).FirstOrDefault();
                }
            }
            catch (Exception)
            {
            }
            r.Url = sendResult.RequestMessage.RequestUri.ToString();
            r.Timestamp = DateTimeOffset.UtcNow;
            r.HttpStatusCode = sendResult.StatusCode;
            r.Success = sendResult.IsSuccessStatusCode;

            r.CacheHit = false;
            r.HttpStatusCode = r.HttpStatusCode;
            r.WasCancelled = false;
            return r;
        }
    }
}