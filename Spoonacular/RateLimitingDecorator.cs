namespace Spoonacular
{
    using System.Threading;

    public class RateLimitingDecorator : RecipeServiceDecorator
    {
        private static readonly SemaphoreSlim _semaphore = new(20, 20); // افزایش از 5 به 20

        public RateLimitingDecorator(IRecipeService recipeService) : base(recipeService) { }

        public override async Task<string> GetRecipeAsync(string recipeName)
        {
            await _semaphore.WaitAsync();
            try
            {
                return await _recipeService.GetRecipeAsync(recipeName);
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }

}