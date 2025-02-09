using System.Text.Json;

namespace Asynchronous_1
{
    public class HttpService(string apiKey) : IRecipeProvider
    {
        private readonly string _apiKey = apiKey;

        public async IAsyncEnumerable<Recipe> GetRecipesAsync(string food)
        {
            using var httpClient = new HttpClient();
            var url = $"https://api.spoonacular.com/recipes/complexSearch?query={food}&apiKey={_apiKey}";
            var response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error: {response.StatusCode}");

            var json = await response.Content.ReadAsStringAsync();
            JsonSerializerOptions jsonSerializerOptions = new() { PropertyNameCaseInsensitive = true };
            var options = jsonSerializerOptions;

            var result = JsonSerializer.Deserialize<RecipeSearchResult>(json, options);

            if (result.Results != null)
            {
                foreach (var recipe in result.Results)
                {
                    yield return recipe;
                }
            }
        }

       
    }
}
