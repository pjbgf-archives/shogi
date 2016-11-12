using System;

namespace Core.Shogi.Console
{
    public class BoardConsoleInput : IBoardInput
    {
        private readonly Player _player;

        private BoardConsoleInput(Player player)
        {
            _player = player;
        }

        public static IBoardInput CreateFor(Player player)
        {
            return new BoardConsoleInput(player);
        }

        public string AskForNextMove()
        {
            System.Console.WriteLine($"Next move for {Enum.GetName(typeof(Player), _player)} Player: ");
            return System.Console.ReadLine();
        }
    }
}