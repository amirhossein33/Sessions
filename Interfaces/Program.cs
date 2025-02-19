using System;

public interface IPaymentMethod
{
    void Pay(decimal amount);
}


public interface IRefundable
{
    void Refund(decimal amount);
}


public interface ITransaction
{
    void ProcessTransaction(decimal amount);
}

public class CreditCard : IPaymentMethod, IRefundable, ITransaction
{
    private readonly string cardNumber;

    public CreditCard(string cardNumber)
    {
        this.cardNumber = cardNumber;
    }

  
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paying {amount:C} using Credit Card {cardNumber}");
    }

 
    public void Refund(decimal amount)
    {
        Console.WriteLine($"Refunding {amount:C} to Credit Card {cardNumber}");
    }

   
    public void ProcessTransaction(decimal amount)
    {
        Console.WriteLine($"Processing transaction of {amount:C} with Credit Card {cardNumber}");
    }
}


public class HamrahBank : IPaymentMethod, IRefundable, ITransaction
{
    private readonly string email;

    public HamrahBank(string email)
    {
        this.email = email;
    }

    // پیاده‌سازی متد Pay از رابط IPaymentMethod
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paying {amount:C} using HamrahBank account {email}");
    }

    // پیاده‌سازی متد Refund از رابط IRefundable
    public void Refund(decimal amount)
    {
        Console.WriteLine($"Refunding {amount:C} to HamrahBank account {email}");
    }

    // پیاده‌سازی متد ProcessTransaction از رابط ITransaction
    public void ProcessTransaction(decimal amount)
    {
        Console.WriteLine($"Processing transaction of {amount:C} through HamrahBank account {email}");
    }
}


public class CashPayment : IPaymentMethod
{

    public void Pay(decimal amount)
    {
        Console.WriteLine($"Paying {amount:C} in cash.");
    }
}


public class Program
{
    public static void Main()
    {
       
        IPaymentMethod creditCardPayment = new CreditCard("1234-5678-9876-5432");
        creditCardPayment.Pay(150.50m);
        IRefundable creditCardRefund = (IRefundable)creditCardPayment;
        creditCardRefund.Refund(50.00m);
        ITransaction creditCardTransaction = (ITransaction)creditCardPayment;
        creditCardTransaction.ProcessTransaction(150.50m);

      
        IPaymentMethod hamrahPayment = new HamrahBank("user@gmail.com");
        hamrahPayment.Pay(200.00m);
        IRefundable hamrahRefund = (IRefundable)hamrahPayment;
        hamrahRefund.Refund(100.00m);
        ITransaction hamrahTransaction = (ITransaction)hamrahPayment;
        hamrahTransaction.ProcessTransaction(200.00m);

       
        IPaymentMethod cashPayment = new CashPayment();
        cashPayment.Pay(50.00m);
    }
}
