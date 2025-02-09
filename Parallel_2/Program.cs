/// <summary>
/// ز Parallel.ForEach برای پردازش رزرو بلیط به‌صورت موازی استفاده شده است.
// از lock برای جلوگیری از Race Condition و همگام‌سازی Threadها استفاده شده است.
//✅ Parallel.Invoke() عملیات ارسال ایمیل، به‌روزرسانی امتیازات و نمایش پیام را به‌طور همزمان اجرا می‌کند.
//✅ از AsParallel() برای پردازش موازی مشتریان بدون بلیط استفاده شده است.
/// </summary>
interface ITicketBookingService
{
    void ProcessBookings(List<Customer> customers);
}

interface INotificationService
{
    void SendConfirmationEmails(List<Customer> customers);
}

interface ILoyaltyService
{
    void UpdateLoyaltyPoints(List<Customer> customers);
}

public class TicketBookingService : ITicketBookingService
{
    private readonly object _lockObject = new ();
    private int _availableTickets = 5;

    public void ProcessBookings(List<Customer> customers)
    {
        Parallel.ForEach(customers, customer =>
        {
            lock (_lockObject)
            {
                if (_availableTickets > 0)
                {
                    Console.WriteLine($" {customer.Name} is booking a ticket...");
                    Thread.Sleep(1000);
                    _availableTickets--;
                    customer.HasTicket = true;
                    Console.WriteLine($" {customer.Name} successfully booked a ticket! Remaining: {_availableTickets}");
                }
                else
                {
                    Console.WriteLine($" {customer.Name} could not book a ticket. SOLD OUT!");
                }
            }
        });
    }
}

public class EmailNotificationService : INotificationService
{
    public void SendConfirmationEmails(List<Customer> customers)
    {
        Console.WriteLine($" Sending booking confirmation emails... Thread ID: {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(1000);
    }
}

public class LoyaltyService : ILoyaltyService
{
    public void UpdateLoyaltyPoints(List<Customer> customers)
    {
        Console.WriteLine($" Updating loyalty points for ticket holders... Thread ID: {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(1000);
    }
}

class TicketManager
{
    private readonly ITicketBookingService _bookingService;
    private readonly INotificationService _notificationService;
    private readonly ILoyaltyService _loyaltyService;

    public TicketManager(ITicketBookingService bookingService, INotificationService notificationService, ILoyaltyService loyaltyService)
    {
        _bookingService = bookingService;
        _notificationService = notificationService;
        _loyaltyService = loyaltyService;
    }

    public void ProcessBookings(List<Customer> customers)
    {
        _bookingService.ProcessBookings(customers);
        Parallel.Invoke(
            () => _notificationService.SendConfirmationEmails(customers),
            () => _loyaltyService.UpdateLoyaltyPoints(customers),
            () => Console.WriteLine($" Notification: Processing ticket bookings... Thread ID: {Thread.CurrentThread.ManagedThreadId}")
        );
    }

    public List<Customer> GetCustomersWithoutTickets(List<Customer> customers)
    {
        return customers.AsParallel().Where(c => !c.HasTicket).ToList();
    }
}

public class Customer
{
    public string Name { get; set; }
    public bool HasTicket { get; set; } = false;
}

public class Program
{
    static void Main()
    {
        ITicketBookingService bookingService = new TicketBookingService();
        INotificationService notificationService = new EmailNotificationService();
        ILoyaltyService loyaltyService = new LoyaltyService();

        TicketManager ticketManager = new TicketManager(bookingService, notificationService, loyaltyService);

        List<Customer> customers =
        [
            new() { Name = "Alice" }, new Customer { Name = "Bob" }, new Customer { Name = "Charlie" },
            new() { Name = "David" }, new Customer { Name = "Emma" }, new Customer { Name = "Frank" },
            new Customer { Name = "Grace" }, new Customer { Name = "Henry" }, new Customer { Name = "Ivy" },
            new Customer { Name = "Jack" }
        ];

        Console.WriteLine(" Starting ticket booking process...\n");

        
        ticketManager.ProcessBookings(customers);

       
        var customersWithoutTickets = ticketManager.GetCustomersWithoutTickets(customers);
        Console.WriteLine($"\n{customersWithoutTickets.Count} customers could not book a ticket.");

        Console.WriteLine("\n Ticket booking process completed!");
    }
}
