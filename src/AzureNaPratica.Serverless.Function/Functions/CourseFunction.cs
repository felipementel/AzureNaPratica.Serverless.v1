using AzureNaPratica.Serverless.Application.Interfaces.Course;
using AzureNaPratica.Serverless.Application.Services.Course;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

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
        public static HttpResponseData Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            if (HttpMethods.IsPost(req.Method))
            {
               
            }

            var logger = executionContext.GetLogger("HttpTrigger1");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
