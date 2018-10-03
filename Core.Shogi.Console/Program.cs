using Core.Shogi.Adapters.Console;
using Core.Shogi.FullVersion;

namespace Core.Shogi.Console
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var blackPlayer = ConsoleHumanPlayer.CreateFor(Player.Black);
            var whitePlayer = ConsoleHumanPlayer.CreateFor(Player.White);

            var shogiGame = new ShogiGame(
                new BoardConsoleRender(), 
                blackPlayer, 
                whitePlayer, 
                new Board());

            shogiGame.Start();
        }
    }
}