using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Hazeltek.UtiliTrak.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();
            
            host.Run();
        }
    }
}
