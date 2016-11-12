namespace Core.Shogi.Console
{
    internal class BoardConsoleInput : IBoardInput
    {
        public string AskForNextMove()
        {
            System.Console.WriteLine("Next move for Black Player: ");
            return System.Console.ReadLine();
        }
    }
}