using System;

namespace TemplateMethodPattern
{
    
    public abstract class FoodPreparation
    {
        
        public void PrepareFood()
        {
            GatherIngredients();
            PrepareMainItem();
            AddCondiments();
            Cook();
            Serve();
        }

        
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

        
        protected abstract void PrepareMainItem();
        protected abstract void AddCondiments();
    }

   
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
