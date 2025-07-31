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
            var response = await _http.GetAsync($"{_apiBaseUrl}/Movie");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var movies = JsonConvert.DeserializeObject<List<Movie>>(json);
            return movies ?? new List<Movie>();
        }
    }
}
