using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Felipementel.NumeroDaSorte
{
    public class Sorteio
    {
        private readonly IConfiguration _configuration;

        public Sorteio(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Function("ObterNumeroDaSorte")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "obternumerodasorte")] HttpRequestData req,
            FunctionContext executionContext)
        {
            try
            {
                if (HttpMethods.IsGet(req.Method))
                {
                    Random randNum = new Random();
                    int numero = randNum.Next(1, 100);

                    var numeroDaSorte = new JsonObject()
                    {
                        ["numeroDaSorte"] = numero
                    };

                    var response = req.CreateResponse(HttpStatusCode.OK);
                    await response.WriteAsJsonAsync(numeroDaSorte);

                    return response;
                }
                else
                {
                    var response = req.CreateResponse(HttpStatusCode.MethodNotAllowed);
                    response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

                    response.WriteString("MethodNotAllowed");

                    return response;
                }
            }
            catch (System.Exception ex)
            {
                var response = req.CreateResponse(HttpStatusCode.InternalServerError);
                response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

                response.WriteString(ex.ToString());

                return response;
            }
        }
    }
}
