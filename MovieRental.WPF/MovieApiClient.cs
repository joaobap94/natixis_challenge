using MovieRental.WPF.DTO;
using Newtonsoft.Json;
using System.Net.Http;
namespace MovieRental.WPF
{
    public class MovieApiClient
    {
        private readonly HttpClient _http = new HttpClient();
        // this is assuming we run the project as http
        private readonly string _apiBaseUrl = "http://localhost:5219";

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            const int maxRetries = 5;
            int msDelay = 1000;

            for (int attempt = 1; attempt <= maxRetries; attempt++)
            {
                try
                {
                    var response = await _http.GetAsync($"{_apiBaseUrl}/Movie");
                    response.EnsureSuccessStatusCode();
                    var json = await response.Content.ReadAsStringAsync();
                    var movies = JsonConvert.DeserializeObject<List<Movie>>(json);
                    return movies ?? new List<Movie>();
                }
                catch (HttpRequestException) when (attempt < maxRetries)
                {
                    await Task.Delay(msDelay);
                }
            }

            throw new Exception("API did not respond after several attempts.");
        }
    }
}
