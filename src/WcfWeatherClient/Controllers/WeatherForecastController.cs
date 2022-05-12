using Microsoft.AspNetCore.Mvc;
using ServiceReference1;

namespace WcfWeatherClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            WeatherServiceClient wheatherServiceClient = new WeatherServiceClient();

            wheatherServiceClient.ClientCredentials.Windows.ClientCredential = new System.Net.NetworkCredential() { Domain = "FULL DOMAIN NAME HERE", UserName = "DOMAIN USER HERE", Password = "<PUT USER DOMAIN PASSWORD HERE>" };

            var result = await wheatherServiceClient.GetWheatherAsync(new GetWheatherRequest() { localtioncode = "pt-PT" });

            return Ok(result.GetWheatherResult);

        }
    }
}