using AzureNaPratica.Serverless.Application.Interfaces.Course;
using AzureNaPratica.Serverless.Application.Services.Course;
using AzureNaPratica.Serverless.Domain.Aggregates.Course.Interfaces.Services;
using AzureNaPratica.Serverless.Domain.Aggregates.Course.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AzureNaPratica.Serverless.CrossCutting
{
    public static class IoC
    {
        public static void DependenciesInjectios(this ServiceCollection services)
        {
            services.AddScoped<ICourseAppService, CourseAppService>();
            services.AddScoped<ICourseService, CourseService>();
        }
    }
}