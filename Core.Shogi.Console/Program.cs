namespace Core.Shogi.Console
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var board = new Board();
            var blackPlayer = HumanPlayerConsoleAdapter.CreateFor(Player.Black);
            var whitePlayer = HumanPlayerConsoleAdapter.CreateFor(Player.White);

            var shogiGame = new ShogiGame(new BoardConsoleRender(), blackPlayer, whitePlayer, board);
            shogiGame.Start();
        }
    }
}