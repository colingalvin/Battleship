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

        public GameBoard ownGameboard;
        public GameBoard opponentGameboard;
        public List<Ship> ships;
        public string name;
        public int score;
        public bool isTurn;

        // constructor (SPAWN)
        public Player(string name)
        {
            this.name = name;
            ownGameboard = new GameBoard();
            opponentGameboard = new GameBoard();
            ships = new List<Ship>();
            Destroyer destroyer = new Destroyer();
            Submarine submarine = new Submarine();
            Battleship battleship = new Battleship();
            AircraftCarrier aircraftCarrier = new AircraftCarrier();
            ships.Add(destroyer);
            ships.Add(submarine);
            ships.Add(battleship);
            ships.Add(aircraftCarrier);
            score = 0;
            isTurn = false;
        }
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
