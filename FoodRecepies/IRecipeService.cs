namespace FoodRecepies
{
    public interface IRecipeService
    {
        Task<string> GetRecipeAsync(string recipeName);
    }
}
