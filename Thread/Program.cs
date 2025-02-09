namespace Thread_2
{
    public interface IThreadWorker
    {
        void Execute();
    }

    public class ThreadWorker : IThreadWorker
    {
        public void Execute()
        {
            Console.WriteLine("Thread is running...");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Step {i + 1} executed.");
                Thread.Sleep(1000);
            }
            Console.WriteLine("Thread is about to finish...");
        }
    }

    public class ThreadManager
    {
        private readonly IThreadWorker _worker;
        private readonly Thread _thread;

        public ThreadManager(IThreadWorker worker)
        {
            _worker = worker;
            _thread = new Thread(new ThreadStart(_worker.Execute));
        }

        public void Start()
        {
            Console.WriteLine($"Thread State: {_thread.ThreadState} (Unstarted)");
            _thread.Start();
            Thread.Sleep(500);
            Console.WriteLine($"Thread State: {_thread.ThreadState} (Running)");
        }

        public void Stop()
        {
            _thread.Join();
            Console.WriteLine($"Thread State: {_thread.ThreadState} (Stopped)");
        }
    }

    public class Program
    {
        static void Main()
        {
            IThreadWorker worker = new ThreadWorker();
            ThreadManager manager = new(worker);
            manager.Start();
            manager.Stop();
        }
    }
}