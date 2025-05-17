using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text.Json;
using WeatherApiJson.Models.Response;
using WeatherApiJson.Models;

namespace WeatherApiJson.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        #region Member Variables
        private readonly HttpClient _httpClient;
        private readonly OpenWeatherSettings _settings;
        #endregion

        #region Constructor
        public WeatherController(IHttpClientFactory httpClientFactory,
                                IOptions<OpenWeatherSettings> options)
        {
            _httpClient = httpClientFactory.CreateClient();
            _settings = options.Value;
        }
        #endregion

        #region Action
        [HttpGet]
        public async Task<IActionResult> GetWeatherJson([FromQuery] string city)
        {
            if (string.IsNullOrWhiteSpace(city))
                return BadRequest("City is required.");

            string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_settings.APIKEY}";

            var response = await _httpClient.GetAsync(apiUrl);

            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, "Failed to fetch weather data.");

            var weatherResponse = await response.Content.ReadAsStringAsync();

            var weatherData = JsonSerializer.Deserialize<WeatherResponse>(weatherResponse,
                                                         new JsonSerializerOptions
                                                         {
                                                             PropertyNameCaseInsensitive = true
                                                         });

            return Ok(weatherData);
        }
        #endregion

    }
}
