using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace COG.WEB
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args)
                .Build();

           // await SeedDatabase(host.Services);
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        // private static async Task SeedDatabase(IServiceProvider serviceProvider)
        // {
        //     using var serviceScope = serviceProvider.CreateScope();
        //     var context = serviceScope.ServiceProvider.GetRequiredService<MainDbContext>();

        //     await context.Seed(serviceScope);
        // }
    }
}
