namespace Core.Shogi.Console
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var board = new ShogiGame(new BoardConsoleRender(), new BoardConsoleInput(), null, new Board());
            board.Start(TODO);
        }
    }
}