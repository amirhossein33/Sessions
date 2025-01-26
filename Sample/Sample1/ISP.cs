namespace SOLID.Sample1
{
    //False
    public interface IPayment
    {
        void ProcessPayment(decimal amount);
        void AddFunds(decimal amount);   // این متد برای پرداخت از طریق کارت اعتباری ضروری نیست
        void Refund(decimal amount);     // این متد برای برخی از روش‌های پرداخت ضروری نیست
    }

    public class CreditCardPayment : IPayment
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing payment of {amount} using Credit Card.");
        }

        public void AddFunds(decimal amount)
        {
            throw new InvalidOperationException("Credit Card cannot be used to add funds.");
        }

        public void Refund(decimal amount)
        {
            Console.WriteLine($"Refunding {amount} to Credit Card.");
        }
    }

    public class WalletPayment : IPayment
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing payment of {amount} using Wallet.");
        }

        public void AddFunds(decimal amount)
        {
            Console.WriteLine($"Adding {amount} to Wallet.");
        }

        public void Refund(decimal amount)
        {
            Console.WriteLine($"Refunding {amount} to Wallet.");
        }
    }

}

//True
public interface IPaymentProcessor
{
    void ProcessPayment(decimal amount);
}

public interface IAddFunds
{
    void AddFunds(decimal amount);
}

public interface IRefund
{
    void Refund(decimal amount);
}

public class CreditCardPayment : IPaymentProcessor, IRefund
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing payment of {amount} using Credit Card.");
    }

    public void Refund(decimal amount)
    {
        Console.WriteLine($"Refunding {amount} to Credit Card.");
    }
}

public class WalletPayment : IPaymentProcessor, IAddFunds, IRefund
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing payment of {amount} using Wallet.");
    }

    public void AddFunds(decimal amount)
    {
        Console.WriteLine($"Adding {amount} to Wallet.");
    }

    public void Refund(decimal amount)
    {
        Console.WriteLine($"Refunding {amount} to Wallet.");
    }
}