using System.Net.Http;
using System.Text.Json;
using LifeManagementApp.Interfaces;
using LifeManagementApp.Models;

namespace LifeManagementApp.Services
{
    public class JokeApiService : IJokeService
    {
        private readonly HttpClient _httpClient;

        public JokeApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Joke>> GetJokesAsync(int amount = 1)
        {
            var url =
                $"https://v2.jokeapi.dev/joke/Programming?blacklistFlags=nsfw,religious,political,racist,sexist,explicit&amount={amount}";

            using var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var jokes = new List<Joke>();

            using var doc = JsonDocument.Parse(json);

            if (doc.RootElement.TryGetProperty("jokes", out var jokesArray))
            {
                foreach (var item in jokesArray.EnumerateArray())
                {
                    var type = item.GetProperty("type").GetString();
                    if (type == "single")
                    {
                        var text = item.GetProperty("joke").GetString() ?? "";
                        jokes.Add(new Joke { Text = text });
                    }
                    else if (type == "twopart")
                    {
                        var setup = item.GetProperty("setup").GetString() ?? "";
                        var delivery = item.GetProperty("delivery").GetString() ?? "";
                        jokes.Add(new Joke { Text = $"{setup} {delivery}" });
                    }
                }
            }
            else
            {
                var type = doc.RootElement.GetProperty("type").GetString();
                if (type == "single")
                {
                    var text = doc.RootElement.GetProperty("joke").GetString() ?? "";
                    jokes.Add(new Joke { Text = text });
                }
                else if (type == "twopart")
                {
                    var setup = doc.RootElement.GetProperty("setup").GetString() ?? "";
                    var delivery = doc.RootElement.GetProperty("delivery").GetString() ?? "";
                    jokes.Add(new Joke { Text = $"{setup} {delivery}" });
                }
            }

            return jokes;
        }
    }
}
