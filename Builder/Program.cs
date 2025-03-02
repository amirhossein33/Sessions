using System;
using System.Collections.Generic;  // برای استفاده از LinkedList

namespace BuilderPattern
{
    // "IBuilder" : رابط سازنده
    interface IBuilder
    {
        void StartUpOperations();  // عملیات شروع
        void BuildBody();          // ساخت بدنه
        void InsertWheels();       // اضافه کردن چرخ‌ها
        void AddHeadlights();      // اضافه کردن چراغ‌ها
        void EndOperations();      // عملیات پایان
        Product GetVehicle();      // دریافت وسیله نقلیه نهایی
    }

    // "ConcreteBuilder" : پیاده‌سازی سازنده برای ماشین
    class Car : IBuilder
    {
        private string brandName;  // نام برند ماشین
        private Product product;   // محصول نهایی (وسیله نقلیه)

        public Car(string brand)
        {
            product = new Product();   // ایجاد شیء جدید محصول
            this.brandName = brand;    // ذخیره نام برند
        }

        public void StartUpOperations()
        {
            product.Add(string.Format("Car Model name: {0}", this.brandName));  // اضافه کردن نام مدل ماشین
        }

        public void BuildBody()
        {
            product.Add("This is a body of a Car");  // اضافه کردن بدنه ماشین
        }

        public void InsertWheels()
        {
            product.Add("4 wheels are added");  // اضافه کردن 4 چرخ
        }

        public void AddHeadlights()
        {
            product.Add("2 Headlights are added");  // اضافه کردن 2 چراغ جلو
        }

        public void EndOperations()
        {
            // هیچ‌کاری در عملیات پایان برای ماشین انجام نمی‌شود
        }

        public Product GetVehicle()
        {
            return product;  // بازگشت محصول نهایی (ماشین)
        }
    }

    // "ConcreteBuilder" : پیاده‌سازی سازنده برای موتور سیکلت
    class MotorCycle : IBuilder
    {
        private string brandName;  // نام برند موتور سیکلت
        private Product product;   // محصول نهایی (وسیله نقلیه)

        public MotorCycle(string brand)
        {
            product = new Product();   // ایجاد شیء جدید محصول
            this.brandName = brand;    // ذخیره نام برند
        }

        public void StartUpOperations()
        {
            // هیچ‌کاری در عملیات شروع برای موتور سیکلت انجام نمی‌شود
        }

        public void BuildBody()
        {
            product.Add("This is a body of a Motorcycle");  // اضافه کردن بدنه موتور سیکلت
        }

        public void InsertWheels()
        {
            product.Add("2 wheels are added");  // اضافه کردن 2 چرخ
        }

        public void AddHeadlights()
        {
            product.Add("1 Headlight is added");  // اضافه کردن 1 چراغ جلو
        }

        public void EndOperations()
        {
            product.Add(string.Format("Motorcycle Model name: {0}", this.brandName));  // اضافه کردن نام مدل موتور سیکلت
        }

        public Product GetVehicle()
        {
            return product;  // بازگشت محصول نهایی (موتور سیکلت)
        }
    }

    // "Product" : محصول نهایی (وسیله نقلیه)
    class Product
    {
        private LinkedList<string> parts;  // فهرست اجزای محصول (بدنه، چرخ‌ها، چراغ‌ها)

        public Product()
        {
            parts = new LinkedList<string>();  // ایجاد لیست برای نگهداری اجزا
        }

        public void Add(string part)
        {
            parts.AddLast(part);  // اضافه کردن یک بخش به لیست
        }

        public void Show()
        {
            Console.WriteLine("\nProduct completed as below:");
            foreach (string part in parts)
            {
                Console.WriteLine(part);  // نمایش اجزای محصول نهایی
            }
        }
    }

    // "Director" : کارگردان، مسئول هدایت فرآیند ساخت
    class Director
    {
        IBuilder builder;  // رابط سازنده

        // یک سری مراحل برای ساخت محصول
        public void Construct(IBuilder builder)
        {
            this.builder = builder;  // تنظیم سازنده برای استفاده
            builder.StartUpOperations();  // عملیات شروع
            builder.BuildBody();          // ساخت بدنه
            builder.InsertWheels();       // اضافه کردن چرخ‌ها
            builder.AddHeadlights();      // اضافه کردن چراغ‌ها
            builder.EndOperations();      // عملیات پایان
        }
    }

    // "Main" : اجرای برنامه
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Builder Pattern Demo***");

            Director director = new ();  // ایجاد شیء کارگردان

            IBuilder b1 = new Car("Ford");  // ایجاد سازنده برای ماشین
            IBuilder b2 = new MotorCycle("Honda");  // ایجاد سازنده برای موتور سیکلت

            // ساخت ماشین
            director.Construct(b1);  // فراخوانی فرآیند ساخت برای ماشین
            Product p1 = b1.GetVehicle();  // دریافت ماشین ساخته شده
            p1.Show();  // نمایش جزئیات ماشین

            // ساخت موتور سیکلت
            director.Construct(b2);  // فراخوانی فرآیند ساخت برای موتور سیکلت
            Product p2 = b2.GetVehicle();  // دریافت موتور سیکلت ساخته شده
            p2.Show();  // نمایش جزئیات موتور سیکلت

            Console.ReadLine();  // نگه‌داشتن کنسول برای مشاهده نتایج
        }
    }
}
