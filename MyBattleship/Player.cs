using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
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
            ChooseShipStartingPlacement();
        }
            // initialize all variables
            // choose where ships go

        // member methods (CAN DO)

        public void ChooseShipStartingPlacement()
        {
            foreach (Ship ship in ships)
            {
                Console.Clear();
                Console.WriteLine($"{name}, here is your current game board:\n");
                Game.DisplayGameBoard(ownGameboard); // display current board
                Console.Write("Ships will be placed either horizontally (left to right)" +
                    "\n\tor vertically (top to bottom) from your chosen starting point." +
                    $"\n\n{name}, choose the starting position for your {ship.name} (takes up {ship.size} places): "); // choose starting point on board (either top or left of ship)
                string startingPosition = Console.ReadLine(); // Needs verification
                Console.WriteLine("Type 1 to place your ship horizontally, Type 2 to place your ship vertically"); // choose whether to place ship across or down from that point
                string orientation = Console.ReadLine(); // Needs verification
                // verify if it will run into any other ship currently on the board
                PlaceShipOnBoard(startingPosition, orientation, ship);
            }
            Console.WriteLine("Here is where you chose to put your ships: \n");
            Game.DisplayGameBoard(ownGameboard); // Display final chosen orientation of board
            Console.WriteLine("\nPress enter to continue.");
            Console.ReadLine();
            Console.Clear();
            // Option to modify choices later on
        }

        public void PlaceShipOnBoard(string coordiantes, string orientation, Ship ship) // needs verification
        {
            int arrayColumnIndex = ParseColumn(coordiantes);
            int arrayRowIndex = ParseRow(coordiantes);
            switch(ship.size)
            {
                case 2:
                    switch(orientation)
                    {
                        case "1": // horizontal
                            ownGameboard.board[arrayColumnIndex, arrayRowIndex] = ship.shipID;
                            ownGameboard.board[(arrayColumnIndex), (arrayRowIndex + 1)] = ship.shipID;
                            break;
                        case "2": // vertical
                            ownGameboard.board[arrayColumnIndex, arrayRowIndex] = ship.shipID;
                            ownGameboard.board[(arrayColumnIndex + 1), arrayRowIndex] = ship.shipID;
                            break;
                    }
                    break;
                case 3:
                    switch (orientation)
                    {
                        case "1": // horizontal
                            ownGameboard.board[arrayColumnIndex, arrayRowIndex] = ship.shipID;
                            ownGameboard.board[(arrayColumnIndex), (arrayRowIndex + 1)] = ship.shipID;
                            ownGameboard.board[(arrayColumnIndex), (arrayRowIndex + 2)] = ship.shipID;
                            break;
                        case "2": // vertical
                            ownGameboard.board[arrayColumnIndex, arrayRowIndex] = ship.shipID;
                            ownGameboard.board[(arrayColumnIndex + 1), arrayRowIndex] = ship.shipID;
                            ownGameboard.board[(arrayColumnIndex + 2), arrayRowIndex] = ship.shipID;
                            break;
                    }
                    break;
                case 4:
                    switch (orientation)
                    {
                        case "1": // horizontal

                            ownGameboard.board[arrayColumnIndex, arrayRowIndex] = ship.shipID;
                            ownGameboard.board[(arrayColumnIndex), (arrayRowIndex + 1)] = ship.shipID;
                            ownGameboard.board[(arrayColumnIndex), (arrayRowIndex + 2)] = ship.shipID;
                            ownGameboard.board[(arrayColumnIndex), (arrayRowIndex + 3)] = ship.shipID;
                            break;
                        case "2": // vertical
                            ownGameboard.board[arrayColumnIndex, arrayRowIndex] = ship.shipID;
                            ownGameboard.board[(arrayColumnIndex + 1), arrayRowIndex] = ship.shipID;
                            ownGameboard.board[(arrayColumnIndex + 2), arrayRowIndex] = ship.shipID;
                            ownGameboard.board[(arrayColumnIndex + 3), arrayRowIndex] = ship.shipID;
                            break;
                    }
                    break;
                case 5:
                    switch (orientation)
                    {
                        case "1": // horizontal
                            ownGameboard.board[arrayColumnIndex, arrayRowIndex] = ship.shipID;
                            ownGameboard.board[(arrayColumnIndex), (arrayRowIndex + 1)] = ship.shipID;
                            ownGameboard.board[(arrayColumnIndex), (arrayRowIndex + 2)] = ship.shipID;
                            ownGameboard.board[(arrayColumnIndex), (arrayRowIndex + 3)] = ship.shipID;
                            ownGameboard.board[(arrayColumnIndex), (arrayRowIndex + 4)] = ship.shipID;
                            break;
                        case "2": // vertical
                            ownGameboard.board[arrayColumnIndex, arrayRowIndex] = ship.shipID;
                            ownGameboard.board[(arrayColumnIndex + 1), arrayRowIndex] = ship.shipID;
                            ownGameboard.board[(arrayColumnIndex + 2), arrayRowIndex] = ship.shipID;
                            ownGameboard.board[(arrayColumnIndex + 3), arrayRowIndex] = ship.shipID;
                            ownGameboard.board[(arrayColumnIndex + 4), arrayRowIndex] = ship.shipID;
                            break;
                    }
                    break;
            }

        }

        public void Attack(string coordiantes, Player player)
        {
            int arrayColumnIndex = ParseColumn(coordiantes);
            int arrayRowIndex = ParseRow(coordiantes);
            if(player.ownGameboard.board[arrayColumnIndex, arrayRowIndex] == "   ") // If no ship present
            {
                player.ownGameboard.board[arrayColumnIndex, arrayRowIndex] = " o "; // Change to miss on opponent's board
                opponentGameboard.board[arrayColumnIndex, arrayRowIndex] = " o "; // Change to miss on own gameboard
                Console.WriteLine($"Miss! {player.name}, your turn.");
            }
            else
            {
                switch(player.ownGameboard.board[arrayColumnIndex, arrayRowIndex])
                {
                    case " D ": // If destroyer is present
                        player.ownGameboard.board[arrayColumnIndex, arrayRowIndex] = player.ships[0].hitShipID; // Change to miss on opponent's board
                        player.ships[0].hitsRemaining--; // Decrease remaining hits ship can take
                        opponentGameboard.board[arrayColumnIndex, arrayRowIndex] = " x "; // Change to miss on own gameboard
                        Console.WriteLine($"Hit! {player.name}, your turn.");
                        break;
                    case " S ": // If submarine is present
                        player.ownGameboard.board[arrayColumnIndex, arrayRowIndex] = player.ships[1].hitShipID; // Change to miss on opponent's board
                        player.ships[1].hitsRemaining--; // Decrease remaining hits ship can take
                        opponentGameboard.board[arrayColumnIndex, arrayRowIndex] = " x "; // Change to miss on own gameboard
                        Console.WriteLine($"Hit! {player.name}, your turn.");
                        break;
                    case " B ": // If battleship is present
                        player.ownGameboard.board[arrayColumnIndex, arrayRowIndex] = player.ships[2].hitShipID; // Change to miss on opponent's board
                        player.ships[2].hitsRemaining--; // Decrease remaining hits ship can take
                        opponentGameboard.board[arrayColumnIndex, arrayRowIndex] = " x "; // Change to miss on own gameboard
                        Console.WriteLine($"Hit! {player.name}, your turn.");
                        break;
                    case " A ": // If aircraft carrier is present
                        player.ownGameboard.board[arrayColumnIndex, arrayRowIndex] = player.ships[3].hitShipID; // Change to miss on opponent's board
                        player.ships[3].hitsRemaining--; // Decrease remaining hits ship can take
                        opponentGameboard.board[arrayColumnIndex, arrayRowIndex] = " x "; // Change to miss on own gameboard
                        Console.WriteLine($"Hit! {player.name}, your turn.");
                        break;
                }
            }
            Console.WriteLine("Press enter for next turn!");
            Console.ReadLine();
        }

        public int ParseRow(string coordinates)
        {
            int arrayRowIndex = -1;
            char column = coordinates[0];
            switch(column)
            {
                case 'a':
                    arrayRowIndex = 1;
                    break;
                case 'b':
                    arrayRowIndex = 2;
                    break;
                case 'c':
                    arrayRowIndex = 3;
                    break;
                case 'd':
                    arrayRowIndex = 4;
                    break;
                case 'e':
                    arrayRowIndex = 5;
                    break;
                case 'f':
                    arrayRowIndex = 6;
                    break;
                case 'g':
                    arrayRowIndex = 7;
                    break;
                case 'h':
                    arrayRowIndex = 8;
                    break;
                case 'i':
                    arrayRowIndex = 9;
                    break;
                case 'j':
                    arrayRowIndex = 10;
                    break;
            }
            return arrayRowIndex;
        }

        public int ParseColumn(string coordiantes)
        {
            int arrayColumnIndex = int.Parse(coordiantes.Substring(1));
            return arrayColumnIndex;
        }
                
                
            // attack
                // choose point on board to attack (user input)
    }
}
