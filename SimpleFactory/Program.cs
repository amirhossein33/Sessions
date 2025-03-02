using System;

namespace SimpleFactoryPattern
{
    // 1. اینترفیس مشترک برای همه حیوانات
    public interface IAnimal
    {
        void Speak();
        void Action();
    }

    // 2. پیاده‌سازی کلاس‌های حیوانات
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

    // 3. تعریف enum برای انواع حیوانات
    public enum AnimalType
    {
        Dog,
        Tiger
    }

    // 4. کلاس انتزاعی کارخانه
    public abstract class ISimpleFactory
    {
        public abstract IAnimal CreateAnimal(AnimalType type);
    }

    // 5. پیاده‌سازی کلاس Simple Factory
    public class SimpleFactory : ISimpleFactory
    {
        public override IAnimal CreateAnimal(AnimalType type)
        {
            IAnimal intendedAnimal = null;

            Console.WriteLine($"You have chosen {type}");

            switch (type)
            {
                case AnimalType.Dog:
                    intendedAnimal = new Dog();
                    break;
                case AnimalType.Tiger:
                    intendedAnimal = new Tiger();
                    break;
                default:
                    Console.WriteLine("Invalid animal type.");
                    throw new ApplicationException("Unknown Animal cannot be instantiated");
            }

            return intendedAnimal;
        }
    }

    // 6. پیاده‌سازی کلاس Client
    class Client
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Simple Factory Pattern Demo ***\n");

            IAnimal preferredType = null;
            ISimpleFactory simpleFactory = new SimpleFactory();

            #region کدی که بسته به ورودی کاربر تغییر می‌کند
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

            #region کدی که تغییر نمی‌کند
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