namespace OrderManagementAPI
{
    //Singelton
    public class Logger
    {
        private static Logger _instance;
        private static readonly object _lock = new object();

        private Logger() { }

        public static Logger Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Logger();
                    }
                    return _instance;
                }
            }
        }

        public void Log(string message)
        {
            Console.WriteLine($"[LOG] {DateTime.Now}: {message}");
        }
    }
    public interface IOrder
    {
        void ProcessOrder();
    }

    public class PhysicalProductOrder : IOrder
    {
        public void ProcessOrder()
        {
            Logger.Instance.Log("سفارش محصول فیزیکی پردازش شد.");
        }
    }

    public class DigitalProductOrder : IOrder
    {
        public void ProcessOrder()
        {
            Logger.Instance.Log("سفارش محصول دیجیتال پردازش شد.");
        }
    }

    // Factory Method
    public abstract class OrderFactory
    {
        public abstract IOrder CreateOrder();
    }

    public class PhysicalOrderFactory : OrderFactory
    {
        public override IOrder CreateOrder() => new PhysicalProductOrder();
    }

    public class DigitalOrderFactory : OrderFactory
    {
        public override IOrder CreateOrder() => new DigitalProductOrder();
    }


public interface IPayment
{
    void ProcessPayment();
}

public class CreditCardPayment : IPayment
{
    public void ProcessPayment()
    {
        Logger.Instance.Log("پرداخت با کارت اعتباری انجام شد.");
    }
}

public class PayPalPayment : IPayment
{
    public void ProcessPayment()
    {
        Logger.Instance.Log("پرداخت با PayPal انجام شد.");
    }
}

// Abstract Factory
public interface IPaymentFactory
{
    IPayment CreatePayment();
}

public class CreditCardPaymentFactory : IPaymentFactory
{
    public IPayment CreatePayment() => new CreditCardPayment();
}

public class PayPalPaymentFactory : IPaymentFactory
{
    public IPayment CreatePayment() => new PayPalPayment();
}
    // Chain of Responsibility
    public abstract class OrderHandler
{
    protected OrderHandler? NextHandler;

    public void SetNext(OrderHandler nextHandler)
    {
        NextHandler = nextHandler;
    }

    public abstract void Handle(Order order);
}

public class StockValidationHandler : OrderHandler
{
    public override void Handle(Order order)
    {
        Logger.Instance.Log("Product ...");
        NextHandler?.Handle(order);
    }
}

public class PaymentValidationHandler : OrderHandler
{
    public override void Handle(Order order)
    {
        Logger.Instance.Log("Paid...");
        NextHandler?.Handle(order);
    }
}
}