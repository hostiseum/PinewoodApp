using System.Net.Http.Headers;
using System.Net.Http;

namespace PinewoodApp.CustomerDMS.Helpers
{
    public class HttpHelper : IHttpHelper
    {
        private const string HttpMethod = "GET";
        IHttpClientFactory _httpClientFactory;
        IConfiguration _configuration;
        public HttpHelper(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }
        public HttpClient GetHttpClient()
        {
            var client = _httpClientFactory.CreateClient();

            if (_configuration == null && _configuration["BaseApiUrl"] == null)
                throw new Exception("BaseAddress not provided");

            client.BaseAddress = new Uri(_configuration!["BaseApiUrl"]!.ToString());
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

    }
}
