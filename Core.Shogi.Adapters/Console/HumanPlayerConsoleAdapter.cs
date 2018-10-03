using System;

namespace Core.Shogi.Adapters.Console
{
    public class HumanPlayerConsoleAdapter : IBoardPlayer
    {
        private HumanPlayerConsoleAdapter(Player player)
        {
            Player = player;
        }

        public static IBoardPlayer CreateFor(Player player)
        {
            return new HumanPlayerConsoleAdapter(player);
        }

        public string AskForNextMove()
        {
            System.Console.WriteLine($"Next move for {Enum.GetName(typeof(Player), Player)} Player: ");
            return System.Console.ReadLine();
        }

        public Player Player { get; private set; }
    }
}