using System;

public struct Point
{
    public readonly double Latitude;
    public readonly double Longitude;

    public Point(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }
}

public class PointManager
{
    public void DisplayPointInfo(ref readonly Point point)
    {
        Console.WriteLine($"Latitude: {point.Latitude}, Longitude: {point.Longitude}");
    }

    public void UpdatePointInfo(ref Point point, double newLatitude, double newLongitude)
    {
        point = new Point(newLatitude, newLongitude);
    }
}

class Program
{
    static void Main(string[] args)
    {
       
        var point1 = new Point (40.7128, -74.0060);  

       
        var manager = new PointManager();

        manager.DisplayPointInfo(ref point1);  
      
        manager.UpdatePointInfo(ref point1, 34.0522, -118.2437); 

        manager.DisplayPointInfo(ref point1);  
    }
}
