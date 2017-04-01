using System;

namespace Core.Shogi.Adapters.Console
{
    public class HumanPlayerConsoleAdapter : IBoardPlayer
    {
        private HumanPlayerConsoleAdapter(PlayerType player)
        {
            Player = player;
        }

        public static IBoardPlayer CreateFor(PlayerType player)
        {
            return new HumanPlayerConsoleAdapter(player);
        }

        public string AskForNextMove()
        {
            System.Console.WriteLine($"Next move for {Enum.GetName(typeof(PlayerType), Player)} Player: ");
            return System.Console.ReadLine();
        }

        public PlayerType Player { get; private set; }
    }
}