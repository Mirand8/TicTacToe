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
                Console.WriteLine("Quer continuar jogando?");
                Console.Write("[0] - Sim [1] - Nao");
                continuePlay = int.Parse(Console.ReadLine());
                Console.Clear();
            } while (continuePlay == 0);
            Console.WriteLine("Obrigado por jogar! =)");
            Console.ReadKey();
        }
    }
}
