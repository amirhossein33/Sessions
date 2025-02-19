

using Cargo;

public class VehicleFactory
{
    public static IVehicle CreateVehicle(string type)
    {
        return type.ToLower() switch
        {
            "car" => new Car(),
            "truck" => new Truck(),
            "airplane" => new Airplane(),
            _ => throw new ArgumentException("Invalid vehicle type"),
        };
    }
}
