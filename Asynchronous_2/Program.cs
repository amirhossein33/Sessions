//   await Task1; await Task2; → اجرای تک‌تک (Sequential) → کندتر
// await Task.WhenAll(Task1, Task2); → اجرای همزمان(Parallel) → سریع‌تر

public interface IUserService
{
    Task<User?> GetUserByIdAsync(int userId);
}

public interface IOrderService
{
    Task<List<Order>> GetOrdersByUserIdAsync(int userId);
}

public interface IPaymentService
{
    Task<List<PaymentGateway>> GetPaymentMethodsByUserIdAsync(int userId);
}

public interface IDataLoader
{
    Task LoadUserDataAsync(int userId);
}

public class UserService : IUserService
{
    public async Task<User?> GetUserByIdAsync(int userId)
    {
        await Task.Delay(1000);
        var users = new List<User>()
        {
            new() { Id = 1, Name = "Ali", Email = "Test@Gmail.com" },
            new() { Id = 2, Name = "Reza", Email = "Gol@Gmail.com" }
        };

        return users.FirstOrDefault(u => u.Id == userId);
    }
}

public class OrderService : IOrderService
{
    public async Task<List<Order>> GetOrdersByUserIdAsync(int userId)
    {
        await Task.Delay(1000);
        return new List<Order>()
        {
            new() { Id = 1, Price = 2000 },
            new() { Id = 2, Price = 4000 }
        };
    }
}

public class PaymentService : IPaymentService
{
    public async Task<List<PaymentGateway>> GetPaymentMethodsByUserIdAsync(int userId)
    {
        await Task.Delay(1000);
        return new()
        {
            new() { GatewayId = "1", GatewayName = "Saderat" },
            new() { GatewayId = "2", GatewayName = "Mellal" }
        };
    }
}

public class ParallelUserLoader : IDataLoader
{
    private readonly IUserService _userService;
    private readonly IOrderService _orderService;
    private readonly IPaymentService _paymentService;

    public ParallelUserLoader(IUserService userService, IOrderService orderService, IPaymentService paymentService)
    {
        _userService = userService;
        _orderService = orderService;
        _paymentService = paymentService;
    }

    public async Task LoadUserDataAsync(int userId)
    {
        var userTask = _userService.GetUserByIdAsync(userId);
        var ordersTask = _orderService.GetOrdersByUserIdAsync(userId);
        var paymentMethodsTask = _paymentService.GetPaymentMethodsByUserIdAsync(userId);

        await Task.WhenAll(userTask, ordersTask, paymentMethodsTask);

        var user = await userTask;
        var orders = await ordersTask;
        var paymentMethods = await paymentMethodsTask;

        DisplayUserData(user, orders, paymentMethods);
    }

    private void DisplayUserData(User? user, List<Order> orders, List<PaymentGateway> paymentMethods)
    {
        if (user == null)
        {
            Console.WriteLine("User not found!");
            return;
        }

        Console.WriteLine($"User: {user.Name} (Email: {user.Email})");
        Console.WriteLine($"Orders: {orders.Count} orders found");
        Console.WriteLine($"Payment Methods: {paymentMethods.Count} methods found");
    }
}

public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
}


public class PaymentGateway
{
    public string? GatewayName { get; set; }
    public string GatewayId { get; set; }
}
public class Order
{
    public int Id { get; set; }
    public decimal Price { get; set; }
}

public class Program
{
    public static async Task Main()
    {
        IUserService userService = new UserService();
        IOrderService orderService = new OrderService();
        IPaymentService paymentService = new PaymentService();

        IDataLoader loader = new ParallelUserLoader(userService, orderService, paymentService);

        await loader.LoadUserDataAsync(1);

        Console.WriteLine("Data loading completed.");
    }
}
