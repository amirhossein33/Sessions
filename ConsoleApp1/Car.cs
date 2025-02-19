

using Cargo;

public class Car : Vehicle
{
    public int PassengerCapacity { get; set; }
    public string TransmissionType { get; set; }

    public override void Start()
    {
        Console.WriteLine("Car started.");
    }

    public override void Stop()
    {
        Console.WriteLine("Car stopped.");
    }

    public override double GetFuelEfficiency()
    {
        return 25.5; 
    }

    public override double GetSpeed()
    {
        return 120; // مثال: سرعت بر حسب کیلومتر بر ساعت
    }
}
