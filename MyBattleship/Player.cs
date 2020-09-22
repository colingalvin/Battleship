using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBattleship
{
    class Player
    {
        // member variables (HAS A)
            // Gameboard (own)
            // Gameboard (opponent)
            // List of ships
            // name
            // score
            // isTurn

        // constructor (SPAWN)
            // initialize all variables
            // choose where ships go

        // member methods (CAN DO)
            // place ships on board
                // display current board
                // choose starting point on board (either top or left of ship)
                // choose whether to place ship across or down from that point
                    // verify if it will run into any other ship currently on the board
                // refresh board with ship in place, repeat for other 3 ships
            // attack
                // choose point on board to attack (user input)
    }
}
