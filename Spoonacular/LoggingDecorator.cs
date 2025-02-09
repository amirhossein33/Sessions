namespace Spoonacular
{
    using System.Diagnostics;

    public class LoggingDecorator : RecipeServiceDecorator
    {
        public LoggingDecorator(IRecipeService recipeService) : base(recipeService) { }

        public override async Task<string> GetRecipeAsync(string recipeName)
        {
            Console.WriteLine($" Requesting recipe: {recipeName}");
            var stopwatch = Stopwatch.StartNew();

            try
            {
                var result = await _recipeService.GetRecipeAsync(recipeName);
                stopwatch.Stop();
                Console.WriteLine($" Response received for: {recipeName} in {stopwatch.ElapsedMilliseconds}ms");
                return result;
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                Console.WriteLine($" Error fetching recipe {recipeName}: {ex.Message} - Took {stopwatch.ElapsedMilliseconds}ms");
                throw;
            }
        }
    }

}
