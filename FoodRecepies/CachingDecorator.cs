using Microsoft.Extensions.Caching.Memory;

namespace FoodRecepies
{
    public class CachingDecorator : IRecipeService
    {
        private readonly IRecipeService _recipeService;
        private readonly MemoryCache _cache = new(new MemoryCacheOptions());

        public CachingDecorator(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public async Task<string> GetRecipeAsync(string recipeName)
        {
            string cacheKey = recipeName.ToLowerInvariant(); // تبدیل به حروف کوچک

            if (_cache.TryGetValue(cacheKey, out string? cachedResponse))
            {
                Console.WriteLine($"[CACHE] Returning cached result for: {recipeName}");
                return cachedResponse;
            }

            var result = await _recipeService.GetRecipeAsync(recipeName);
            _cache.Set(cacheKey, result, TimeSpan.FromMinutes(5)); 
            return result;
        }
    }
}
