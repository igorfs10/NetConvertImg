using ApplicationCore.Interfaces.Services;
using ApplicationCore.Services;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace NetConvertImg
{
    internal static class Program
    {
        public static IServiceProvider? ServiceProvider { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;
            ServiceProvider.GetRequiredService<DbContext>().Database.EnsureCreated();

            Application.Run(ServiceProvider.GetRequiredService<Form1>());
        }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddTransient<Form1>();
                    services.AddScoped<IFileService, FileService>();
                    services.AddScoped<IImageService, ImageService>();
                    services.AddScoped<DbContext, BaseDbContext>();
                    services.AddDbContext<DbContext>(options =>
                    {
                        options.UseSqlite("Data Source=app.db;Cache=Shared;");
                    });
                });
        }
    }
}