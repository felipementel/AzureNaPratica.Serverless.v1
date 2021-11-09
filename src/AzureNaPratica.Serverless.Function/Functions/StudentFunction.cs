using AzureNaPratica.Serverless.Application.DataTransferObject.Student;
using AzureNaPratica.Serverless.Application.Interfaces.Student;
using AzureNaPratica.Serverless.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace AzureNaPratica.Serverless.Function.Functions
{
    public class StudentFunction
    {
        private readonly IStudentAppService _studentAppService;

        public StudentFunction(
            IStudentAppService studentAppService)
        {
            _studentAppService = studentAppService;
        }

        [Function("StudentFunction")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Student Function");

            try
            {
                if (HttpMethods.IsPost(req.Method))
                {
                    logger.LogInformation("*** POST");

                    var item = Util.OurSerlialization.Deserializer<StudentDto>(req.ReadAsString());

                    var itemEntity = await _studentAppService.InsertAsync(item);

                    if (itemEntity.ValidationResult.IsValid is not false)
                    {
                        var response = req.CreateResponse(HttpStatusCode.Created);
                        response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

                        response.WriteString("Student created");

                        return response;
                    }
                    else
                    {
                        var response = req.CreateResponse(HttpStatusCode.BadRequest);
                        var body = OurSerlialization.Serializer(itemEntity.ValidationResult);
                        response.Body = StreamString.ConvertStringToStream(body);
                        response.Headers.Add("Content-Type", "application/json");

                        return response;
                    }
                }
                if (HttpMethods.IsGet(req.Method))
                {
                    var items = await _studentAppService.GetAllAsync();
                    var response = req.CreateResponse(HttpStatusCode.OK);
                    string body = Util.OurSerlialization.Serializer(items);

                    response.Body = body.ConvertStringToStream();
                    response.Headers.Add("Content-Type", "application/json");

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
            catch (Exception ex)
            {
                var response = req.CreateResponse(HttpStatusCode.InternalServerError);
                response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

                response.WriteString(ex.ToString());

                return response;
            }
        }
    }
}
