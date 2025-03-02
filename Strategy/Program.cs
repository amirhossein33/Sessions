using System;

namespace StrategyPattern
{
    // 1️⃣ اینترفیس استراتژی پرداخت
    public interface IPaymentStrategy
    {
        void Pay(double amount);
    }

    // 2️⃣ استراتژی پرداخت با کارت اعتباری
    public class CreditCardPayment : IPaymentStrategy
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Paid {amount} USD using Credit Card.");
        }
    }

    // 3️⃣ استراتژی پرداخت با PayPal
    public class PayPalPayment : IPaymentStrategy
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Paid {amount} USD using PayPal.");
        }
    }

    // 4️⃣ استراتژی پرداخت با رمزارز (Crypto)
    public class CryptoPayment : IPaymentStrategy
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Paid {amount} USD using Cryptocurrency.");
        }
    }

    // 5️⃣ کلاس Context برای مدیریت استراتژی‌های پرداخت
    public class PaymentContext
    {
        private IPaymentStrategy _paymentStrategy;

        // تنظیم استراتژی پرداخت در زمان اجرا
        public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        // اجرای پرداخت
        public void PayNow(double amount)
        {
            if (_paymentStrategy != null)
            {
                _paymentStrategy.Pay(amount);
            }
            else
            {
                Console.WriteLine("Please select a payment method first.");
            }
        }
    }

    // 6️⃣ برنامه اصلی (Client)
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Strategy Pattern - Payment System ***\n");

            PaymentContext paymentContext = new PaymentContext();
            IPaymentStrategy paymentStrategy = null;

            Console.WriteLine("Select Payment Method:");
            Console.WriteLine("1. Credit Card");
            Console.WriteLine("2. PayPal");
            Console.WriteLine("3. Cryptocurrency");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    paymentStrategy = new CreditCardPayment();
                    break;
                case "2":
                    paymentStrategy = new PayPalPayment();
                    break;
                case "3":
                    paymentStrategy = new CryptoPayment();
                    break;
                default:
                    Console.WriteLine("Invalid choice! Defaulting to Credit Card.");
                    paymentStrategy = new CreditCardPayment();
                    break;
            }

            // تنظیم استراتژی پرداخت
            paymentContext.SetPaymentStrategy(paymentStrategy);

            // اجرای پرداخت با مقدار 100 دلار
            paymentContext.PayNow(100);

            Console.ReadKey();
        }
    }
}
