using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Entities;
using Mojio.Platform.SDK.Contracts.Instrumentation;
using Mojio.Platform.SDK.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK
{
    public class MojioHttpClient : IHttpClientBuilder
    {
        private readonly IConfiguration _configuration;
        private readonly IDIContainer _container;
        private readonly ILog _log;
        private readonly ISerializer _serializer;
        private readonly HttpClientHandler handler = new HttpClientHandler();

        public MojioHttpClient(IAuthorization authorization, IConfiguration configuration, ISerializer serializer, IDIContainer container, ILog log)
        {
            _configuration = configuration;
            _serializer = serializer;
            _container = container;
            _log = log;
            handler.AllowAutoRedirect = true;
            Authorization = authorization;
        }

        public static bool DisableSessionAffinity { get; set; } = false;
        public IAuthorization Authorization { get; set; }

        public HttpClient Client
        {
            get
            {
                var client = new HttpClient(handler);
                if (Authorization != null && !string.IsNullOrEmpty(Authorization.MojioApiToken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AuthorizationType, Authorization.MojioApiToken);
                }
                client.Timeout = TimeSpan.FromMinutes(3);

                return client;
            }
        }

        public string AuthorizationType { get; set; } = "Bearer";

        public async Task<IPlatformResponse<T>> Request<T>(ApiEndpoint endpoint, string relativePath, CancellationToken cancellationToken, IProgress<ISDKProgress> progress = null, HttpMethod method = null, string body = null, byte[] rawData = null, string contentType = "application/json", IDictionary<string, string> headers = null)
        {
            var monitor = _container.Resolve<IProgressMonitor>();
            if (progress != null)
            {
                monitor.Progress = progress;
                monitor.Start();
            }
            monitor.Report("Initializing Http Request", 0);

            var _method = HttpMethod.Get;
            if (method != null) _method = method;

            var platformResponse = new PlatformResponse<T>
            {
                Success = false
            };

            if (headers != null && headers.Count > 0)
            {
                if (headers.ContainsKey("Authorization"))
                {
                    var h = headers["Authorization"];
                    if (h.IndexOf(" ", StringComparison.Ordinal) > 0)
                    {
                        var type = h.Substring(0, h.IndexOf(" ", StringComparison.Ordinal)).Trim();
                        var token = h.Substring(h.IndexOf(" ", StringComparison.Ordinal)).Trim();
                        AuthorizationType = type;
                        Authorization.MojioApiToken = token;
                        headers.Remove("Authorization");
                    }
                }
            }

            HttpClient client;

            switch (endpoint)
            {
                case ApiEndpoint.Accounts:
                    client = AccountsClient(contentType);
                    break;

                case ApiEndpoint.Images:
                    client = ImagesClient(contentType);
                    break;

                case ApiEndpoint.Push:
                    client = PushClient(contentType);
                    break;

                default:
                    client = ApiClient(contentType);
                    break;
            }

            var request = new HttpRequestMessage(_method, relativePath);
            monitor.Report("Setting HttpContent Body", 0.1);

            if (!string.IsNullOrEmpty(body))
            {
                Debug.WriteLine($"Request Content:{body}");
                request.Content = new StringContent(body, Encoding.UTF8, contentType);
            }

            monitor.Report("Set HttpContent Body", 0.2);

            if (rawData != null)
            {
                monitor.Report("Creating MultiPart Form Content", 0.2);

                var requestContent = new MultipartFormDataContent(); //"Upload----" + DateTime.Now.ToString(CultureInfo.InvariantCulture));

                var imageContent = new ByteArrayContent(rawData);
                var fileName = "image.png";
                var type = "image/png";

                if (headers != null && headers.Count > 0)
                {
                    type = (from x in headers where x.Key == "Content-Type" select x.Value).FirstOrDefault();
                    fileName = (from x in headers where x.Key == "Filename" select x.Value).FirstOrDefault();
                    if (!string.IsNullOrEmpty(type))
                    {
                        headers.Remove("Content-Type");
                    }
                    if (!string.IsNullOrEmpty(fileName))
                    {
                        headers.Remove("Filename");
                    }
                }

                imageContent.Headers.ContentDisposition = ContentDispositionHeaderValue.Parse("form-data");
                imageContent.Headers.ContentDisposition.Name = "\"file\"";
                imageContent.Headers.ContentDisposition.FileName = fileName;
                imageContent.Headers.ContentDisposition.Size = rawData.Length;
                imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse(type);

                requestContent.Add(imageContent);
                request.Content = requestContent;

                monitor.Report("Created MultiPart Form Content", 0.3);
            }
            monitor.Report("Adding Headers", 0.4);

            if (headers != null && headers.Count > 0)
            {
                foreach (var h in headers)
                {
                    request.Headers.Add(h.Key, h.Value);
                }
            }
            request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));

            if (DisableSessionAffinity)
            {
                request.Headers.Add("Arr-Disable-Session-Affinity", "True");
            }

            monitor.Report("Added Headers", 0.4);

            if (cancellationToken.IsCancellationRequested)
            {
                platformResponse.WasCancelled = true;
                monitor.Report("Operation Cancelled", 0.5);
                return platformResponse;
            }
            monitor.Report("Sending Http Request", 0.6);
            var requestSw = new Stopwatch();
            requestSw.Start();
            Debug.WriteLine($"Pre-flight request URL: {request.RequestUri}");

            using (var sendResult = await client.SendAsync(request, cancellationToken))
            {
                platformResponse.RequestDurationMS = requestSw.ElapsedMilliseconds;
                monitor.Report("Received Response from Http Request", 0.7);
                requestSw.Stop();

                platformResponse.Url = sendResult.RequestMessage.RequestUri.ToString();
                Debug.WriteLine($"Post-flight request URL: {platformResponse.Url}");
                platformResponse.Timestamp = DateTimeOffset.UtcNow;
                platformResponse.HttpStatusCode = sendResult.StatusCode;
                Debug.WriteLine($"Status Code: {platformResponse.HttpStatusCode}");

                try
                {
                    var cookie = (from h in sendResult.Headers where h.Key == "Set-Cookie" select h.Value.FirstOrDefault()).FirstOrDefault();
                    if (cookie != null)
                    {
                        platformResponse.ARRAffinityInstance = (from c in cookie.Split(';') where c.StartsWith("") select c.Split('=').LastOrDefault()).FirstOrDefault();
                    }
                }
                catch (Exception)
                {
                }

                if (sendResult.IsSuccessStatusCode)
                {
                    monitor.Report("Received Successful StatusCode", 0.8);
                    if (cancellationToken.IsCancellationRequested)
                    {
                        platformResponse.WasCancelled = true;
                        monitor.Report("Operation Cancelled", 0.9);
                        return platformResponse;
                    }

                    monitor.Report("Reading data from Response", 0.9);
                    var json = await sendResult.Content.ReadAsStringAsync();

                    monitor.Report("Deserializing data", 0.95);
                    try
                    {
                        platformResponse.Response = _serializer.Deserialize<T>(json);
                        if (platformResponse.Response != null)
                        {
                            platformResponse.Success = true;
                        }
                    }
                    catch (Exception e)
                    {
                        _log.Error(e, "Invalid response from the server. Received:{0}, expected:{1}.  Will continue.", json, typeof(T));
                    }

                    if (typeof(T) == typeof(IAuthorization))
                    {
                        monitor.Report("Setting internal auth token", 0.99);
                        Authorization.MojioApiToken = (platformResponse.Response as IAuthorization).AccessToken;
                        _container.RegisterInstance(Authorization, "Session");
                    }
                }
                else
                {
                    monitor.Report("Received Unsuccessful StatusCode", 0.8);

                    platformResponse.Success = false;
                    platformResponse.ErrorCode = sendResult.StatusCode.ToString();
                    platformResponse.ErrorMessage = sendResult.ReasonPhrase;

                    monitor.Report("Reading data from Response", 0.9);
                    var content = await sendResult.Content.ReadAsStringAsync();

                    Debug.WriteLine(content);
                    Debug.WriteLine(_serializer.SerializeToString(request));

                    if (!string.IsNullOrEmpty(content))
                    {
                        try
                        {
                            monitor.Report("Deserializing data", 0.95);
                            dynamic result = _serializer.Deserialize(content);
                            if (result != null)
                            {
                                if (result.Message != null)
                                {
                                    platformResponse.ErrorMessage = platformResponse.ErrorMessage + ", " + result.Message;
                                }
                                else
                                {
                                    platformResponse.ErrorMessage = platformResponse.ErrorMessage + ", " + content;
                                }
                            }
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
            monitor.Report("Finished", 1);

            monitor.Stop();

            return platformResponse;
        }

        public HttpClient ImagesClient(string contentType = "application/json")
        {
            var client = Client;
            client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue(contentType));

            client.BaseAddress = new Uri(_configuration.Environment.ImagesUri);

            return client;
        }

        public HttpClient PushClient(string contentType = "application/json")
        {
            var client = Client;
            client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue(contentType));

            client.BaseAddress = new Uri(_configuration.Environment.PushUri);

            return client;
        }

        public HttpClient ApiClient(string contentType = "application/json")
        {
            var client = Client;
            client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue(contentType));

            client.BaseAddress = new Uri(_configuration.Environment.APIUri);

            return client;
        }

        public HttpClient AccountsClient(string contentType = "application/json")
        {
            if (string.IsNullOrEmpty(contentType)) contentType = "application/json";
            var client = Client;
            client.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue(contentType));

            client.BaseAddress = new Uri(_configuration.Environment.AccountsUri);

            return client;
        }
    }
}