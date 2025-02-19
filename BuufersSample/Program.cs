using System;
using System.Buffers;

namespace BuufersSample
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Enter the number of carbs :");
            string input = Console.ReadLine();

            char[] buffer = ArrayPool<char>.Shared.Rent(input.Length);

            try
            {
                input.CopyTo(0, buffer, 0, input.Length);
                Span<char> spanBuffer = new(buffer, 0, input.Length);
                ProcessCarbsSpan(spanBuffer);
            }
            finally
            {

                ArrayPool<char>.Shared.Return(buffer);
            }
        }

        public static void ProcessCarbsSpan(Span<char> span)
        {
            string[] carbs = span.ToString().Split(',');
            Console.WriteLine("Processing using Span<T> with Buffer:");
            foreach (var carb in carbs)
            {
                if (int.TryParse(carb.Trim(), out int value))
                {
                    Console.WriteLine($"Carb value: {value}");
                }
            }
        }
    }
}