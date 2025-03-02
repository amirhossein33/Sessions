using System;

namespace SingletonExamples
{
    // روش 1: پیاده‌سازی ساده (غیر Thread-Safe)
    public sealed class Singleton1
    {
        private static Singleton1? instance;
        private Singleton1() { }
        public static Singleton1 Instance
        {
            get
            {
                instance ??= new Singleton1();
                return instance;
            }
        }
    }

    // روش 2: استفاده از lock برای Thread-Safety
    public sealed class Singleton2
    {
        private static Singleton2? instance;
        private static readonly object padlock = new object();
        private Singleton2() { }
        public static Singleton2 Instance
        {
            get
            {
                lock (padlock)
                {
                    instance ??= new Singleton2();
                    return instance;
                }
            }
        }
    }

    // روش 3: استفاده از Lazy<T> (بهترین روش عمومی)
    public sealed class Singleton3
    {
        private static readonly Lazy<Singleton3> lazyInstance =
            new(() => new Singleton3());
        private Singleton3() { }
        public static Singleton3 Instance => lazyInstance.Value;
    }

    // روش 4: استفاده از AddSingleton در ASP.NET Core
    public sealed class Singleton4
    {
        private Singleton4() { }
    }
    // ثبت در Program.cs:
    // builder.Services.AddSingleton<Singleton4>();

    // روش 5: استفاده از AddHostSingleton در .NET  برای پردازش‌های طولانی‌مدت
    public sealed class Singleton5
    {
        private Singleton5() { }
    }
    // ثبت در Program.cs:
    // builder.Services.AddHostSingleton<Singleton5>();

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Testing Singleton Implementations:");

            Console.WriteLine(Singleton1.Instance);
            Console.WriteLine(Singleton2.Instance);
            Console.WriteLine(Singleton3.Instance);

            Console.WriteLine("For Singleton4 and Singleton5, use ASP.NET Core DI.");
        }
    }
}