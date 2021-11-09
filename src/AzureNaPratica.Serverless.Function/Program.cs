using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Functions.Worker.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AzureNaPratica.Serverless.Infra.Database.Maps.Setup;
using AzureNaPratica.Serverless.Domain.Configs;
using AzureNaPratica.Serverless.Infra.CrossCutting;
using Serilog;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Builder;
using Serilog.Events;
using System.Reflection;

namespace AzureNaPratica.Serverless.Function
{
    public class Program
    {
        public static async Task Main()
        {
            var host = new HostBuilder()
                .ConfigureAppConfiguration((builder, configurationBuilder) =>
                {
                    configurationBuilder.AddJsonFile("local.settings.json", true, true)
                        .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
                        .AddEnvironmentVariables();

                    if (builder.HostingEnvironment.IsDevelopment())
                    {
                        configurationBuilder
                            .AddUserSecrets<Program>();
                    }
                })
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureLogging(logging => 
                {
                    Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                    .Enrich.FromLogContext()
                    .WriteTo.Console()
                    .CreateLogger();
                })
                .ConfigureServices((context, services) =>
                {
                    SetupMaps
                    .ConfigureMaps();

                    services
                       .AddOptions<ApplicationSettings>()
                       .Configure<IConfiguration>(
                           (settings, configuration) =>
                           {
                               configuration.Bind(settings);
                           });

                    services
                       .AddOptions<ConnectionStrings>()
                       .Configure<IConfiguration>(
                           (settings, configuration) =>
                           {
                               //configuration.Bind(nameof(ConnectionStrings), settings);
                               configuration.GetSection(nameof(ConnectionStrings)).Bind(settings);
                           });

                    services.Configure<GzipCompressionProviderOptions>(options =>
                    {
                        options.Level = System.IO.Compression.CompressionLevel.Optimal;
                    })
                    .AddResponseCompression(options =>
                    {
                        options.Providers.Add<GzipCompressionProvider>();
                        options.EnableForHttps = true;
                    });

                    services.AddDependenciesInjectios(context.Configuration);
                })
                .Build();

            await host.RunAsync();
        }
    }
}