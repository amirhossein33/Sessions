using System.Collections.Concurrent;
namespace Concurrency
{
    
    public class Order
    {
        public int Id { get; }
        public string Name { get; }

        public Order(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public interface IOrderConsumer
    {
        void ProcessOrder(Order order);
    }

    public class OrderConsumer : IOrderConsumer
    {
        public void ProcessOrder(Order order)
        {
            Console.WriteLine($"Processing Order ID: {order.Id}, Product: {order.Name}");
            Thread.Sleep(1000);
        }
    }


    public class OrderProducer
    {
        private readonly BlockingCollection<Order> _orderQueue;

        public OrderProducer(BlockingCollection<Order> orderQueue)
        {
            _orderQueue = orderQueue;
        }

        public void ProduceOrders()
        {
            for (int i = 1; i <= 14; i++)
            {
                var order = new Order(i, $"Product-{i}");
                _orderQueue.Add(order);
                Console.WriteLine($"Produced Order ID: {order.Id}");
                Thread.Sleep(500);
            }
            _orderQueue.CompleteAdding();
        }
    }

    public class OrderProcessingSystem
    {
        private readonly BlockingCollection<Order> _orderQueue;
        private readonly IOrderConsumer _orderConsumer;

        public OrderProcessingSystem(IOrderConsumer orderConsumer)
        {
            _orderQueue = new BlockingCollection<Order>(10);
            _orderConsumer = orderConsumer;
        }

        public void StartProcessing()
        {
            var producer = new OrderProducer(_orderQueue);

            var producerTask = Task.Run(() => producer.ProduceOrders());
            var consumerTask = Task.Run(() =>
            {
                foreach (var order in _orderQueue.GetConsumingEnumerable())
                {
                    _orderConsumer.ProcessOrder(order);
                }
            });

            Task.WaitAll(producerTask, consumerTask);
        }
    }

    public class Program
    {
        public static void Main()
        {
            IOrderConsumer orderConsumer = new OrderConsumer();
            var system = new OrderProcessingSystem(orderConsumer);

            Console.WriteLine("Starting order processing system...");
            system.StartProcessing();
            Console.WriteLine("All orders processed.");
        }
    }
}