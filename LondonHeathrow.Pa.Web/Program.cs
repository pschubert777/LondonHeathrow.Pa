using LondonHeathrow.Pa.Web.Data;
using LondonHeathrow.Pa.Web.Hubs;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace LondonHeathrow.Pa.Web;

public class Program
{


    public static async Task Main(string[] args)
    {
        await CreateHostBuilder(args).Build().RunAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });

    
}