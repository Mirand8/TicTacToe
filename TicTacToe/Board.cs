using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Board
    {
        public char[,] CurrentGame { get; set; }


        public Board()
        {
            CurrentGame = new char[3, 3];
            FillBoard();
        }

        public bool IsPositionEmpty(int move) => GetPosition(move) == '-';

        public char GetPosition(int move)
        {
            return move switch
            {
                1 => CurrentGame[0, 0],
                2 => CurrentGame[0, 1],
                3 => CurrentGame[0, 2],
                4 => CurrentGame[1, 0],
                5 => CurrentGame[1, 1],
                6 => CurrentGame[1, 2],
                7 => CurrentGame[2, 0],
                8 => CurrentGame[2, 1],
                9 => CurrentGame[2, 2],
                _ => 'e',
            };
        }

        public void SetPosition(int move, char letter)
        {
            switch (move)
            {
                case 1: CurrentGame[0, 0] = letter; break;

                case 2: CurrentGame[0, 1] = letter; break;

                case 3: CurrentGame[0, 2] = letter; break;

                case 4: CurrentGame[1, 0] = letter; break;

                case 5: CurrentGame[1, 1] = letter; break;

                case 6: CurrentGame[1, 2] = letter; break;

                case 7: CurrentGame[2, 0] = letter; break;

                case 8: CurrentGame[2, 1] = letter; break;

                case 9: CurrentGame[2, 2] = letter; break;
            }
        }

        public char[] GetColumn(int position)
        {
            char[] column = new char[3];

            for (int i = 0; i < CurrentGame.GetLength(0); i++)
            {
                for (int j = 0; j < CurrentGame.GetLength(1); j++)
                {
                    if (position == j) column[i] = CurrentGame[i, j];
                }
            }
            return column;
        }

        public char[] GetRow(int position)
        {
            char[] row = new char[3];

            for (int i = 0; i < CurrentGame.GetLength(0); i++)
            {
                for (int j = 0; j < CurrentGame.GetLength(1); j++)
                {
                    row[j] = CurrentGame[position, j];
                }
            }
            return row;
        }

        public char[] GetDiagonal(int position)
        {
            char[] diagonal = new char[3];

            for (int i = 0; i < CurrentGame.GetLength(0); i++)
            {
                for (int j = 0; j < CurrentGame.GetLength(1); j++)
                {
                    switch (position)
                    {
                        case 0:
                            if (i == j) diagonal[j] = CurrentGame[i, j];
                            break;
                        case 1:
                            if ((i + j) == 2) diagonal[j] = CurrentGame[i, j];
                            break;
                    }
                }
            }

            return diagonal;
        }

        void FillBoard()
        {
            CurrentGame = new char[3, 3];
            for (int i = 0; i < CurrentGame.GetLength(0); i++)
            {
                for (int j = 0; j < CurrentGame.GetLength(1); j++)
                {
                    CurrentGame[i, j] = '-';
                }
            }
        }

        public void Show()
        {
            Console.WriteLine("\t\t{0} : 1\t | \t{1} : 2\t | \t{2} : 3\n" +
                              "\t-----------------------------------------------\n" +
                              "\t\t{3} : 4\t | \t{4} : 5\t | \t{5} : 6\n" +
                              "\t-----------------------------------------------\n" +
                              "\t\t{6} : 7\t | \t{7} : 8\t | \t{8} : 9\n",
                               CurrentGame[0, 0],
                               CurrentGame[0, 1],
                               CurrentGame[0, 2],
                               CurrentGame[1, 0],
                               CurrentGame[1, 1],
                               CurrentGame[1, 2],
                               CurrentGame[2, 0],
                               CurrentGame[2, 1],
                               CurrentGame[2, 2]);
        }
    }
}
