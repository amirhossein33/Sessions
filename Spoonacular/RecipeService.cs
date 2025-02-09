using System.Text.Json;

namespace Spoonacular
{
    public class RecipeService : IRecipeService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "06f0fb8a229d4ed08108858df97cf6b6"; // کلید API

        public RecipeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetRecipeAsync(string recipeName)
        {
            var url = $"https://api.spoonacular.com/recipes/complexSearch?query={recipeName}&apiKey={ApiKey}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error fetching recipe: {response.StatusCode}");
            }

            var json = await response.Content.ReadAsStringAsync();
            return FormatResponse(json);
        }

        private string FormatResponse(string json)
        {
            using var doc = JsonDocument.Parse(json);
            var results = doc.RootElement.GetProperty("results");

            if (results.GetArrayLength() == 0)
            {
                return "No recipes found.";
            }

            var firstRecipe = results[0];
            return $"Recipe: {firstRecipe.GetProperty("title").GetString()}, ID: {firstRecipe.GetProperty("id").GetInt32()}";
        }
    }
}