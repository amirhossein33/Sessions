namespace FoodRecepies
{
    public class RateLimitingDecorator : IRecipeService
    {
        private readonly IRecipeService _recipeService;
        private static readonly SemaphoreSlim _semaphore = new(5, 5); // حداکثر ۵ درخواست همزمان

        public RateLimitingDecorator(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public async Task<string> GetRecipeAsync(string recipeName)
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
