﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBattleship
{
    class Battleship : Ship // (IS A)
    {
        // member variables (HAS A)

        // constructor (SPAWN)
        public Battleship()
        {
            name = "Battleship";
            size = 4;
            hitsRemaining = size;
            shipID = " B ";
            hitShipID = "xBx";
        }

        // member methods (CAN DO)
    }
}
