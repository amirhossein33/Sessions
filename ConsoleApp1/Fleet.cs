namespace Cargo
{
    public class Fleet<T> where T : IVehicle
    {
        private readonly List<T> vehicles = [];

        public void AddVehicle(T vehicle)
        {
            vehicles.Add(vehicle);
        }

        public void StartAllVehicles()
        {
            foreach (var vehicle in vehicles)
            {
                vehicle.Start();
            }
        }

        public double CalculateTotalFuelEfficiency()
        {
            return vehicles.Sum(v => v.GetFuelEfficiency());
        }
    }
}