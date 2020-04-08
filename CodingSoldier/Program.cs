using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using CodingSoldier.App_Start;

namespace CodingSoldier
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls("http://*:2350")
                .UseIISIntegration()
                .Build();
    }
}
