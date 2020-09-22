using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBattleship
{
    class Destroyer : Ship // (IS A)
    {
        // member variables (HAS A)

        // constructor (SPAWN)
        public Destroyer()
        {
            name = "Destroyer";
            size = 2;
            hitsRemaining = size;
            shipID = " D ";
            hitShipID = "xDx";
        }

        // member methods (CAN DO)
    }
}
