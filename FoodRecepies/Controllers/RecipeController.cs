using Microsoft.AspNetCore.Mvc;

namespace FoodRecepies.Controllers
{
    [ApiController]
    [Route("api/recipes")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet("{recipeName}")]
        public async Task<IActionResult> GetRecipe(string recipeName)
        {
            var normalizedRecipeName = recipeName.ToLowerInvariant(); 
            var result = await _recipeService.GetRecipeAsync(normalizedRecipeName);
            return Ok(result);
        }
    }
}
