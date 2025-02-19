namespace Cargo
{
    public class Program
    {
        public static void Main(string[] args)
        {
           
            var car = VehicleFactory.CreateVehicle("car");
            var truck = VehicleFactory.CreateVehicle("truck");
            var airplane = VehicleFactory.CreateVehicle("airplane");

            var fleet = new Fleet<IVehicle>();
            fleet.AddVehicle(car);
            fleet.AddVehicle(truck);
            fleet.AddVehicle(airplane);

          
            fleet.StartAllVehicles();

          
            Console.WriteLine($"Total Fuel Efficiency: {fleet.CalculateTotalFuelEfficiency()}");

            
            if (airplane is IFlyable flyableAirplane)
            {
                flyableAirplane.Fly();
            }

          
            if (truck is ICargoTransportable cargoTruck)
            {
                cargoTruck.LoadCargo();
                cargoTruck.UnloadCargo();
            }
        }
    }
}
