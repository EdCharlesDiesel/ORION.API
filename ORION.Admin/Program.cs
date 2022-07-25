using Microsoft.AspNetCore;

namespace ORION.Admin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();        
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                // .UseUrls("http://0.0.0.0:80")
                // .UseIISIntegration()
                .UseStartup<Startup>();
    }
}

 