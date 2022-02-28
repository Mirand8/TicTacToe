using System;
using System.Linq;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            int continuePlay;
            TicTacToe game = new TicTacToe();

            // RESET NOT WORKING

            do 
            {
                game.Play();
                Console.Write("Deseja jogar novamente? ([0] - Contiuar [1] - Sair )");
                continuePlay = int.Parse(Console.ReadLine());
                Console.WriteLine($"Jogador1 tem {game.Player1.WinCount} vitorias");
                Console.WriteLine($"Jogador2 tem {game.Player1.WinCount} vitorias");
                Console.ReadKey();
                Console.Clear();
            } while (continuePlay == 0);
        }
    }
}
