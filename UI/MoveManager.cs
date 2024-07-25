using System;

namespace UI
{
    public static class MoveManager
    {
        public static int GetComputerMove(string[] moves)
        {
            var rng = new Random();
            return rng.Next(moves.Length);
        }
    }
}
