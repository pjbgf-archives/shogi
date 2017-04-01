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
            var king = new King(PlayerType.Black, "5i");

            Assert.Equal('K', king.ShortName);
        }

        [Theory]
        [InlineData(PlayerType.Black, "7i", "7h")] //"BeAbleToMoveForwardAsBlackPlayer")]
        [InlineData(PlayerType.White, "7a", "7b")] //"BeAbleToMoveForwardAsWhitePlayer")]
        [InlineData(PlayerType.Black, "7i", "8h")] //"BeAbleToMoveForwardLeftAsBlackPlayer")]
        [InlineData(PlayerType.White, "7a", "6b")] //"BeAbleToMoveForwardLeftAsWhitePlayer")]
        [InlineData(PlayerType.Black, "5e", "6f")] //"BeAbleToMoveBackLeftAsBlackPlayer")]
        [InlineData(PlayerType.White, "5e", "4d")] //"BeAbleToMoveBackLeftAsWhitePlayer")]
        [InlineData(PlayerType.Black, "6h", "6i")] //"BeAbleToMoveBackAsBlackPlayer")]
        [InlineData(PlayerType.White, "6b", "6a")] //"BeAbleToMoveBackAsWhitePlayer")]
        [InlineData(PlayerType.Black, "5e", "4f")] //"BeAbleToBackRightAsBlackPlayer")]
        [InlineData(PlayerType.White, "5e", "6d")] //"BeAbleToBackRightAsWhitePlayer")]
        [InlineData(PlayerType.Black, "7i", "6h")] //"BeAbleToMoveForwardRightAsBlackPlayer")]
        [InlineData(PlayerType.White, "7a", "8b")] //"BeAbleToMoveForwardRightAsWhitePlayer")]
        [InlineData(PlayerType.Black, "5e", "6e")] //"BeAbleToMoveLeftAsBlackPlayer")]
        [InlineData(PlayerType.White, "5e", "4e")] //"BeAbleToMoveLeftAsWhitePlayer")]
        [InlineData(PlayerType.Black, "5e", "4e")] //"BeAbleToMoveRightAsBlackPlayer")]
        [InlineData(PlayerType.White, "5e", "6e")] //"BeAbleToMoveRightAsWhitePlayer")]
        public void AllowValidMoves(PlayerType player, string positionFrom, string positionTo)
        {
            var king = new King(player, positionFrom);

            var isMoveLegal = king.IsMoveLegal(positionTo);

            Assert.True(isMoveLegal);
        }

        [Theory]
        [InlineData(PlayerType.Black, "5e", new string[] { "5e5d", "5e5f", "5e4e", "5e6e", "5e6d", "5e4d", "5e6f", "5e4f" })]//"AsBlackPlayer"
        [InlineData(PlayerType.White, "5e", new string[] { "5e5d", "5e5f", "5e4e", "5e6e", "5e6d", "5e4d", "5e6f", "5e4f" })]//"AsWhitePlayer"
        public void KnowAllItsPossibleMoves(PlayerType player, string position,
            IEnumerable<string> expectedPossibleMovements)
        {
            var king = new King(player, position);

            var possibleMovements = king.PossibleMovements;

            Assert.Equal(expectedPossibleMovements, possibleMovements);
        }
    }
}