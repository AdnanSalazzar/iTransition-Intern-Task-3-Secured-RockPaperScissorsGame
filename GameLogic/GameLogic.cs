namespace GameLogic
{
    public static class GameLogic
    {
        public static int DetermineWinner(string[] moves, int playerMove, int computerMove)
        {
            int n = moves.Length;
            int p = n / 2;
            int result = (playerMove - computerMove + p + n) % n - p;
            return Math.Sign(result);
        }

        public static bool IsValidMove(string[] moves, int move)
        {
            return move >= 0 && move < moves.Length;
        }
    }
}
