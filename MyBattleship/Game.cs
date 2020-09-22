using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyBattleship
{
    class Game
    {
        // member variables (HAS A)

        public Player playerOne;
        public Player playerTwo;

        // constructor (SPAWN)
        public Game()
        {
            Console.Write("Enter name for Player One: ");
            string playerOneName = Console.ReadLine();
            playerOne = new Player(playerOneName);

            Console.Write("Enter name for Player Two: ");
            string playerTwoName = Console.ReadLine();
            playerTwo = new Player(playerTwoName);
        }

        // member methods (CAN DO)
            // welcome/display rules

        public static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to Battleship, the console version of the classic game!\n");
            // Rules
            Console.WriteLine("During each turn, two boards will be displayed.\n\n" +
                "The top board shows where each player has attacked their opponent's board, hits (X) and misses (O).\n\n" +
                "The bottom board shows the player's own board:\n" +
                "\tEach ship's placement is denoted with the proper letter:\n" +
                "\t(D - destroyer, S - submarine, B - battleship, A - aircraft carrier)\n\n" +
                "Opponent's attempts will be displayed each round.\n" +
                "Misses will be shown as \"o\", while hits will be shown as \"x\" surrounding the player's ship.\n" +
                "Each round, players will enter coordinates to attack.\n" +
                "Hits and misses will be displayed, and boards will be updated automatically.\n" +
                "Players will score a point for each opponent ship they successfully destroy.\n" +
                "Play will continue until all of one player's ships are destroyed!\n");

            Console.WriteLine("Each player will place their ships on the board, and then the battle will begin!");
        }
        public void PlayGame()
        {
            
            // choose player to go first (default to player 1 at first)
            ChooseFirstPlayer();
            while(playerOne.score < 4 && playerTwo.score < 4) // repeat play while no player has 4 points
            {
                if (playerOne.isTurn) // if player one's turn
                {
                    Console.Clear();
                    Console.WriteLine($"{playerOne.name}'s turn:\n");
                    // Display game boards (opponent on top, own on bottom)

                    Console.WriteLine("Opponent's Board:");
                    DisplayGameBoard(playerOne.opponentGameboard); // opponent - only attempts made
                    Console.WriteLine("\nYour Board:");
                    DisplayGameBoard(playerOne.ownGameboard); // own - where ships are, where opponent has attacked

                    Console.Write("\nChoose opponent coordinates to attack: "); // Player chooses where to attack
                    string userInput = Console.ReadLine(); // user input coordinates - verification needed

                    SwitchTurns();
                }
                else // if player two's turn
                {
                    Console.Clear();
                    DisplayGameBoard(playerTwo.opponentGameboard);
                    DisplayGameBoard(playerTwo.ownGameboard);
                    Console.Write("Choose coordinates to attack: ");
                    string userInput = Console.ReadLine();

                    SwitchTurns();
                }
            }
            // check opponent's own gameboard
            // if only spaces, replace with o and display miss
            // else if it contains anything other than spaces, replace with x_x and display hit
            // check own gameboard, replace with X or O for hit or miss
            // Display updated game boards, repeat
        }

        public void ChooseFirstPlayer()
        {
            playerOne.isTurn = true;
        }

        public void SwitchTurns()
        {
            playerOne.isTurn = !playerOne.isTurn;
            playerTwo.isTurn = !playerTwo.isTurn;
        }

        public static void DisplayGameBoard(GameBoard gameboard)
        {
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    Console.Write(gameboard.board[i,j]);
                }
                Console.WriteLine(); // blank line between boards
            }
            Console.WriteLine(); // blank line after boards
        }

            
    }
}
