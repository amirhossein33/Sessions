//best Practice
public class Program
{
    public static void Main()
    {
        using FileStream fs = new("test.txt", FileMode.Create);
        using StreamWriter writer = new(fs);
        writer.WriteLine("Hello World!");
    }
}

//public class Program
//{
//    public static void Main()
//    {
//        using FileStream fs = new("test.txt", FileMode.Create);
//        StreamWriter writer = new(fs);
//        writer.WriteLine("Hello World!");
//        writer.Dispose();
//    }
//}