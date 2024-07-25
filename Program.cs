using System;
using System.Collections.Generic;
using Crypto;
using GameLogic;
using UI;

namespace RockPaperScissorsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] defaultMoves = { "rock", "paper", "scissors", "lizard", "spock" };
            int numOfMoves;

            do
            {
                Console.WriteLine("Enter the number of moves (must be an odd number greater than or equal to 3):");
            } while (!int.TryParse(Console.ReadLine(), out numOfMoves) || numOfMoves < 3 || numOfMoves % 2 == 0);

            string[] moves = new string[numOfMoves];

            for (int i = 0; i < numOfMoves; i++)
            {
                if (i < defaultMoves.Length)
                {
                    moves[i] = defaultMoves[i];
                }
                else
                {
                    moves[i] = (i + 1).ToString();
                }
            }

            var key = CryptoManager.GenerateKey();
            var computerMoveIndex = MoveManager.GetComputerMove(moves);
            var hmac = CryptoManager.ComputeHMAC(moves[computerMoveIndex], key);
            Console.WriteLine($"HMAC: {hmac}");

            while (true)
            {
                DisplayManager.DisplayMenu(moves);
                var input = Console.ReadLine();

                if (input == "0")
                {
                    break;
                }

                if (input == "?")
                {
                    DisplayManager.GenerateHelpTable(moves);
                    continue;
                }

                if (int.TryParse(input, out int playerMoveIndex) && GameLogic.GameLogic.IsValidMove(moves, playerMoveIndex - 1))
                {
                    playerMoveIndex--;
                    Console.WriteLine($"Your move: {moves[playerMoveIndex]}");
                    Console.WriteLine($"Computer move: {moves[computerMoveIndex]}");

                    int result = GameLogic.GameLogic.DetermineWinner(moves, playerMoveIndex, computerMoveIndex);

                    if (result == 0)
                        Console.WriteLine("It's a draw!");
                    else if (result == 1)
                        Console.WriteLine("You win!");
                    else
                        Console.WriteLine("You lose!");

                    Console.WriteLine($"HMAC key: {BitConverter.ToString(key).Replace("-", "")}");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid move, please try again.");
                }
            }
        }
    }
}
