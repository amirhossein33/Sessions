public class MyResource : IDisposable
{
    private bool disposed = false;

    public void UseResource()
    {
        if (disposed)
            throw new ObjectDisposedException("MyResource");
        Console.WriteLine("Resource is being used.");
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this); // جلوگیری از  Finalize
    }

    public void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                
                Console.WriteLine("Releasing managed resources...");
            }
           
            Console.WriteLine("Releasing unmanaged resources...");
            disposed = true;
        }
    }

    ~MyResource()
    {
        Dispose(false); // Finalizer فقط منابع غیرمدیریتی را آزاد می‌کند.
    }
}

public class Program
{
    public static void Main()
    {
        using MyResource resource = new ();
        resource.UseResource();
        // Dispose به‌صورت خودکار اجرا می‌شود
    }
}