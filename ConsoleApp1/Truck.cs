namespace Cargo
{
    public class Truck : Vehicle, ICargoTransportable
    {
        public double CargoCapacity { get; set; }
        public double WheelSize { get; set; }

        public override void Start()
        {
            Console.WriteLine("Truck started.");
        }

        public override void Stop()
        {
            Console.WriteLine("Truck stopped.");
        }

        public override double GetFuelEfficiency()
        {
            return 15.0;
        }

        public override double GetSpeed()
        {
            return 90;
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
}