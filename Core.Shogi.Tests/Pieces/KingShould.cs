using System.Collections.Generic;
using Core.Shogi.Pieces;
using Xunit;

namespace Core.Shogi.Tests.Pieces
{
    public class KingShould
    {
        [Fact]
        public void Have_K_AsShortName()
        {
            var king = new King(Player.Black, "5i");

            Assert.Equal('K', king.ShortName);
        }

        [Theory]
        [InlineData(Player.Black, "7i", "7h")] 
        [InlineData(Player.White, "7a", "7b")] 
        [InlineData(Player.Black, "7i", "8h")] 
        [InlineData(Player.White, "7a", "6b")] 
        [InlineData(Player.Black, "5e", "6f")] 
        [InlineData(Player.White, "5e", "4d")] 
        [InlineData(Player.Black, "6h", "6i")] 
        [InlineData(Player.White, "6b", "6a")] 
        [InlineData(Player.Black, "5e", "4f")] 
        [InlineData(Player.White, "5e", "6d")] 
        [InlineData(Player.Black, "7i", "6h")] 
        [InlineData(Player.White, "7a", "8b")] 
        [InlineData(Player.Black, "5e", "6e")] 
        [InlineData(Player.White, "5e", "4e")] 
        [InlineData(Player.Black, "5e", "4e")] 
        [InlineData(Player.White, "5e", "6e")] 
        public void AllowValidMoves(Player player, string positionFrom, string positionTo)
        {
            var king = new King(player, positionFrom);

            var isMoveLegal = king.IsMoveLegal(positionTo);

            Assert.True(isMoveLegal);
        }

        [Theory]
        [InlineData(Player.Black, "5e", new string[] { "5e5d", "5e5f", "5e4e", "5e6e", "5e6d", "5e4d", "5e6f", "5e4f" })]//"AsBlackPlayer"
        [InlineData(Player.White, "5e", new string[] { "5e5d", "5e5f", "5e4e", "5e6e", "5e6d", "5e4d", "5e6f", "5e4f" })]//"AsWhitePlayer"
        public void KnowAllItsPossibleMoves(Player player, string position,
            IEnumerable<string> expectedPossibleMovements)
        {
            var king = new King(player, position);

            var possibleMovements = king.PossibleMovements;

            Assert.Equal(expectedPossibleMovements, possibleMovements);
        }
    }
}