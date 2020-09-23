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
                    "\n\tor vertically (top to bottom) from your chosen starting point.\n\n");
                Console.Write($"Choose the starting position for your {ship.name} (takes up {ship.size} places): "); // choose starting point on board (either top or left of ship)
                string startingPosition = Console.ReadLine(); // Needs verification

                Console.Write("\nType 1 to place your ship horizontally, Type 2 to place your ship vertically: "); // choose whether to place ship across or down from that point
                string orientation = Console.ReadLine(); // Needs verification

                // verify if it will run into any other ship currently on the board
                int[] verifiedCoordinates = Verification.VerifyCoordinates(startingPosition);
                PlaceShipOnBoard(verifiedCoordinates, orientation, ship);
            }
            Console.Clear();
            Console.WriteLine($"{name}, here is where you chose to put your ships: \n");
            Game.DisplayGameBoard(ownGameboard); // Display final chosen orientation of board
            // Option to modify choices later on?
            Console.Write("Press enter to finish.");
            Console.ReadLine();
            Console.Clear();
        }

        public void PlaceShipOnBoard(int[] coordiantes, string orientation, Ship ship) // needs verification
        {
            // Verify here
            int rowIndex = coordiantes[0];
            int columnIndex = coordiantes[1];
            switch(ship.size)
            {
                case 2:
                    switch(orientation)
                    {
                        case "1": // horizontal
                            ownGameboard.board[rowIndex, columnIndex] = ship.shipID;
                            ownGameboard.board[rowIndex, (columnIndex + 1)] = ship.shipID;
                            break;
                        case "2": // vertical
                            ownGameboard.board[rowIndex, columnIndex] = ship.shipID;
                            ownGameboard.board[(rowIndex + 1), columnIndex] = ship.shipID;
                            break;
                    }
                    break;
                case 3:
                    switch (orientation)
                    {
                        case "1": // horizontal
                            ownGameboard.board[rowIndex, columnIndex] = ship.shipID;
                            ownGameboard.board[rowIndex, (columnIndex + 1)] = ship.shipID;
                            ownGameboard.board[rowIndex, (columnIndex + 2)] = ship.shipID;
                            break;
                        case "2": // vertical
                            ownGameboard.board[rowIndex, columnIndex] = ship.shipID;
                            ownGameboard.board[(rowIndex + 1), columnIndex] = ship.shipID;
                            ownGameboard.board[(rowIndex + 2), columnIndex] = ship.shipID;
                            break;
                    }
                    break;
                case 4:
                    switch (orientation)
                    {
                        case "1": // horizontal

                            ownGameboard.board[rowIndex, columnIndex] = ship.shipID;
                            ownGameboard.board[rowIndex, (columnIndex + 1)] = ship.shipID;
                            ownGameboard.board[rowIndex, (columnIndex + 2)] = ship.shipID;
                            ownGameboard.board[rowIndex, (columnIndex + 3)] = ship.shipID;
                            break;
                        case "2": // vertical
                            ownGameboard.board[rowIndex, columnIndex] = ship.shipID;
                            ownGameboard.board[(rowIndex + 1), columnIndex] = ship.shipID;
                            ownGameboard.board[(rowIndex + 2), columnIndex] = ship.shipID;
                            ownGameboard.board[(rowIndex + 3), columnIndex] = ship.shipID;
                            break;
                    }
                    break;
                case 5:
                    switch (orientation)
                    {
                        case "1": // horizontal
                            ownGameboard.board[rowIndex, columnIndex] = ship.shipID;
                            ownGameboard.board[rowIndex, (columnIndex + 1)] = ship.shipID;
                            ownGameboard.board[rowIndex, (columnIndex + 2)] = ship.shipID;
                            ownGameboard.board[rowIndex, (columnIndex + 3)] = ship.shipID;
                            ownGameboard.board[rowIndex, (columnIndex + 4)] = ship.shipID;
                            break;
                        case "2": // vertical
                            ownGameboard.board[rowIndex, columnIndex] = ship.shipID;
                            ownGameboard.board[(rowIndex + 1), columnIndex] = ship.shipID;
                            ownGameboard.board[(rowIndex + 2), columnIndex] = ship.shipID;
                            ownGameboard.board[(rowIndex + 3), columnIndex] = ship.shipID;
                            ownGameboard.board[(rowIndex + 4), columnIndex] = ship.shipID;
                            break;
                    }
                    break;
            }
        }

        public void Attack(int[] coordinates, Player player)
        {
            int arrayRowIndex = coordinates[0];
            int arrayColumnIndex = coordinates[1];
            if(player.ownGameboard.board[arrayRowIndex, arrayColumnIndex] == "   ") // If no ship present
            {
                player.ownGameboard.board[arrayRowIndex, arrayColumnIndex] = " o "; // Change to miss on opponent's board
                opponentGameboard.board[arrayRowIndex, arrayColumnIndex] = " o "; // Change to miss on own gameboard
                Console.WriteLine("Miss!");
            }
            else
            {
                switch(player.ownGameboard.board[arrayRowIndex, arrayColumnIndex])
                {
                    case " D ": // If destroyer is present
                        player.ownGameboard.board[arrayRowIndex, arrayColumnIndex] = player.ships[0].hitShipID; // Change to miss on opponent's board
                        player.ships[0].hitsRemaining--; // Decrease remaining hits ship can take
                        opponentGameboard.board[arrayRowIndex, arrayColumnIndex] = " x "; // Change to miss on own gameboard
                        break;
                    case " S ": // If submarine is present
                        player.ownGameboard.board[arrayRowIndex, arrayColumnIndex] = player.ships[1].hitShipID; // Change to miss on opponent's board
                        player.ships[1].hitsRemaining--; // Decrease remaining hits ship can take
                        opponentGameboard.board[arrayRowIndex, arrayColumnIndex] = " x "; // Change to miss on own gameboard
                        break;
                    case " B ": // If battleship is present
                        player.ownGameboard.board[arrayRowIndex, arrayColumnIndex] = player.ships[2].hitShipID; // Change to miss on opponent's board
                        player.ships[2].hitsRemaining--; // Decrease remaining hits ship can take
                        opponentGameboard.board[arrayRowIndex, arrayColumnIndex] = " x "; // Change to miss on own gameboard
                        break;
                    case " A ": // If aircraft carrier is present
                        player.ownGameboard.board[arrayRowIndex, arrayColumnIndex] = player.ships[3].hitShipID; // Change to miss on opponent's board
                        player.ships[3].hitsRemaining--; // Decrease remaining hits ship can take
                        opponentGameboard.board[arrayRowIndex, arrayColumnIndex] = " x "; // Change to miss on own gameboard
                        break;
                }
            Console.Write("Hit! ");
            YouSunkMyBattleship(player);
            }
            Console.WriteLine("Press enter for next turn!");
            Console.ReadLine();
        }

        public void YouSunkMyBattleship(Player player)
        {
            int i = 0;
            foreach (Ship ship in player.ships)
            {
                if(ship.hitsRemaining == 0)
                {
                    Console.WriteLine($"You sunk {player.name}'s {player.ships[i].name}!");
                    player.ships[i].hitsRemaining = -1;
                    score++;
                }
                i++;
            }
        }
    }
}
