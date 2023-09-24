using BE.Data.Identity;
using BE.Data.Seeds;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;


namespace BE
{
    
    public class Program
    {
        public static string EnvironmentName => Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

        public static async Task Main(string[] args)
        {

            var builder =
                new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();

            Log.Logger =
                new Serilog.LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .CreateLogger();


            try
            {
                Log.Information("Creating host builder ...");
                var hostBuilder = CreateHostBuilder(args);

                Log.Information("Building host ...");
                var host = hostBuilder.Build();

                using var scope = host.Services.CreateScope();
                var services = scope.ServiceProvider;
                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                await DefaultRoles.SeedAsync(roleManager);
                await DefaultUsers.SeedNormalUserAsync(userManager);
                await DefaultUsers.SeedAdminUserAsync(userManager);
                await DefaultUsers.SeedSuperAdminUserAsync(userManager, roleManager);
                Log.Information("Running host ...");
                host.Run();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unhandled exception : {ex}");
                Serilog.Log.Fatal(ex, "Host terminated unexpectedly.");
            }
            finally
            {
                Serilog.Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}