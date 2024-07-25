using System;
using System.Collections.Generic;
using ConsoleTables;

namespace UI
{
    public static class DisplayManager
    {
        public static void DisplayMenu(string[] moves)
        {
            Console.WriteLine("Available moves:");
            for (int i = 0; i < moves.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {moves[i]}");
            }
            Console.WriteLine("0 - exit");
            Console.WriteLine("? - help");
        }

        public static void GenerateHelpTable(string[] moves)
        {
            var table = new ConsoleTable("v PC/User >");
            table.AddColumn(moves);

            for (int i = 0; i < moves.Length; i++)
            {
                var row = new List<string> { moves[i] };
                for (int j = 0; j < moves.Length; j++)
                {
                    int result = GameLogic.GameLogic.DetermineWinner(moves, i, j);
                    if (result == 0)
                        row.Add("Draw");
                    else if (result == 1)
                        row.Add("Win");
                    else
                        row.Add("Lose");
                }
                table.AddRow(row.ToArray());
            }

            Console.WriteLine("Results from user's point of view:");
            table.Write(Format.Alternative);
        }
    }
}
