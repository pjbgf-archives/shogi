using System.Collections.Generic;
using Core.Shogi.Pieces;
using Xunit;

namespace Core.Shogi.Tests.Pieces
{
    
    public class LanceShould
    {
        [Fact]
        public void Have_L_AsShortName()
        {
            var lance = new Lance(Player.Black, "5i");

            Assert.Equal('L', lance.ShortName);
        }

        [Theory]
        [InlineData(Player.Black, "7i", "8h")] //"NotMoveForwardLeftAsBlackPlayer")]
        [InlineData(Player.White, "7a", "6b")] //"NotMoveForwardLeftAsWhitePlayer")]
        [InlineData(Player.Black, "5e", "6f")] //"NotBackLeftAsBlackPlayer")]
        [InlineData(Player.White, "5e", "4d")] //"NotBackLeftAsWhitePlayer")]
        [InlineData(Player.Black, "6h", "6i")] //"NotMoveBackAsBlackPlayer")]
        [InlineData(Player.White, "6b", "6a")] //"NotMoveBackAsWhitePlayer")]
        [InlineData(Player.Black, "5e", "4f")] //"NotBackRightAsBlackPlayer")]
        [InlineData(Player.White, "5e", "6d")] //"NotBackRightAsWhitePlayer")]
        [InlineData(Player.Black, "7i", "6h")] //"NotMoveForwardRightAsBlackPlayer")]
        [InlineData(Player.White, "7a", "8b")] //"NotMoveForwardRightAsWhitePlayer")]
        public void NotAllowIllegalMoves(Player player, string positionFrom, string positionTo)
        {
            var lance = new Lance(player, positionFrom);

            var isMoveLegal = lance.IsMoveLegal(positionTo);

            Assert.False(isMoveLegal);
        }

        [Theory]
        [InlineData(Player.Black, "7i", "7h")] //"BeAbleToMoveForward1RowAsBlackPlayer")]
        [InlineData(Player.Black, "7i", "7g")] //"BeAbleToMoveForward2RowsAsBlackPlayer")]
        [InlineData(Player.Black, "7i", "7f")] //"BeAbleToMoveForward3RowsAsBlackPlayer")]
        [InlineData(Player.Black, "7i", "7e")] //"BeAbleToMoveForward4RowsAsBlackPlayer")]
        [InlineData(Player.Black, "7i", "7d")] //"BeAbleToMoveForward5RowsAsBlackPlayer")]
        [InlineData(Player.Black, "7i", "7c")] //"BeAbleToMoveForward6RowsAsBlackPlayer")]
        [InlineData(Player.Black, "7i", "7b")] //"BeAbleToMoveForward7RowsAsBlackPlayer")]
        [InlineData(Player.Black, "7i", "7a")] //"BeAbleToMoveForward8RowsAsBlackPlayer")]
        [InlineData(Player.White, "7a", "7b")] //"BeAbleToMoveForward1RowAsWhitePlayer")]
        [InlineData(Player.White, "7a", "7c")] //"BeAbleToMoveForward2RowsAsWhitePlayer")]
        [InlineData(Player.White, "7a", "7d")] //"BeAbleToMoveForward3RowsAsWhitePlayer")]
        [InlineData(Player.White, "7a", "7e")] //"BeAbleToMoveForward4RowsAsWhitePlayer")]
        [InlineData(Player.White, "7a", "7f")] //"BeAbleToMoveForward5RowsAsWhitePlayer")]
        [InlineData(Player.White, "7a", "7g")] //"BeAbleToMoveForward6RowsAsWhitePlayer")]
        [InlineData(Player.White, "7a", "7h")] //"BeAbleToMoveForward7RowsAsWhitePlayer")]
        [InlineData(Player.White, "7a", "7i")] //"BeAbleToMoveForward8RowsAsWhitePlayer")]
        public void AllowValidMoves(Player player, string positionFrom, string positionTo)
        {
            var lance = new Lance(player, positionFrom);

            var isMoveLegal = lance.IsMoveLegal(positionTo);

            Assert.True(isMoveLegal);
        }

        [Theory()]
        [InlineData(Player.Black, "9i", new string[] { "9i9h", "9i9g", "9i9f", "9i9e", "9i9d", "9i9c", "9i9b", "9i9a" })]//TestName = "AsBlackPlayer")]
        [InlineData(Player.White, "1a", new string[] { "1a1b", "1a1c", "1a1d", "1a1e", "1a1f", "1a1g", "1a1h", "1a1i" })]//TestName = "AsWhitePlayer")]
        public void KnowAllItsPossibleMoves(Player player, string position,
            IEnumerable<string> expectedPossibleMovements)
        {
            var lance = new Lance(player, position);

            var possibleMovements = lance.PossibleMovements;

            Assert.Equal(expectedPossibleMovements, possibleMovements);
        }
    }
}