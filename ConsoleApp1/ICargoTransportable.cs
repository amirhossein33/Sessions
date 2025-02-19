using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo
{
    public interface ICargoTransportable
    {
        void LoadCargo();
        void UnloadCargo();
    }

}
