using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class TicTacToe
    {
        public Board Board { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public static int PlaysCount { get; set; }

        public Player Turn { get; set; }
        private readonly static int _tie = -1;
        private readonly static int _win = 1;
        private static int EndGame { get;  set; }

        public TicTacToe()
        {
            Player1 = new Player(1);
            Player2 = new Player(2);
            PlaysCount = 0;
            Board = new Board();
            Player1.Letter = 'x';
            Player2.Letter = 'o';
        }

        public void Play()
        {
            do
            {
                if (PlaysCount == 0)
                {
                    Turn = Player1;
                    Show();
                }
                else
                {
                    Turn = PlaysCount % 2 == 0 ? Player1 : Player2;
                    UpdateBoard();
                }
                Console.Write($"Faca sua jogada, jogador {Turn.Id}: ");
                int move = int.Parse(Console.ReadLine());
                while (!(Board.IsPositionEmpty(move) && move < 10 && move >= 1))
                {
                    if (!(move < 10 && move >= 1))
                    {
                        Console.WriteLine("\n======= ATENCAO!! Esta posicao eh invalida!=======\n");
                    }
                    else if (!(Board.IsPositionEmpty(move)))
                    {
                        Console.WriteLine("\n======= ATENCAO!! Este lugar ja esta ocupado!=======\n");
                    }
                    Console.Write($"Faca sua jogada, jogador {Turn.Id}: ");
                    move = int.Parse(Console.ReadLine());
                }
                Board.SetPosition(move, Turn.Letter);
                ++PlaysCount;

                CheckWin();
                CheckTie();
            } while (EndGame == 0);

            UpdateBoard();

            if (EndGame == _win)
            {
                if (Turn.Id == 1) Player1.WinCount++;
                else Player2.WinCount++;
                Console.WriteLine($"\nPARABENS!! JOGADOR {Turn.Id} VENCEU =)");
            }
            else if (EndGame == _tie)
            {
                Console.WriteLine($"\nEMPATE! DESSA VEZ NINGUEM VENCEU =(");
            }

            ShowScoreBoard();
        }

        void ShowScoreBoard()
        {
            Console.Clear();
            Console.WriteLine($"Jogador1 tem {Player1.WinCount} vitorias");
            Console.WriteLine($"Jogador2 tem {Player2.WinCount} vitorias");
            Console.ReadKey();
            Console.Clear();
        }

        public void ResetGame()
        {
            PlaysCount = 0;
            Board = new Board();
            EndGame = 0;
        }

        void UpdateBoard()
        {
            Console.Clear();
            Show();
        }

        void CheckTie()
        {
            bool tie = PlaysCount > 8;

            if (tie) EndGame = _tie;
        }

        void CheckWin()
        {
            bool win = CheckRows() || CheckDiagonals() || CheckColumns();

            if (win) EndGame = _win;
        }

        bool CheckRows()
        {
            char[] row0 = Board.GetRow(0);
            char[] row1 = Board.GetRow(1);
            char[] row2 = Board.GetRow(2);
            bool checkRow0 = false, checkRow1 = false, checkRow2 = false;

            if (!row0.Contains('-'))
            {
                checkRow0 = AllEqual(row0);
            }
            else if (!row1.Contains('-'))
            {
                checkRow1 = AllEqual(row1);
            }
            else if (!row2.Contains('-'))
            {
                checkRow2 = AllEqual(row2);
            }

            return checkRow0 || checkRow1 || checkRow2;
        }

        bool CheckColumns()
        {
            char[] column0 = Board.GetColumn(0);
            char[] column1 = Board.GetColumn(1);
            char[] column2 = Board.GetColumn(2);
            bool checkRow0 = false, checkRow1 = false, checkRow2 = false;

            if (!column0.Contains('-'))
            {
                checkRow0 = AllEqual(column0);
            }
            else if (!column1.Contains('-'))
            {
                checkRow1 = AllEqual(column1);
            }
            else if (!column2.Contains('-'))
            {
                checkRow2 = AllEqual(column2);
            }

            return checkRow0 || checkRow1 || checkRow2;
        }

        bool CheckDiagonals()
        {
            char[] principal = Board.GetDiagonal(0);
            char[] right = Board.GetDiagonal(1);
            bool checkPrincipal = false, checkRight = false;

            if (!principal.Contains('-'))
            {
                checkPrincipal = AllEqual(principal);
            }
            else if (!right.Contains('-'))
            {
                checkRight = AllEqual(right);
            }

            return checkPrincipal || checkRight;
        }

        static bool AllEqual(char[] array) => array.All(letter => letter == 'x') || array.All(letter => letter == 'o');

        public void Show()
        {
            Console.WriteLine("\t-=-=-=-=-=-=-=-=-=-=-=-=-=-\n" +
                              "\t\tJOGO DA VELHA \n" +
                              "\t-=-=-=-=-=-=-=-=-=-=-=-=-=-\n" +
                              "\t\tJOGADOR 1 = X\n" +
                              "\t\tJOGADOR 2 = O\n" +
                              "\t-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n" + 
                              "\tPara jogar, digite a posicao (de 1 a 9) que deseja posicionar sua jogada!\n"
                             );
            Board.Show();
        }
    }
}
