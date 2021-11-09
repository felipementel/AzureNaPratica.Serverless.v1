using AzureNaPratica.Serverless.Application.Interfaces.Course;
using AzureNaPratica.Serverless.Application.Interfaces.Student;
using AzureNaPratica.Serverless.Application.Services.Course;
using AzureNaPratica.Serverless.Domain.Aggregates.Course.Entities;
using AzureNaPratica.Serverless.Domain.Aggregates.Course.Interfaces.Repositories;
using AzureNaPratica.Serverless.Domain.Aggregates.Course.Interfaces.Services;
using AzureNaPratica.Serverless.Domain.Aggregates.Course.Services;
using AzureNaPratica.Serverless.Domain.Aggregates.Course.Validations;
using AzureNaPratica.Serverless.Domain.Aggregates.Student.Entities;
using AzureNaPratica.Serverless.Domain.Aggregates.Student.Interfaces.MessageBroker;
using AzureNaPratica.Serverless.Domain.Aggregates.Student.Interfaces.Repositories;
using AzureNaPratica.Serverless.Domain.Aggregates.Student.Interfaces.Services;
using AzureNaPratica.Serverless.Domain.Aggregates.Student.Services;
using AzureNaPratica.Serverless.Domain.Aggregates.Student.Validations;
using AzureNaPratica.Serverless.Domain.Base.Interfaces.HttpService;
using AzureNaPratica.Serverless.Domain.Base.Interfaces.Repository.MongoDB;
using AzureNaPratica.Serverless.HttpService;
using AzureNaPratica.Serverless.Infra.Database.Repositories;
using AzureNaPratica.Serverless.Infra.Database.Repositories.Base.MongoDB;
using AzureNaPratica.Serverless.Infra.MessageBroker;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace AzureNaPratica.Serverless.Infra.CrossCutting
{
    public static class IoC
    {
        public static void AddDependenciesInjectios(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton<IMongoDbContext, MongoDbContext>();

            services.AddScoped<ICourseAppService, CourseAppService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IValidator<Course>, CourseValidator>();
            services.AddScoped<ICourseRepository, CourseRepository>();

            services.AddScoped<IStudentAppService, StudentAppService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IValidator<Student>, StudentValidator>();
            services.AddScoped<IStudentRepository, StudentRepository>();

            services.AddScoped<IStudentMessageBroker, StudentMessageBroker>();

            services.AddScoped<ILuckyNumber, LuckyNumber>()
                .AddHttpClient("lucyNumber", config =>
                {
                    config.BaseAddress = new Uri(configuration["ExternalServices:LucyNumber:url"]);
                    config.DefaultRequestHeaders.Add("x-functions-key", configuration["ExternalServices:LucyNumber:ApiKey"]);
                    config.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                })
                .SetHandlerLifetime(TimeSpan.FromMinutes(5))
                .AddPolicyHandler(GetRetryPolicy())
                .AddPolicyHandler(GetCircuitBreakerPolicy());
        }

        public static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(
                retryCount: 6,
                sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                onRetry: (ex, ts, retryCount, context) =>
                {
                    Console.WriteLine($"Retry Policy - Attempt {retryCount} - Error {ex.Exception?.Message}");
                });
        }

        public static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
        {
            return HttpPolicyExtensions.HandleTransientHttpError()
                .CircuitBreakerAsync(3, TimeSpan.FromSeconds(2),
                onBreak: (ex, ts) => Console.WriteLine($"CircuitBreaker Policy onBreak: - {ex.Exception?.Message} - Time {ts} - Open Circuit"),
                onHalfOpen: () => Console.WriteLine("CircuitBreaker Policy - onHalfOpen: Attempt"),
                onReset: () => Console.WriteLine("CircuitBreaker Policy - onReset: Successful request - Closed Circuit"));
        }
    }
}