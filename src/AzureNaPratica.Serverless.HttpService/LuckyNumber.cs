using AzureNaPratica.Serverless.Domain.Base.Interfaces.HttpService;
using System.Net.Http;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
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

        public async Task<int> GetLuckyNumber()
        {
            using var httpClient = _httpClientFactory.CreateClient("luckyNumber");
            var content = await httpClient.GetAsync("/api/obternumerodasorte");

            string body = string.Empty;

            if (!content.IsSuccessStatusCode)
            {
                return 0;                
            }

            //body = await content.Content.ReadAsStringAsync();

            //return System.Text.Json.JsonSerializer.Deserialize<NumeroDaSorte>(body).Numero;

            var node = JsonNode.Parse(await content.Content.ReadAsStringAsync());

            return int.Parse(node["numeroDaSorte"].ToString());
        }
    }

    public class NumeroDaSorte
    {
        [JsonPropertyName(name: "numeroDaSorte")]
        public int Numero { get; set; }
    }
}