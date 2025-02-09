using Microsoft.Extensions.Caching.Memory;

namespace Spoonacular
{
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.AspNetCore.Http;

    public class CachingDecorator : RecipeServiceDecorator
    {
        private readonly MemoryCache _cache = new(new MemoryCacheOptions());
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CachingDecorator(IRecipeService recipeService, IHttpContextAccessor httpContextAccessor) : base(recipeService)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public override async Task<string> GetRecipeAsync(string recipeName)
        {
            string user = _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "guest";
            string cacheKey = $"{recipeName.ToLowerInvariant()}_{user}"; 

            if (_cache.TryGetValue(cacheKey, out string cachedResponse))
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
