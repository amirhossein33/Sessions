namespace Lock
{
    public class StadiumTicketBooking
    {
        private readonly object _lockObject = new();
        private int availableTickets = 5;

        public void BuyTicketsWithParallel()
        {
            List<string> customers =
            [
                "Reza", "Amir", "Farid", "Nasser", "Ali",
            "Saeed", "Hassan", "Farhad", "Nader", "Hossein"
            ];

            Parallel.ForEach(customers, customer =>
            {
                lock (_lockObject)
                {
                    if (availableTickets > 0)
                    {
                        Console.WriteLine($"={customer} is purchasing a ticket...");
                        Thread.Sleep(1000);
                        availableTickets--;
                        Console.WriteLine($" {customer} successfully bought a ticket! Remaining: {availableTickets}");
                    }
                    else
                    {
                        Console.WriteLine($" {customer} could not buy a ticket. SOLD OUT!");
                    }
                }
            });
        }
    }

    internal class Program
    {
        internal static void Main()
        {
            StadiumTicketBooking ticketSystem = new StadiumTicketBooking();
            Console.WriteLine(" Starting ticket booking system...\n");

            ticketSystem.BuyTicketsWithParallel();

            Console.WriteLine("\n Ticket booking process finished!");
        }
    }
}