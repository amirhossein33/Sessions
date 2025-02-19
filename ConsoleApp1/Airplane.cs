

using Cargo;

public class Airplane : Vehicle, IFlyable, ICargoTransportable
{
    public double FlightAltitude { get; set; }

    public override void Start()
    {
        Console.WriteLine("Airplane started.");
    }

    public override void Stop()
    {
        Console.WriteLine("Airplane stopped.");
    }

    public override double GetFuelEfficiency()
    {
        return 5.0; 
    }

    public override double GetSpeed()
    {
        return 900; 
    }

    public void Fly()
    {
        Console.WriteLine("Airplane is flying.");
    }

    public void LoadCargo()
    {
        Console.WriteLine("Cargo loaded.");
    }

    public void UnloadCargo()
    {
        Console.WriteLine("Cargo unloaded.");
    }
}
