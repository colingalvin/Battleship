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
            // PlaceShipOnBoard();
        }
            // initialize all variables
            // choose where ships go

        // member methods (CAN DO)

        public void PlaceShipOnBoard()
        {
            foreach (Ship ship in ships)
            {
                Game.DisplayGameBoard(ownGameboard); // display current board
                Console.Write($"Choose the top/left starting position for your {ship.name}: "); // choose starting point on board (either top or left of ship)
                string startingPosition = Console.ReadLine(); // Needs verification
                Console.WriteLine("Type 1 to place your ship horizontally, Type 2 to place your ship vertically"); // choose whether to place ship across or down from that point
                string orientation = Console.ReadLine(); // Needs verification
                // verify if it will run into any other ship currently on the board
            }
            Console.WriteLine("Here is where you chose to put your ships: \n");
            Game.DisplayGameBoard(ownGameboard); // Display final chosen orientation of board
            Console.WriteLine("\nPress enter to continue.");
            // Option to modify choices later on
        }

        public void ParseCoordinates()
        {
            // take in user input coordiantes
            // translate to array coordinates
            // modify array correctly
        }
                
                
            // attack
                // choose point on board to attack (user input)
    }
}
