using Mojio.Platform.SDK.Contracts;
using Mojio.Platform.SDK.Contracts.Client;
using Mojio.Platform.SDK.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Mojio.Platform.SDK
{
    public partial class Client
    {

        public async Task<IPlatformResponse<IMessageResponse>> DeleteImage(ImageEntities entityType, Guid id, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);
            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                var result = await _clientBuilder.Request<IMessageResponse>(ApiEndpoint.Api, $"v2/{entityType}/{id}/image", tokenP.CancellationToken, tokenP.Progress, HttpMethod.Delete);
                return result;
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<IMessageResponse>>(null);
        }

        public async Task<IPlatformResponse<IMessageResponse>> SaveImage(ImageEntities entityType, Guid id, byte[] image, string fileName, string contentType, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
        {
            var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);
            if (string.IsNullOrEmpty(fileName)) fileName = "App.Profile.Picture";
            if (string.IsNullOrEmpty(contentType)) contentType = "image/png";

            var headers = new Dictionary<string, string>
            {
                {"Content-Type", contentType},
                {"Filename", fileName}
            };

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                var result = await _clientBuilder.Request<IMessageResponse>(ApiEndpoint.Api, $"v2/{entityType}/{id}/image", tokenP.CancellationToken, tokenP.Progress, HttpMethod.Post, null, image, "application/json", headers);
                return result;
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<IMessageResponse>>(null);
        }


        public async Task<IPlatformResponse<IImage>> GetImage(ImageEntities entityType, Guid id, CancellationToken? cancellationToken = null, IProgress<ISDKProgress> progress = null)
            {
                var tokenP = IssueNewTokenAndProgressContainer(cancellationToken, progress);

            if ((await Login(Authorization, cancellationToken, progress)).Success)
            {
                return await _clientBuilder.Request<IImage>(ApiEndpoint.Api, $"v2/{entityType}/{id}/image", tokenP.CancellationToken, tokenP.Progress);
            }
            _log.Fatal(new Exception("Authorization Failed"));
            return await Task.FromResult<IPlatformResponse<IImage>>(null);
        }

    }
}