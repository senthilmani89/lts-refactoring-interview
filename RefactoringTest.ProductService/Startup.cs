using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RefactoringTest.ProductService;
using System;

[assembly: FunctionsStartup(typeof(Startup))]

namespace RefactoringTest.ProductService
{
    public class Startup : FunctionsStartup
    {
        private void RegisterServices(IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            services.AddSingleton(c => config);
            services.AddLogging();
        }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            RegisterServices(builder.Services);
        }
    }
}
