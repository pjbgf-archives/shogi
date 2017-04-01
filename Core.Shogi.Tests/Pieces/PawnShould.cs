using System.Collections.Generic;
using Core.Shogi.Pieces;
using Xunit;

namespace Core.Shogi.Tests.Pieces
{
    
    public class PawnShould
    {
        [Fact]
        public void Have_P_AsShortName()
        {
            var pawn = new Pawn(PlayerType.Black, "1g");

            Assert.Equal('P', pawn.ShortName);
        }

        [Theory]
        [InlineData(PlayerType.Black, "1g", "1h")] //"NotMoveBackwardAsBlackPlayer")]
        [InlineData(PlayerType.White, "1c", "1b")] //"NotMoveBackwardAsWhitePlayer")]
        [InlineData(PlayerType.Black, "5g", "6g")] //"NotMoveLeftAsBlackPlayer")]
        [InlineData(PlayerType.White, "5c", "4c")] //"NotMoveLeftAsWhitePlayer")]
        [InlineData(PlayerType.Black, "5g", "4g")] //"NotMoveRightAsBlackPlayer")]
        [InlineData(PlayerType.White, "5c", "6c")] //"NotMoveRightAsWhitePlayer")]
        [InlineData(PlayerType.Black, "5g", "6h")] //"NotMoveBackLeftAsBlackPlayer")]
        [InlineData(PlayerType.White, "5c", "4b")] //"NotMoveBackLeftAsWhitePlayer")]
        [InlineData(PlayerType.Black, "5g", "4h")] //"NotMoveBackRightAsBlackPlayer")]
        [InlineData(PlayerType.White, "5c", "6b")] //"NotMoveBackRightAsWhitePlayer")]
        [InlineData(PlayerType.Black, "5g", "6f")] //"NotMoveForwardLeftAsBlackPlayer")]
        [InlineData(PlayerType.White, "5c", "4d")] //"NotMoveForwardLeftAsWhitePlayer")]
        [InlineData(PlayerType.Black, "5g", "4f")] //"NotMoveForwardRightAsBlackPlayer")]
        [InlineData(PlayerType.White, "5c", "6d")] //"NotMoveForwardRightAsWhitePlayer")]
        public void NotAllowIllegalMoves(PlayerType player, string positionFrom, string positionTo)
        {
            var pawn = new Pawn(player, positionFrom);

            var isMoveLegal = pawn.IsMoveLegal(positionTo);

            Assert.False(isMoveLegal);
        }

        [Theory]
        [InlineData(PlayerType.Black, "8g", "8f")] //"BeAbleToMove1RowUpAsBlackPlayer")]
        [InlineData(PlayerType.White, "8c", "8d")] //"BeAbleToMove1RowDownAsWhitePlayer")]
        [InlineData(PlayerType.Black, "8g", "8e")] //"BeAbleToMove2RowsUpAsBlackPlayerIfFirstMove")]
        [InlineData(PlayerType.White, "8c", "8e")] //"BeAbleToMove2RowsDownAsWhitePlayerIfFirstMove")]
        public void AllowValidMoves(PlayerType player, string positionFrom, string positionTo)
        {
            var pawn = new Pawn(player, positionFrom);

            var isMoveLegal = pawn.IsMoveLegal(positionTo);

            Assert.True(isMoveLegal);
        }

        [Theory]
        [InlineData(PlayerType.Black, "8g", new string[] { "8g8f", "8g8e" })] //"AsBlackPlayer")]
        [InlineData(PlayerType.White, "1c", new string[] { "1c1d", "1c1e" })] //"AsWhitePlayer")]
        public void KnowAllItsPossibleMoves(PlayerType player, string position,
            IEnumerable<string> expectedPossibleMovements)
        {
            var pawn = new Pawn(player, position);

            var possibleMovements = pawn.PossibleMovements;

            Assert.Equal(expectedPossibleMovements, possibleMovements);
        }
    }
}