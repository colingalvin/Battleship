using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBattleship
{
    class GameBoard
    {
        // member variables (HAS A)
        public string[,] board;

        // constructor (SPAWN)
        public GameBoard()
        {
            board = new string[11, 11]
            {
                    {"  ", " A ", " B ", " C ", " D ", " E ", " F ", " G ", " H ", " I ", " J "},
                    {"1 ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   "},
                    {"2 ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   "},
                    {"3 ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   "},
                    {"4 ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   "},
                    {"5 ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   "},
                    {"6 ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   "},
                    {"7 ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   "},
                    {"8 ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   "},
                    {"9 ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   "},
                    {"10", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   "},
            };
        }

        // member methods (CAN DO)
    }
}
