namespace Asynchronous_1
{
    public class RecipeService
    {
        private readonly IRecipeProvider _recipeProvider;

        public RecipeService(IRecipeProvider recipeProvider)
        {
            _recipeProvider = recipeProvider;
        }

        public async Task DisplayRecipesAsync(string ingredient)
        {
            try
            {
                await foreach (var recipe in _recipeProvider.GetRecipesAsync(ingredient))
                {
                    Console.WriteLine($"- {recipe.Title}");
                    Console.WriteLine($"  Image: {recipe.Image}");
                    Console.WriteLine($"  Summary: {recipe.Summary}");
                    Console.WriteLine(new string('-', 50));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to get recipes: {ex.Message}");
            }
        }
    }
}
