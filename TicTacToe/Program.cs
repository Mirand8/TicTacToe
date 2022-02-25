using System;
using System.Linq;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] tab = new char[3, 3];
            tab[0, 0] = 'o';
            tab[0, 1] = 'o';
            tab[0, 2] = 'o';

            tab[1, 0] = 'x';
            tab[1, 1] = 'x';
            tab[1, 2] = 'x';

            tab[2, 0] = 'x';
            tab[2, 1] = 'x';
            tab[2, 2] = 'x';

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(tab[i, j] + "\t");
                }
                Console.WriteLine();
            }

            char[] row1 = GetFullRow(0, tab);

            Console.WriteLine(CheckWin(row1));
        }

        private static char[] GetFullRow(int rowToGet, char[,] tab)
        {
            char[] fullRow = new char[3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == rowToGet)
                    {
                        fullRow[j] = tab[i, j];
                        Console.WriteLine(fullRow[j]);
                    }
                }
            }
            return fullRow;
        }

        private static char[] GetFullColumn(int columnToGet, char[,] tab)
        {
            Console.WriteLine();
            char[] fullColumn = new char[3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (j == columnToGet)
                    {
                        fullColumn[j] = tab[i, j];
                        Console.Write(fullColumn[j]);
                        Console.WriteLine("->" + i + " " + j);
                    }
                }
            }
            return fullColumn;
        }

        private static bool CheckWin(char[] dimenson) => !dimenson.Any(x => x != dimenson.First() || x != dimenson.Last());
    }
}
