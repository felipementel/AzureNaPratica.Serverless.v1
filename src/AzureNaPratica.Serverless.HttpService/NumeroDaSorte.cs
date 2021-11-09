using AzureNaPratica.Serverless.Domain.Base.Interfaces.HttpService;
using System.Net.Http;
using System.Threading.Tasks;

namespace AzureNaPratica.Serverless.HttpService
{
    public class LuckyNumber : ILuckyNumber
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LuckyNumber(
            IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<int> GetLucyNumber()
        {
            using var httpClient = _httpClientFactory.CreateClient("lucyNumber");
            var content = await httpClient.GetAsync("/api/obternumerodasorte");

            string body = string.Empty;

            if (!content.IsSuccessStatusCode)
            {
                return 0;                
            }

            body = await content.Content.ReadAsStringAsync();

            return System.Text.Json.JsonSerializer.Deserialize<NumeroDaSorte>(body).numeroDaSorte;
        }
    }

    public class NumeroDaSorte
    {
        public int numeroDaSorte { get; set; }
    }
}
