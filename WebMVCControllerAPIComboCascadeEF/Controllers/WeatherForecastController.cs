using CLSerilog;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace WebMVCControllerAPIComboCascadeEF.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private string _utenteLoggato = "Gino De Ginibus";
        private string _namespace = "WebMVCControllerAPIComboCascadeEF.Controllers.WeatherForecastController";

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            //})
            //.ToArray();

            _namespace = _namespace + " Get GetWeatherForecast";

            List<WeatherForecast> forecasts = null;
            ManageSerilog manageSerilog = new ManageSerilog();

            try
            {
                
                forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                }).ToList();
                //ManageSerilog.LogInformation(_utenteLoggato, _namespace, string.Format("Dati meteo: {0}", forecasts.Count));
                manageSerilog.LogInformation(_utenteLoggato, _namespace, string.Format("Dati meteo: {0}", forecasts.Count));
            }
            catch (Exception ex)
            {
                //string sErr = string.Empty;
                //if (ex.InnerException != null)
                //{
                //    sErr = string.Format("Source: {0}{4}Message: {1}{4}StackTrace: {2}{4}InnerException: {3}{4}", ex.Source, ex.Message, ex.StackTrace, ex.InnerException.Message, System.Environment.NewLine);
                //}
                //else
                //{
                //    sErr = string.Format("Source: {0}{3}Message: {1}{3}StackTrace: {2}{3}", ex.Source, ex.Message, ex.StackTrace, System.Environment.NewLine);
                //}
                //_logger.LogError(sErr);
                //ManageSerilog.LogError(_utenteLoggato, _namespace, ex);
                throw;
            }
            return forecasts;
        }
    }
}
