using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo
{
    public abstract class Vehicle : IVehicle
    {
        public string ChassisNumber { get; set; }
        public string FuelType { get; set; }
        public int WheelCount { get; set; }

        public abstract void Start();
        public abstract void Stop();
        public abstract double GetFuelEfficiency();
        public abstract double GetSpeed();
    }
}
