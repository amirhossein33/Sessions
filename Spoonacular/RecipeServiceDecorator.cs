namespace Spoonacular
{
    public class RecipeServiceDecorator : IRecipeService
    {
        protected readonly IRecipeService _recipeService;

        public RecipeServiceDecorator(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public virtual async Task<string> GetRecipeAsync(string recipeName)
        {
            return await _recipeService.GetRecipeAsync(recipeName);
        }
    }

}