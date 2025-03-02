using System;

namespace AbstractFactoryPattern
{
    // 1. اینترفیس انتزاعی برای محصولات دیجیتال
    public interface IDigitalProduct
    {
        void DisplayDetails();
    }

    // 2. اینترفیس انتزاعی برای محصولات فیزیکی
    public interface IPhysicalProduct
    {
        void DisplayDetails();
    }

    #region Digital Product Collections
    // 3. پیاده‌سازی محصولات دیجیتال
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
    // 4. پیاده‌سازی محصولات فیزیکی
    class Book : IPhysicalProduct
    {
        public void DisplayDetails() => Console.WriteLine("Book: A physical book that can be shipped.");
    }

    class Laptop : IPhysicalProduct
    {
        public void DisplayDetails() => Console.WriteLine("Laptop: A high-performance physical computing device.");
    }
    #endregion

    // 5. کارخانه انتزاعی (Abstract Factory)
    public interface IProductFactory
    {
        IDigitalProduct GetDigitalProduct();
        IPhysicalProduct GetPhysicalProduct();
    }

    // 6. کارخانه Concrete برای محصولات دیجیتال
    public class DigitalProductFactory : IProductFactory
    {
        public IDigitalProduct GetDigitalProduct() => new EBook();
        public IPhysicalProduct GetPhysicalProduct() => new Laptop();
    }

    // 7. کارخانه Concrete برای محصولات فیزیکی
    public class PhysicalProductFactory : IProductFactory
    {
        public IDigitalProduct GetDigitalProduct() => new OnlineCourse();
        public IPhysicalProduct GetPhysicalProduct() => new Book();
    }

    // 8. پیاده‌سازی کلاس Client
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Abstract Factory Pattern Demo ***\n");

            // ایجاد محصولات دیجیتال با استفاده از DigitalProductFactory
            IProductFactory digitalFactory = new DigitalProductFactory();
            IDigitalProduct digitalProduct = digitalFactory.GetDigitalProduct();
            IPhysicalProduct physicalProduct = digitalFactory.GetPhysicalProduct();

            Console.WriteLine("Digital Factory Products:");
            digitalProduct.DisplayDetails();
            physicalProduct.DisplayDetails();

            Console.WriteLine("******************");

            // ایجاد محصولات فیزیکی با استفاده از PhysicalProductFactory
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
