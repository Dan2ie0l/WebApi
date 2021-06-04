using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Initializers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RestApi.Implementations.Data;

namespace RestApi
{
    public class Program
    {
        public async static Task CreateDbIfNotExists(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<ApplicationDbContext>();
            await ApplicationContextInitializer.InitializeAsync(context);
        }

        public async static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            await CreateDbIfNotExists(host);

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
