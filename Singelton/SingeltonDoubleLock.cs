using SingletonPatternEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singelton.DoubleLock
{
    // Double Checked Locking


    public sealed class Singleton
    {
        // ما از volatile استفاده می‌کنیم تا اطمینان حاصل کنیم که
        // تخصیص به متغیر instance قبل از دسترسی به آن کامل شده است.
        private static volatile Singleton instance;
        private static object lockObject = new();

        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        instance ??= new Singleton();
                    }
                }
                return instance;
            }
        }
    }

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
