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
	public class FakeHttpClient : IHttpClientBuilder
	{
		private readonly IConfiguration _configuration;
		private readonly IDIContainer _container;
		private readonly ILog _log;
		private readonly ISerializer _serializer;
		private readonly HttpClientHandler handler = new HttpClientHandler();

		public FakeHttpClient()
		{
			throw new NotSupportedException();
		}

		public FakeHttpClient(IDIContainer container)
		{
			_configuration = container.Resolve<IConfiguration>();
			_serializer = container.Resolve<ISerializer>();
			_container = container;
			_log = container.Resolve<ILog>();
			handler.AllowAutoRedirect = true;
			Authorization = container.Resolve<IAuthorization>();
		}

		public static bool DisableSessionAffinity { get; set; } = false;
		public IAuthorization Authorization { get; set; }

		public HttpClient Client
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public string AuthorizationType { get {
				return "Bearer";
			} } 

		public Task<IPlatformResponse<T>> Request<T>(ApiEndpoint endpoint, string relativePath, CancellationToken cancellationToken, IProgress<ISDKProgress> progress = null, HttpMethod method = null, string body = null, byte[] rawData = null, string contentType = "application/json", IDictionary<string, string> headers = null)
		{
			throw new NotImplementedException();
		}

		public HttpClient ImagesClient(string contentType = "application/json")
		{
			throw new NotImplementedException();
		}

		public HttpClient PushClient(string contentType = "application/json")
		{
			throw new NotImplementedException();
		}

		public HttpClient ApiClient(string contentType = "application/json")
		{
			throw new NotImplementedException();
		}

		public HttpClient AccountsClient(string contentType = "application/json")
		{
			throw new NotImplementedException();
		}
	}
}