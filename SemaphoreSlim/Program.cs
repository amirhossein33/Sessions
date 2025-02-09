using System;
using System.Threading;
using System.Threading.Tasks;

namespace Semaphores
{
    public class Program
    {
     
        static readonly Semaphore semaphore = new(3, 3);

        public static void EnterParkingWithSemaphore(int carId)
        {
            Console.WriteLine($" Car {carId} is waiting to enter the parking...");
            semaphore.WaitOne(); 
            try
            {
                Console.WriteLine($" Car {carId} has entered the parking.");
                Thread.Sleep(3000); 
                Console.WriteLine($" Car {carId} is leaving the parking.");
            }
            finally
            {
                semaphore.Release(); 
            }
        }

       
        public static readonly SemaphoreSlim semaphoreSlim = new(3);

        public static async Task EnterParkingWithSemaphoreSlim(int carId)
        {
            Console.WriteLine($" Car {carId} is waiting to enter the parking...");
            await semaphoreSlim.WaitAsync(); 
            try
            {
                Console.WriteLine($" Car {carId} has entered the parking.");
                await Task.Delay(3000); 
                Console.WriteLine($" Car {carId} is leaving the parking.");
            }
            finally
            {
                semaphoreSlim.Release(); 
            }
        }

        static async Task Main()
        {
            Console.WriteLine(" Parking Simulation Started!\n");

            //   `Semaphore`
            /*
            Thread[] cars = new Thread[10];
            for (int i = 0; i < 10; i++)
            {
                cars[i] = new Thread(EnterParkingWithSemaphore);
                cars[i].Start(i + 1);
            }
            foreach (var car in cars)
            {
                car.Join();
            }
            */

            //   `SemaphoreSlim`
            Task[] carTasks = new Task[10];
            for (int i = 0; i < 10; i++)
            {
                carTasks[i] = EnterParkingWithSemaphoreSlim(i + 1);
            }
            await Task.WhenAll(carTasks);

            Console.WriteLine("\n All cars have finished parking!");
        }
    }
}