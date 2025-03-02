using System;

namespace SingletonPatternEx
{
    //کلاس Singleton که با sealed محدود شده است
    public sealed class Singleton
    {
        // نمونه یکتا که به صورت استاتیک و تنها یک بار ایجاد می‌شود
        private static readonly Singleton instance = new();

        // متغیر برای شمارش تعداد نمونه‌ها (در اینجا فقط یک نمونه داریم)
        private int numberOfInstances = 0;

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
    // Double Checked Locking


    //public sealed class Singleton
    //{
    //    // ما از volatile استفاده می‌کنیم تا اطمینان حاصل کنیم که
    //    // تخصیص به متغیر instance قبل از دسترسی به آن کامل شده است.
    //    private static volatile Singleton instance;
    //    private static object lockObject = new Object();

    //    private Singleton() { }

    //    public static Singleton Instance
    //    {
    //        get
    //        {
    //            if (instance == null)
    //            {
    //                lock (lockObject)
    //                {
    //                    if (instance == null)
    //                        instance = new Singleton();
    //                }
    //            }
    //            return instance;
    //        }
    //    }
    //}

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Singleton Pattern Demo ***\n");

            // تلاش برای ایجاد نمونه اول
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
