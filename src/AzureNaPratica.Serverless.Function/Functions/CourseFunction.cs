using AzureNaPratica.Serverless.Application.DataTransferObject.Course;
using AzureNaPratica.Serverless.Application.Interfaces.Course;
using AzureNaPratica.Serverless.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Threading.Tasks;

namespace AzureNaPratica.Serverless.Function.Functions
{
    public class CourseFunction
    {
        private readonly ICourseAppService _courseAppService;

        public CourseFunction(
            ICourseAppService courseAppService)
        {
            _courseAppService = courseAppService;
        }

        [Function("CourseFunction")]
        public async Task<HttpResponseData> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            var logger = executionContext.GetLogger("Course Function");

            try
            {
                if (HttpMethods.IsPost(req.Method))
                {
                    logger.LogInformation("*** POST");

                    var item = Util.OurSerlialization.Deserializer<CourseDto>(req.ReadAsString());

                    await _courseAppService.InsertAsync(item);

                    var response = req.CreateResponse(HttpStatusCode.Created);
                    response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

                    response.WriteString("Course created");

                    return response;
                }
                if (HttpMethods.IsGet(req.Method))
                {
                    var items = await _courseAppService.GetAllAsync();
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
