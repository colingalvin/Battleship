using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBattleship
{
    class Verification
    {
        public static string VerifyCoordinates(string coordinates)
        {
            bool isColumn;
            bool isRow;
            do
            {
                isColumn = VerifyColumn(coordinates);
                isRow = VerifyRow(coordinates);
                if (!isColumn || !isRow)
                {
                    Console.Write("Invalid coordinates. Please format as such: a10, b5, f2.\n" +
                        "Please enter a new coordiante: ");
                    coordinates = Console.ReadLine();
                }
            }
            while (isColumn == false || isRow == false);
            return coordinates.ToLower(); // Return lower-case version of input
        }

        private static bool VerifyColumn(string coordinates)
        {
            bool isColumn = false;
            char[] columns = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j' };
            char userColumn = char.ToLower(coordinates[0]);
            foreach (char column in columns)
            {
                if (column == userColumn)
                {
                    isColumn = true;
                    break;
                }
            }
            return isColumn;
        }

        private static bool VerifyRow(string coordinates)
        {
            bool isRow = false;
            int userRow;
            bool isNumber = int.TryParse(coordinates.Substring(1), out userRow);
            if (isNumber && userRow >= 1 && userRow <= 10) // NO MAGIC NUMBERS!
            {
                isRow = true;
            }
            return isRow;
        }
    }
}
