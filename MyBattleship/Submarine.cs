using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBattleship
{
    class Submarine : Ship // (IS A)
    {
        // member variables (HAS A)

        // constructor (SPAWN)
        public Submarine()
            :base()
        {
            name = "Submarine";
            size = 3;
            shipID = " S ";
            hitShipID = "xSx";
        }

        // member methods (CAN DO)
    }
}
