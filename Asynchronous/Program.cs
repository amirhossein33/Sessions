namespace Asynchronous_1
{
    //IAsyncEnumrable برای کاهش مصرف حافظه استفاده میشود
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var apiKey = "06f0fb8a229d4ed08108858df97cf6b6";
            Console.WriteLine("Please Enter FoodName");
            var food = Console.ReadLine()?.Trim().ToLower();

            if (string.IsNullOrEmpty(food))
            {
                Console.WriteLine("Food Name not Entered.");
                return;
            }

            var httpService = new HttpService(apiKey);
            var recipeService = new RecipeService(httpService);

            await recipeService.DisplayRecipesAsync(food);
        }
    }
}