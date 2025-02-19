using System;
using System.Collections.Generic;

namespace CsharpGenericAdavance
{

    // 1. Generic Constraints 
    public class Repository<T> where T : class
    {
        private List<T> items = [];
        public void Add(T item) => items.Add(item);
        public IEnumerable<T> GetAll() => items;
    }

    // 2. Generic Constraints with Multiple Types
    public class Pair<T1, T2>
        where T1 : struct
        where T2 : class
    {
        public T1 First { get; set; }
        public T2 Second { get; set; }
    }

    // 3. Covariance and Contravariance
    public interface IProducer<out T>
    {
        T Produce();
    }

    public class StringProducer : IProducer<string>
    {
        public string Produce() => "Hello, Covariance!";
    }

    public interface IConsumer<in T>
    {
        void Consume(T item);
    }

    public class ObjectConsumer : IConsumer<object>
    {
        public void Consume(object item)
        {
            Console.WriteLine($"Consumed: {item}");
        }
    }

    // 4. Custom Generic Interfaces
    public interface IRepository<T>
    {
        void Add(T item);
        T Get(int index);
    }

    public class CustomRepository<T> : IRepository<T>
    {
        private List<T> _items = new();
        public void Add(T item) => _items.Add(item);
        public T Get(int index) => _items[index];
    }

    // 5. Generic Methods
    public static class Utility
    {
        public static void Print<T>(T item)
        {
            Console.WriteLine($"Item: {item}");
        }
    }

    // 6. Generic Collections Customization
    public class CustomList<T> : List<T>
    {
        public void PrintAll()
        {
            foreach (var item in this)
            {
                Console.WriteLine(item);
            }
        }
    }

    class Program
    {
        static void Main()
        {

            Repository<string> repo = new();
            repo.Add("Item 1");
            repo.Add("Item 2");
            foreach (var item in repo.GetAll())
                Console.WriteLine(item);

            // Testing Multiple Generic Constraints
            Pair<int, string> pair = new() { First = 10, Second = "Hello" };
            Console.WriteLine($"Pair: {pair.First}, {pair.Second}");

            // Testing Covariance
            IProducer<object> producer = new StringProducer();
            Console.WriteLine(producer.Produce());

            // Testing Contravariance
            IConsumer<string> consumer = new ObjectConsumer();
            consumer.Consume("Contravariant Example");

            // Testing Custom Generic Interfaces
            IRepository<int> intRepo = new CustomRepository<int>();
            intRepo.Add(42);
            Console.WriteLine($"Custom Repository: {intRepo.Get(0)}");

            // Testing Generic Methods
            Utility.Print("Hello, Generics!");
            Utility.Print(123);

            // Testing Generic Collections Customization
            CustomList<double> customList = new CustomList<double> { 1.1, 2.2, 3.3 };
            customList.PrintAll();
        }
    }
}