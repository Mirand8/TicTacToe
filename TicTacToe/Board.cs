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
                0 => CurrentGame[0, 0],
                1 => CurrentGame[0, 1],
                2 => CurrentGame[0, 2],
                3 => CurrentGame[1, 0],
                4 => CurrentGame[1, 1],
                5 => CurrentGame[1, 2],
                6 => CurrentGame[2, 0],
                7 => CurrentGame[2, 1],
                8 => CurrentGame[2, 2],
                _ => 'e',
            };
        }

        public void SetPosition(int move, char letter)
        {
            switch (move)
            {
                case 0: CurrentGame[0, 0] = letter; break;

                case 1: CurrentGame[0, 1] = letter; break;

                case 2: CurrentGame[0, 2] = letter; break;

                case 3: CurrentGame[1, 0] = letter; break;

                case 4: CurrentGame[1, 1] = letter; break;

                case 5: CurrentGame[1, 2] = letter; break;

                case 6: CurrentGame[2, 0] = letter; break;

                case 7: CurrentGame[2, 1] = letter; break;

                case 8: CurrentGame[2, 2] = letter; break;
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
            Console.WriteLine("\t\t{0}\t | \t{1}\t | \t{2}\n" +
                              "\t-----------------------------------------------\n" +
                              "\t\t{3}\t | \t{4}\t | \t{5}\n" +
                              "\t-----------------------------------------------\n" +
                              "\t\t{6}\t | \t{7}\t | \t{8}\n",
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
