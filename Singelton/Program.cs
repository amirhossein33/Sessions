using System;

namespace SingletonPatternEx
{
    //کلاس Singleton که با sealed محدود شده است
    public sealed class Singleton
    {
        // نمونه یکتا که به صورت استاتیک و تنها یک بار ایجاد می‌شود
        private static readonly Singleton instance = new();

        // متغیر برای شمارش تعداد نمونه‌ها (در اینجا فقط یک نمونه داریم)
        private readonly int numberOfInstances = 0;

        // سازنده خصوصی که اجازه ایجاد نمونه خارج از کلاس را نمی‌دهد
        private Singleton()
        {
            Console.WriteLine("Instantiating inside the private constructor.");
            numberOfInstances++;
            Console.WriteLine("Number of instances ={0}", numberOfInstances);
        }

        // ویژگی استاتیک برای دسترسی به نمونه یکتا
        public static Singleton Instance
        {
            get
            {
                Console.WriteLine("We already have an instance now. Use it.");
                return instance;
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Singleton Pattern Demo ***\n");

            Console.WriteLine("Trying to create instance s1.");
            Singleton s1 = Singleton.Instance;

            // تلاش برای ایجاد نمونه دوم
            Console.WriteLine("Trying to create instance s2.");
            Singleton s2 = Singleton.Instance;

            // بررسی اینکه آیا هر دو نمونه یکی هستند
            if (s1 == s2)
            {
                Console.WriteLine("Only one instance exists.");
            }
            else
            {
                Console.WriteLine("Different instances exist.");
            }

            Console.Read();
        }
    }
}
