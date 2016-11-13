using Core.Shogi.Adapters.Console;

namespace Core.Shogi.Console
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var board = new Board();
            var blackPlayer = HumanPlayerConsoleAdapter.CreateFor(Player.Black);
            var whitePlayer = NoviceComputerPlayer.CreateFor(Player.White, board);

            var shogiGame = new ShogiGame(new BoardConsoleRender(), blackPlayer, whitePlayer, board);
            shogiGame.Start();
        }
    }
}