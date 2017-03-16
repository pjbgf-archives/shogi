using System.Collections.Generic;
using Core.Shogi.Pieces;
using Xunit;

namespace Core.Shogi.Tests.Pieces
{
    
    public class BishopShould
    {
        [Fact]
        public void DescribeSimpleMovements()
        {
            var bishop = new Bishop(Player.Black, "8h");
            string moveDescription = bishop.Move("6f");

            Assert.Equal("B8h-6f", moveDescription);
        }

        //[InlineDataWithName(Player.Black, "1g", "1h", TestName = "NotMoveBackwardAsBlackPlayer")]
        //[InlineDataWithName(Player.White, "1c", "1b", TestName = "NotMoveBackwardAsWhitePlayer")]
        //[InlineDataWithName(Player.Black, "5g", "6g", TestName = "NotMoveLeftAsBlackPlayer")]
        //[InlineDataWithName(Player.White, "5c", "4c", TestName = "NotMoveLeftAsWhitePlayer")]
        //[InlineDataWithName(Player.Black, "5g", "4g", TestName = "NotMoveRightAsBlackPlayer")]
        //[InlineDataWithName(Player.White, "5c", "6c", TestName = "NotMoveRightAsWhitePlayer")]
        //[InlineDataWithName(Player.Black, "8g", "8f", TestName = "NotMoveForwardAsBlackPlayer")]
        //[InlineDataWithName(Player.White, "8c", "8d", TestName = "NotMoveForwardAsWhitePlayer")]
        public void NotAllowIllegalMoves(Player player, string positionFrom, string positionTo)
        {
            var bishop = new Bishop(player, positionFrom);

            var isMoveLegal = bishop.IsMoveLegal(positionTo);

            Assert.False(isMoveLegal);
        }

        //[InlineDataWithName(Player.Black, "5e", "9a", TestName = "BeAbleToMoveFromCentreToTopLeftCornerAsBlackPlayer")]
        //[InlineDataWithName(Player.White, "5e", "1i", TestName = "BeAbleToMoveFromCentreToTopLeftCornerAsWhitePlayer")]
        //[InlineDataWithName(Player.Black, "5e", "1a", TestName = "BeAbleToMoveFromCentreToTopRightCornerAsBlackPlayer")]
        //[InlineDataWithName(Player.White, "5e", "9i", TestName = "BeAbleToMoveFromCentreToTopRightCornerAsWhitePlayer")]
        //[InlineDataWithName(Player.Black, "5e", "9i", TestName = "BeAbleToMoveFromCentreToBottomLeftCornerAsBlackPlayer")]
        //[InlineDataWithName(Player.White, "5e", "1a", TestName = "BeAbleToMoveFromCentreToBottomLeftCornerAsWhitePlayer")]
        //[InlineDataWithName(Player.Black, "5e", "1i", TestName = "BeAbleToMoveFromCentreToBottomRightCornerAsBlackPlayer")]
        //[InlineDataWithName(Player.White, "5e", "9a", TestName = "BeAbleToMoveFromCentreToBottomRightCornerAsWhitePlayer")]
        public void AllowValidMoves(Player player, string positionFrom, string positionTo)
        {
            var bishop = new Bishop(player, positionFrom);

            var isMoveLegal = bishop.IsMoveLegal(positionTo);

            Assert.True(isMoveLegal);
        }

        //[InlineDataWithName(Player.Black, "5e",
        //     new string[]
        //     {
        //         "5e4d", "5e6f", "5e4f", "5e6d", "5e3c", "5e7g", "5e3g", "5e7c", "5e2b", "5e8h", "5e2h", "5e8b", "5e1a",
        //         "5e9i", "5e1i", "5e9a"
        //     },
        //     TestName = "AsBlackPlayerFromCentreOfBoard")]
        //[InlineDataWithName(Player.White, "5e",
        //     new string[]
        //     {
        //         "5e4d", "5e6f", "5e4f", "5e6d", "5e3c", "5e7g", "5e3g", "5e7c", "5e2b", "5e8h", "5e2h", "5e8b", "5e1a",
        //         "5e9i", "5e1i", "5e9a"
        //     },
        //     TestName = "AsWhitePlayerFromCentreOfBoard")]
        //[InlineDataWithName(Player.Black, "8c",
        //     new string[] {"8c7b", "8c9d", "8c7d", "8c9b", "8c6a", "8c6e", "8c5f", "8c4g", "8c3h", "8c2i"},
        //     TestName = "AsBlackPlayerFromNonSimmetricLocation")]
        public void KnowAllItsPossibleMoves(Player player, string position,
            IEnumerable<string> expectedPossibleMovements)
        {
            var bishop = new Bishop(player, position);

            var possibleMovements = bishop.PossibleMovements;

            Assert.Equal(expectedPossibleMovements, possibleMovements);
        }
    }
}