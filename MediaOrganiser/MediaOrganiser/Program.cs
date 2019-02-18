using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using MediaOrganiser.Models;
using Microsoft.EntityFrameworkCore;

namespace MediaOrganiser
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
                .Build();

        //public static void Main(string[] args)
        //{
        //    var host = CreateWebHostBuilder(args).Build();

        //    using (var scope = host.Services.CreateScope())
        //    {
        //        var services = scope.ServiceProvider;

        //        try
        //        {
        //            var context = services.GetRequiredService<MediaOrganiserContext>();
        //            context.Database.Migrate();
        //            SeedData.Initialize(services);
        //        }
        //        catch (Exception ex)
        //        {
        //            var logger = services.GetRequiredService<ILogger<Program>>();
        //            logger.LogError(ex, "An error occurred seeding the DB.");
        //        }
        //    }

        //    host.Run();
        //}

        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        .UseStartup<Startup>();
    }
}