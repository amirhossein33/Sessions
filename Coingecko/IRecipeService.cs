namespace Coingecko
{
    public interface IRecipeService
    {
        Task<string> GetRecipeAsync(string recipeName);
    }
}
