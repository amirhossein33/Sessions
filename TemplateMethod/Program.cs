using System;

namespace TemplateMethodPattern
{
    // 1️⃣ کلاس انتزاعی که مراحل اصلی آماده‌سازی غذا را مشخص می‌کند
    public abstract class FoodPreparation
    {
        // متد Template که ترتیب کلی مراحل را مشخص می‌کند
        public void PrepareFood()
        {
            GatherIngredients();
            PrepareMainItem();
            AddCondiments();
            Cook();
            Serve();
        }

        // مراحل مشترک (برای همه غذاها یکسان است)
        private void GatherIngredients()
        {
            Console.WriteLine("Gathering ingredients...");
        }

        private void Cook()
        {
            Console.WriteLine("Cooking the food...");
        }

        private void Serve()
        {
            Console.WriteLine("Serving the food.\n");
        }

        // متدهای انتزاعی که هر غذا باید پیاده‌سازی کند
        protected abstract void PrepareMainItem();
        protected abstract void AddCondiments();
    }

    // 2️⃣ کلاس پیتزا (Pizza)
    public class Pizza : FoodPreparation
    {
        protected override void PrepareMainItem()
        {
            Console.WriteLine("Rolling the pizza dough and adding sauce.");
        }

        protected override void AddCondiments()
        {
            Console.WriteLine("Adding cheese and toppings.");
        }
    }

    // 3️⃣ کلاس همبرگر (Burger)
    public class Burger : FoodPreparation
    {
        protected override void PrepareMainItem()
        {
            Console.WriteLine("Grilling the burger patty.");
        }

        protected override void AddCondiments()
        {
            Console.WriteLine("Adding lettuce, tomato, and sauces.");
        }
    }

    // 4️⃣ برنامه اصلی (Client)
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Template Method Pattern - Food Preparation ***\n");

            // تهیه پیتزا
            FoodPreparation pizza = new Pizza();
            Console.WriteLine("Making Pizza:");
            pizza.PrepareFood();

            // تهیه همبرگر
            FoodPreparation burger = new Burger();
            Console.WriteLine("Making Burger:");
            burger.PrepareFood();

            Console.ReadKey();
        }
    }
}
