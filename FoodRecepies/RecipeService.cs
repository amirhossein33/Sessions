namespace FoodRecepies
{
    public abstract class RecipeService : IRecipeService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "06f0fb8a229d4ed08108858df97cf6b6";

        public RecipeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetRecipeAsync(string recipeName)
        {
            var url = $"https://api.spoonacular.com/recipes/complexSearch?query={recipeName}&apiKey={ApiKey}";
            var response = await _httpClient.GetStringAsync(url);
            return response;
        }
    }

}
