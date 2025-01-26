namespace SOLID.Sample1
{
    //False
    public abstract class Vehicle
    {
        public abstract void StartEngine();
        public abstract void StopEngine();
    }
    public class Car : Vehicle
    {
        public override void StartEngine()
        {
            Console.WriteLine("Starting the car engine.");
            // Code to start the car engine
        }
        public override void StopEngine()
        {
            Console.WriteLine("Stopping the car engine.");
            // Code to stop the car engine
        }
    }
    public class ElectricCar : Vehicle
    {
        public override void StartEngine()
        {
            throw new InvalidOperationException("Electric cars do not have engines.");
        }
        public override void StopEngine()
        {
            throw new InvalidOperationException("Electric cars do not have engines.");
        }
    }
}




//True
public abstract class Vehicle
{
    public abstract void TurnonLight();
    // Common vehicle behavior and properties.
}
public interface IEnginePowered
{
    void StartEngine();
    void StopEngine();
}
public class Car : Vehicle, IEnginePowered
{
    public override void TurnonLight()
    {
        Console.WriteLine("Turn on Lights.");
    }
    public void StartEngine()
    {
        Console.WriteLine("Starting the car engine.");
        // Code to start the car engine.
    }
    public void StopEngine()
    {
        Console.WriteLine("Stopping the car engine.");
        // Code to stop the car engine.
    }
}
public class ElectricCar : Vehicle
{
    public override void TurnonLight()
    {
        Console.WriteLine("Turn on Lights.");
    }
    // Specific behavior for electric cars.
}