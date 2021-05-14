using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherApi
{
    // Both in same file to save time
    public interface IWeatherService
    {
        Task<string> Get(string cityName);
    }
    
    public class WeatherService : IWeatherService
    {
        private HttpClient _httpClient;

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> Get(string city)
        {
            var apiKey = "d6796d810e164f63a7b194048211205";

            string apiUrl = $"?key={apiKey}&q={city}";

            var response = await _httpClient.GetAsync(apiUrl);

            // Throws an exception if invalid response returned.
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}