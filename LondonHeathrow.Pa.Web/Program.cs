using LondonHeathrow.Pa.Web.Data;
using LondonHeathrow.Pa.Web.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace LondonHeathrow.Pa.Web;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddRazorPages();
        builder.Services.AddSignalR();
        builder.Services.AddResponseCompression(options =>
        {
            options.MimeTypes = new[] { "application/octet-stream" };
        });

        builder.Services.AddDbContext<PaDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.MapHub<PaIotHub>("/pa-iot");

        await app.RunAsync();
    }
}