namespace Cargo
{
    public interface IVehicle
    {
        void Start();
        void Stop();
        double GetFuelEfficiency();
        double GetSpeed(); 
    }
}
