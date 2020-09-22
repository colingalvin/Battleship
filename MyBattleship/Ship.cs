using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBattleship
{
    abstract class Ship
    {
        // member variables (HAS A)

        public string name;
        public int size;
        public int hitsTaken;
        // position on board ?

        // constructor (SPAWN)
        public Ship()
        {
            hitsTaken = 0;
        }

        // member methods (CAN DO)

    }
}
