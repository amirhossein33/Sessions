//class Program
//{
//    static void Main()
//    {

//        int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };


//        Span<int> span = new (arr, 2, 4); 


//        span[0] = 100; // تغییر مقدار اولین عنصر در span (درواقع arr[2])


//        Console.WriteLine("Updated array:");
//        foreach (var item in arr)
//        {
//            Console.Write(item + " ");  // 1 2 100 4 5 6 7 8 9
//        }
//    }
//}


//class Program
//{
//    static void Main()
//    {

//        int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

//        // ایجاد یک Memory از بخشی از آرایه
//        Memory<int> memory = new (arr, 2, 4); // از ایندکس 2 شروع کرده و 4 عضو بعدی را می‌گیرد

//        // تبدیل Memory به Span برای دسترسی سریعتر
//        Span<int> span = memory.Span;


//        span[0] = 100;  // تغییر مقدار اولین عنصر در memory (درواقع arr[2])

//        // چاپ آرایه اصلی
//        Console.WriteLine("Updated array:");
//        foreach (var item in arr)
//        {
//            Console.Write(item + " ");  // 1 2 100 4 5 6 7 8 9
//        }
//    }
//}

struct Order
{
    public int OrderId;
    public string CustomerName;
    public double Amount;

    public Order(int orderId, string customerName, double amount)
    {
        OrderId = orderId;
        CustomerName = customerName;
        Amount = amount;
    }
}

class OrderProcessor
{
    // متد پردازش سفارش‌ها با استفاده از Span<T>
    public static void ProcessOrders(Span<Order> orders)
    {
        Console.WriteLine("Processing Orders...");
        foreach (ref Order order in orders)
        {
            Console.WriteLine($"Order ID: {order.OrderId}, Customer: {order.CustomerName}, Amount: {order.Amount}");
        }
    }

    // متد ذخیره‌سازی سفارش‌ها با استفاده از Memory<T>
    public static void StoreOrders(Memory<Order> memoryOrders)
    {
        Span<Order> ordersSpan = memoryOrders.Span; // تبدیل Memory<T> به Span<T> برای پردازش سریع‌تر
        Console.WriteLine("Storing Orders...");
        foreach (var order in ordersSpan)
        {
            Console.WriteLine($"Stored Order: {order.OrderId} - {order.CustomerName} - {order.Amount}");
        }
    }
}

class Program
{
    static void Main()
    {
        
        Order[] orderArray = new Order[]
        {
            new(1, "Ali", 250.50),
            new(2, "Babak", 450.75),
            new(3, "Carl", 320.00)
        };

        // استفاده از Span<T> برای پردازش سریع سفارش‌ها
        Span<Order> orderSpan = new(orderArray);
        OrderProcessor.ProcessOrders(orderSpan);

        Console.WriteLine();

        // استفاده از Memory<T> برای ذخیره‌سازی سفارش‌ها
        Memory<Order> orderMemory = new(orderArray);
        OrderProcessor.StoreOrders(orderMemory);
    }
}
