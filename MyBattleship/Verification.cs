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
        public static int[] VerifyCoordinates(string coordinates)
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
            int[] arrayCoordinates = ConvertCoordinates(coordinates.ToLower()); // Return lower-case version of input
            return arrayCoordinates;
        }
        public static int[] ConvertCoordinates(string userInput)
        {
            int[] coordinates = new int[2]; // store verified coordinates here
            coordinates[0] = ParseRow(userInput);
            coordinates[1] = ParseColumn(userInput);
            return coordinates;
        }

        public static int ParseColumn(string coordinates)
        {
            int arrayColumnIndex = -1;
            char column = coordinates[0];
            switch (column)
            {
                case 'a':
                    arrayColumnIndex = 1;
                    break;
                case 'b':
                    arrayColumnIndex = 2;
                    break;
                case 'c':
                    arrayColumnIndex = 3;
                    break;
                case 'd':
                    arrayColumnIndex = 4;
                    break;
                case 'e':
                    arrayColumnIndex = 5;
                    break;
                case 'f':
                    arrayColumnIndex = 6;
                    break;
                case 'g':
                    arrayColumnIndex = 7;
                    break;
                case 'h':
                    arrayColumnIndex = 8;
                    break;
                case 'i':
                    arrayColumnIndex = 9;
                    break;
                case 'j':
                    arrayColumnIndex = 10;
                    break;
            }
            return arrayColumnIndex;
        }

        public static int ParseRow(string coordiantes)
        {
            int arrayRowIndex = int.Parse(coordiantes.Substring(1));
            return arrayRowIndex;
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
