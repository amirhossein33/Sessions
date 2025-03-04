using System;

namespace SimpleFactoryPattern
{
    // 1. Common interface for all animals
    public interface IAnimal
    {
        void Speak();
        void Action();
    }

    // 2. Implementation of animal classes
    public class Dog : IAnimal
    {
        public void Speak() => Console.WriteLine("Dog says: Bow-Wow.");
        public void Action() => Console.WriteLine("Dogs prefer barking...");
    }

    public class Tiger : IAnimal
    {
        public void Speak() => Console.WriteLine("Tiger says: Halum.");
        public void Action() => Console.WriteLine("Tigers prefer hunting...");
    }

    // 3. Define enum for animal types
    public enum AnimalType
    {
        Dog,
        Tiger
    }

    // 4. Abstract factory class
    public abstract class SimpleFactoryP
    {
        public abstract IAnimal CreateAnimal(AnimalType type);
    }

    public class SimpleFactory : SimpleFactoryP
    {
        public override IAnimal CreateAnimal(AnimalType type)
        {
            Console.WriteLine($"You have chosen {type}");
            switch (type)
            {
                case AnimalType.Dog:
                    _ = new Dog();
                    break;
                case AnimalType.Tiger:
                    _ = new Tiger();
                    break;
                default:
                    Console.WriteLine("Invalid animal type.");
                    throw new ApplicationException("Unknown Animal cannot be instantiated");
            }

            return null;
        }
    }

    // 6. Implementation of the Client class
    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Simple Factory Pattern Demo ***\n");

            IAnimal preferredType = null;
            SimpleFactoryP simpleFactory = new SimpleFactory();

            #region Code that varies based on user input
            Console.WriteLine("Enter your choice (0 for Dog, 1 for Tiger):");
            string inputStr = Console.ReadLine();
            int input;

            if (int.TryParse(inputStr, out input))
            {
                if (Enum.IsDefined(typeof(AnimalType), input))
                {
                    AnimalType selectedType = (AnimalType)input;
                    preferredType = simpleFactory.CreateAnimal(selectedType);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 0 for Dog or 1 for Tiger.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
            #endregion

            #region Code that does not vary
            if (preferredType != null)
            {
                preferredType.Speak();
                preferredType.Action();
            }
            #endregion

            Console.ReadKey();
        }
    }
}
