using System;

namespace Core.Shogi.Console
{
    public class BoardConsoleInput : IBoardInput
    {
        private BoardConsoleInput(Player player)
        {
            Player = player;
        }

        public static IBoardInput CreateFor(Player player)
        {
            return new BoardConsoleInput(player);
        }

        public string AskForNextMove()
        {
            System.Console.WriteLine($"Next move for {Enum.GetName(typeof(Player), Player)} Player: ");
            return System.Console.ReadLine();
        }

        public Player Player { get; private set; }
    }
}