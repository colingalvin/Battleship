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
            Console.WriteLine("Each player will place their ships on the board, and then the battle will begin!");
        }
        public void PlayGame()
        {
            DisplayGameBoard(playerOne.ownGameboard);
        }

        public void DisplayGameBoard(GameBoard gameboard)
        {
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    Console.Write(gameboard.board[i,j]);
                }
                Console.WriteLine();
            }
        }
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
