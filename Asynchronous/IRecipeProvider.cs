namespace Asynchronous_1
{
    public interface IRecipeProvider
    {
        IAsyncEnumerable<Recipe> GetRecipesAsync(string ingredient);
    }
}
