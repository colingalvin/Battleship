using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBattleship
{
    class Game
    {
        // member variables (HAS A)

        // constructor (SPAWN)
            // player 1
            // player 2

        // member methods (CAN DO)
            // welcome/display rules
            // new game
                // create players
                    // each player has 2 gameboards
                    // each player has list of 4 ships
            // play game
                // choose player to go first (default to player 1 at first)
                // Display game boards (opponent on top, own on bottom)
                    // opponent - only attempts made
                    // own - where ships are, where opponent has attacked
                // Player chooses where to attack
                    // user input coordinates - verification needed
                    // check opponent's own gameboard
                        // if only spaces, replace with o and display miss
                        // else if it contains anything other than spaces, replace with x_x and display hit
                    // check own gameboard, replace with X or O for hit or miss
                // Display updated game boards, repeat
    }
}
