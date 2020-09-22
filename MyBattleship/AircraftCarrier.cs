using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBattleship
{
    class AircraftCarrier : Ship // (IS A)
    {
        // member variables (HAS A)

        // constructor (SPAWN)
        public AircraftCarrier()
            :base()
        {
            name = "Aircraft Carrier";
            size = 5;
        }

        // member methods (CAN DO)
    }
}
