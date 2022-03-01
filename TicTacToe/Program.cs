using System;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int continuePlay = 0;
            TicTacToe game = new();

            do
            {
                game.ResetGame();
                game.Play();
            } while (continuePlay == 0);
        }
    }
}
