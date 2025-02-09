namespace FoodRecepies
{
    public class LoggingDecorator(IRecipeService recipeService) : IRecipeService
    {
        public async Task<string> GetRecipeAsync(string recipeName)
        {
            Console.WriteLine($" Requesting recipe: {recipeName}");
            var result = await recipeService.GetRecipeAsync(recipeName);
            Console.WriteLine($" Response received for: {recipeName}");
            return result;
        }
    }
}