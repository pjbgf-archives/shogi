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
            var pawn = new Pawn(Player.Black, "1g");

            Assert.Equal('P', pawn.ShortName);
        }

        //[InlineDataWithName(Player.Black, "1g", "1h", TestName = "NotMoveBackwardAsBlackPlayer")]
        //[InlineDataWithName(Player.White, "1c", "1b", TestName = "NotMoveBackwardAsWhitePlayer")]
        //[InlineDataWithName(Player.Black, "5g", "6g", TestName = "NotMoveLeftAsBlackPlayer")]
        //[InlineDataWithName(Player.White, "5c", "4c", TestName = "NotMoveLeftAsWhitePlayer")]
        //[InlineDataWithName(Player.Black, "5g", "4g", TestName = "NotMoveRightAsBlackPlayer")]
        //[InlineDataWithName(Player.White, "5c", "6c", TestName = "NotMoveRightAsWhitePlayer")]
        //[InlineDataWithName(Player.Black, "5g", "6h", TestName = "NotMoveBackLeftAsBlackPlayer")]
        //[InlineDataWithName(Player.White, "5c", "4b", TestName = "NotMoveBackLeftAsWhitePlayer")]
        //[InlineDataWithName(Player.Black, "5g", "4h", TestName = "NotMoveBackRightAsBlackPlayer")]
        //[InlineDataWithName(Player.White, "5c", "6b", TestName = "NotMoveBackRightAsWhitePlayer")]
        //[InlineDataWithName(Player.Black, "5g", "6f", TestName = "NotMoveForwardLeftAsBlackPlayer")]
        //[InlineDataWithName(Player.White, "5c", "4d", TestName = "NotMoveForwardLeftAsWhitePlayer")]
        //[InlineDataWithName(Player.Black, "5g", "4f", TestName = "NotMoveForwardRightAsBlackPlayer")]
        //[InlineDataWithName(Player.White, "5c", "6d", TestName = "NotMoveForwardRightAsWhitePlayer")]
        public void NotAllowIllegalMoves(Player player, string positionFrom, string positionTo)
        {
            var pawn = new Pawn(player, positionFrom);

            var isMoveLegal = pawn.IsMoveLegal(positionTo);

            Assert.False(isMoveLegal);
        }

        //[InlineDataWithName(Player.Black, "8g", "8f", TestName = "BeAbleToMove1RowUpAsBlackPlayer")]
        //[InlineDataWithName(Player.White, "8c", "8d", TestName = "BeAbleToMove1RowDownAsWhitePlayer")]
        //[InlineDataWithName(Player.Black, "8g", "8e", TestName = "BeAbleToMove2RowsUpAsBlackPlayerIfFirstMove")]
        //[InlineDataWithName(Player.White, "8c", "8e", TestName = "BeAbleToMove2RowsDownAsWhitePlayerIfFirstMove")]
        public void AllowValidMoves(Player player, string positionFrom, string positionTo)
        {
            var pawn = new Pawn(player, positionFrom);

            var isMoveLegal = pawn.IsMoveLegal(positionTo);

            Assert.True(isMoveLegal);
        }

        //[InlineDataWithName(Player.Black, "8g", new string[] {"8g8f", "8g8e"}, TestName = "AsBlackPlayer")]
        //[InlineDataWithName(Player.White, "1c", new string[] {"1c1d", "1c1e"}, TestName = "AsWhitePlayer")]
        public void KnowAllItsPossibleMoves(Player player, string position,
            IEnumerable<string> expectedPossibleMovements)
        {
            var pawn = new Pawn(player, position);

            var possibleMovements = pawn.PossibleMovements;

            Assert.Equal(expectedPossibleMovements, possibleMovements);
        }
    }
}