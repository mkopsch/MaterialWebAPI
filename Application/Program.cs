using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace MaterialWebAPI.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                    .UseUrls("https://localhost:5001;https://MARTINS-MBP:5001;http://MARTINS-MBP:5000")
                    .UseStartup<Startup>();
                });
    }
}
