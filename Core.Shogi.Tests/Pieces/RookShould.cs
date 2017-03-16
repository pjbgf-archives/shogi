using Core.Shogi.Pieces;
using Xunit;
using System.Collections.Generic;

namespace Core.Shogi.Tests.Pieces
{
    
    public class RookShould
    {
        [Fact]
        public void Have_R_AsShortName()
        {
            var rook = new Rook(Player.Black, "2h");

            Assert.Equal('R', rook.ShortName);
        }

		//[Theory]
  //      [InlineDataWithName(Player.Black, "7i", "8h", TestName = "NotMoveForwardLeftAsBlackPlayer")]
  //      [InlineDataWithName(Player.White, "7a", "6b", TestName = "NotMoveForwardLeftAsWhitePlayer")]
  //      [InlineDataWithName(Player.Black, "5e", "6f", TestName = "NotBackLeftAsBlackPlayer")]
  //      [InlineDataWithName(Player.White, "5e", "4d", TestName = "NotBackLeftAsWhitePlayer")]
  //      [InlineDataWithName(Player.Black, "5e", "4f", TestName = "NotBackRightAsBlackPlayer")]
  //      [InlineDataWithName(Player.White, "5e", "6d", TestName = "NotBackRightAsWhitePlayer")]
  //      [InlineDataWithName(Player.Black, "7i", "6h", TestName = "NotMoveForwardRightAsBlackPlayer")]
  //      [InlineDataWithName(Player.White, "7a", "8b", TestName = "NotMoveForwardRightAsWhitePlayer")]
        public void NotAllowIllegalMoves(Player player, string positionFrom, string positionTo)
        {
            var rook = new Rook(player, positionFrom);

            var isMoveLegal = rook.IsMoveLegal(positionTo);

            Assert.False(isMoveLegal);
        }

		//[Theory]
  //      [InlineDataWithName(Player.Black, "5e", "9e", TestName = "BeAbleToMoveToInRangeToLeftAsBlackPlayer")]
  //      [InlineDataWithName(Player.Black, "5e", "1e", TestName = "BeAbleToMoveToInRangeToRightAsBlackPlayer")]
  //      [InlineDataWithName(Player.Black, "5e", "5a", TestName = "BeAbleToMoveToInRangeToForwardAsBlackPlayer")]
  //      [InlineDataWithName(Player.Black, "5e", "5i", TestName = "BeAbleToMoveToInRangeToBackAsBlackPlayer")]
  //      [InlineDataWithName(Player.White, "5e", "1e", TestName = "BeAbleToMoveToInRangeToLeftAsWhitePlayer")]
  //      [InlineDataWithName(Player.White, "5e", "9e", TestName = "BeAbleToMoveToInRangeToRightAsWhitePlayer")]
  //      [InlineDataWithName(Player.White, "5e", "5i", TestName = "BeAbleToMoveToInRangeToForwardAsWhitePlayer")]
  //      [InlineDataWithName(Player.White, "5e", "5a", TestName = "BeAbleToMoveToInRangeToBackAsWhitePlayer")]
        public void AllowValidMoves(Player player, string positionFrom, string positionTo)
        {
            var rook = new Rook(player, positionFrom);

            var isMoveLegal = rook.IsMoveLegal(positionTo);

            Assert.True(isMoveLegal);
        }

		//[Theory]
  //      [InlineDataWithName(Player.Black, "5e", new string[] {"5e5d", "5e5c", "5e5b", "5e5a", "5e5f", "5e5g", "5e5h", "5e5i", "5e4e", "5e3e", "5e2e", "5e1e", "5e6e", "5e7e", "5e8e", "5e9e"},
  //           TestName = "AsBlackPlayer")]
  //      [InlineDataWithName(Player.White, "5e", new string[] {"5e5d", "5e5c", "5e5b", "5e5a", "5e5f", "5e5g", "5e5h", "5e5i", "5e4e", "5e3e", "5e2e", "5e1e", "5e6e", "5e7e", "5e8e", "5e9e"},
  //           TestName = "AsWhitePlayer")]
        public void KnowAllItsPossibleMoves(Player player, string position,
            IEnumerable<string> expectedPossibleMovements)
        {
            var rook = new Rook(player, position);

            var possibleMovements = rook.PossibleMovements;

            Assert.Equal(expectedPossibleMovements, possibleMovements);
        }
    }
}