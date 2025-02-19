using System;

namespace Slice_CopyTo_ReadOnlyMemory
{
    public class Program
    {
        public static void Main()
        {
            // ورودی متنی برای پردازش
            string inputData = "Hello, this is a long string that needs slicing.";
            ReadOnlyMemory<char> memory = inputData.AsMemory();

            // تقسیم متن به دو بخش با استفاده از Slice
            ReadOnlyMemory<char> firstPart = memory.Slice(0, 10);
            ReadOnlyMemory<char> secondPart = memory.Slice(10);

            Console.WriteLine($"First part: {firstPart.ToString()}");
            Console.WriteLine($"Second part: {secondPart.ToString()}");

            // کپی کردن داده‌ها به یک آرایه جدید با CopyTo
            char[] destination = new char[firstPart.Length];
            firstPart.CopyTo(destination);

            Console.WriteLine($"Copied part: {new string(destination)}");
        }
    }
}