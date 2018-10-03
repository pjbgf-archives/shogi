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
        [InlineData(Player.Black, "7i", "7h")] //"BeAbleToMoveForwardAsBlackPlayer")]
        [InlineData(Player.White, "7a", "7b")] //"BeAbleToMoveForwardAsWhitePlayer")]
        [InlineData(Player.Black, "7i", "8h")] //"BeAbleToMoveForwardLeftAsBlackPlayer")]
        [InlineData(Player.White, "7a", "6b")] //"BeAbleToMoveForwardLeftAsWhitePlayer")]
        [InlineData(Player.Black, "5e", "6f")] //"BeAbleToMoveBackLeftAsBlackPlayer")]
        [InlineData(Player.White, "5e", "4d")] //"BeAbleToMoveBackLeftAsWhitePlayer")]
        [InlineData(Player.Black, "6h", "6i")] //"BeAbleToMoveBackAsBlackPlayer")]
        [InlineData(Player.White, "6b", "6a")] //"BeAbleToMoveBackAsWhitePlayer")]
        [InlineData(Player.Black, "5e", "4f")] //"BeAbleToBackRightAsBlackPlayer")]
        [InlineData(Player.White, "5e", "6d")] //"BeAbleToBackRightAsWhitePlayer")]
        [InlineData(Player.Black, "7i", "6h")] //"BeAbleToMoveForwardRightAsBlackPlayer")]
        [InlineData(Player.White, "7a", "8b")] //"BeAbleToMoveForwardRightAsWhitePlayer")]
        [InlineData(Player.Black, "5e", "6e")] //"BeAbleToMoveLeftAsBlackPlayer")]
        [InlineData(Player.White, "5e", "4e")] //"BeAbleToMoveLeftAsWhitePlayer")]
        [InlineData(Player.Black, "5e", "4e")] //"BeAbleToMoveRightAsBlackPlayer")]
        [InlineData(Player.White, "5e", "6e")] //"BeAbleToMoveRightAsWhitePlayer")]
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