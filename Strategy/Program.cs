using System;

namespace StrategyPattern
{
    // 1️⃣ Payment strategy interface
    public interface IPaymentStrategy
    {
        void Pay(double amount);
    }

    // 2️⃣ Credit card payment strategy
    public class CreditCardPayment : IPaymentStrategy
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Paid {amount} USD using Credit Card.");
        }
    }

    // 3️⃣ PayPal payment strategy
    public class PayPalPayment : IPaymentStrategy
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Paid {amount} USD using PayPal.");
        }
    }

    // 4️⃣ Cryptocurrency payment strategy
    public class CryptoPayment : IPaymentStrategy
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Paid {amount} USD using Cryptocurrency.");
        }
    }

    // 5️⃣ Context class for managing payment strategies
    public class PaymentContext
    {
        private IPaymentStrategy _paymentStrategy;

        // Set payment strategy at runtime
        public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        // Execute payment
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

    // 6️⃣ Main program (Client)
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Strategy Pattern - Payment System ***\n");

            PaymentContext paymentContext = new ();
            Console.WriteLine("Select Payment Method:");
            Console.WriteLine("1. Credit Card");
            Console.WriteLine("2. PayPal");
            Console.WriteLine("3. Cryptocurrency");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            IPaymentStrategy paymentStrategy;
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

            // Set payment strategy
            paymentContext.SetPaymentStrategy(paymentStrategy);

            // Execute payment with an amount of 100 USD
            paymentContext.PayNow(100);

            Console.ReadKey();
        }
    }
}
