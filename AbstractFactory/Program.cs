using System;

namespace AbstractFactoryPattern
{
    // 1. Abstract interface for digital products
    public interface IDigitalProduct
    {
        void DisplayDetails();
    }

    // 2. Abstract interface for physical products
    public interface IPhysicalProduct
    {
        void DisplayDetails();
    }

    #region Digital Product Collections
    // 3. Implementation of digital products
    class EBook : IDigitalProduct
    {
        public void DisplayDetails() => Console.WriteLine("E-Book: A digital book available for download.");
    }

    class OnlineCourse : IDigitalProduct
    {
        public void DisplayDetails() => Console.WriteLine("Online Course: A self-paced course available online.");
    }
    #endregion

    #region Physical Product Collections
    // 4. Implementation of physical products
    class Book : IPhysicalProduct
    {
        public void DisplayDetails() => Console.WriteLine("Book: A physical book that can be shipped.");
    }

    class Laptop : IPhysicalProduct
    {
        public void DisplayDetails() => Console.WriteLine("Laptop: A high-performance physical computing device.");
    }
    #endregion

    // 5. Abstract Factory
    public interface IProductFactory
    {
        IDigitalProduct GetDigitalProduct();
        IPhysicalProduct GetPhysicalProduct();
    }

    // 6. Concrete Factory for digital products
    public class DigitalProductFactory : IProductFactory
    {
        public IDigitalProduct GetDigitalProduct() => new EBook();
        public IPhysicalProduct GetPhysicalProduct() => new Laptop();
    }

    // 7. Concrete Factory for physical products
    public class PhysicalProductFactory : IProductFactory
    {
        public IDigitalProduct GetDigitalProduct() => new OnlineCourse();
        public IPhysicalProduct GetPhysicalProduct() => new Book();
    }

    // 8. Implementation of the Client class
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Abstract Factory Pattern Demo ***\n");

            // Create digital products using DigitalProductFactory
            IProductFactory digitalFactory = new DigitalProductFactory();
            IDigitalProduct digitalProduct = digitalFactory.GetDigitalProduct();
            IPhysicalProduct physicalProduct = digitalFactory.GetPhysicalProduct();

            Console.WriteLine("Digital Factory Products:");
            digitalProduct.DisplayDetails();
            physicalProduct.DisplayDetails();


            // Create physical products using PhysicalProductFactory
            IProductFactory physicalFactory = new PhysicalProductFactory();
            IDigitalProduct anotherDigitalProduct = physicalFactory.GetDigitalProduct();
            IPhysicalProduct anotherPhysicalProduct = physicalFactory.GetPhysicalProduct();

            Console.WriteLine("Physical Factory Products:");
            anotherDigitalProduct.DisplayDetails();
            anotherPhysicalProduct.DisplayDetails();

            Console.ReadLine();
        }
    }
}
