using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Threading.Tasks;

namespace AzureNaPratica.Serverless.Function.Functions
{
    [ExcludeFromCodeCoverage]
    public class HealthCheck
    {
        [Function("HealthCheck")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "healthcheck/ping")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logging = executionContext.GetLogger("HealthCheck");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            await response.WriteStringAsync($"pong v{System.Reflection.Assembly.GetExecutingAssembly().GetName().Version}");

            logging.LogInformation("** HealthCheck Ok **");

            return response;
        }
    }
}
