
using Serilog.Events;
using Serilog;

namespace WebMVCControllerAPIComboCascadeEF
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Logging.ClearProviders();   // NO Microsoft Logging - VEDERE Sezione Logging di appsettings.json

            // SERILOG
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build())
                .MinimumLevel.Override("Microsoft", LogEventLevel.Error)  // NO Microsoft Logging
                .Enrich.FromLogContext()
                .CreateLogger();

            var configurationBuilder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, false);

            var config = configurationBuilder.Build();


            // SERILOG
            builder.Host.UseSerilog(logger);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            // SWAGGER
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                // SWAGGER
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // PATRIZIO
            app.UseStaticFiles();

            // SERILOG
            app.UseSerilogRequestLogging();

            app.UseRouting();

            app.UseAuthorization();


            app.MapControllers();

            
            app.Run();
        }
    }
}
