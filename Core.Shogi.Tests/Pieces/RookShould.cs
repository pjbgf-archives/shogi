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
            var rook = new Rook(PlayerType.Black, "2h");

            Assert.Equal('R', rook.ShortName);
        }

		[Theory]
        [InlineData(PlayerType.Black, "7i", "8h")]//, TestName ="NotMoveForwardLeftAsBlackPlayer")]
        [InlineData(PlayerType.White, "7a", "6b")]//, TestName ="NotMoveForwardLeftAsWhitePlayer")]
        [InlineData(PlayerType.Black, "5e", "6f")]//, TestName ="NotBackLeftAsBlackPlayer")]
        [InlineData(PlayerType.White, "5e", "4d")]//, TestName ="NotBackLeftAsWhitePlayer")]
        [InlineData(PlayerType.Black, "5e", "4f")]//, TestName ="NotBackRightAsBlackPlayer")]
        [InlineData(PlayerType.White, "5e", "6d")]//, TestName ="NotBackRightAsWhitePlayer")]
        [InlineData(PlayerType.Black, "7i", "6h")]//, TestName ="NotMoveForwardRightAsBlackPlayer")]
        [InlineData(PlayerType.White, "7a", "8b")]//, TestName ="NotMoveForwardRightAsWhitePlayer")]
        public void NotAllowIllegalMoves(PlayerType player, string positionFrom, string positionTo)
        {
            var rook = new Rook(player, positionFrom);

            var isMoveLegal = rook.IsMoveLegal(positionTo);

            Assert.False(isMoveLegal);
        }

		[Theory]
        [InlineData(PlayerType.Black, "5e", "9e")]//, TestName ="BeAbleToMoveToInRangeToLeftAsBlackPlayer")]
        [InlineData(PlayerType.Black, "5e", "1e")]//, TestName ="BeAbleToMoveToInRangeToRightAsBlackPlayer")]
        [InlineData(PlayerType.Black, "5e", "5a")]//, TestName ="BeAbleToMoveToInRangeToForwardAsBlackPlayer")]
        [InlineData(PlayerType.Black, "5e", "5i")]//, TestName ="BeAbleToMoveToInRangeToBackAsBlackPlayer")]
        [InlineData(PlayerType.White, "5e", "1e")]//, TestName ="BeAbleToMoveToInRangeToLeftAsWhitePlayer")]
        [InlineData(PlayerType.White, "5e", "9e")]//, TestName ="BeAbleToMoveToInRangeToRightAsWhitePlayer")]
        [InlineData(PlayerType.White, "5e", "5i")]//, TestName ="BeAbleToMoveToInRangeToForwardAsWhitePlayer")]
        [InlineData(PlayerType.White, "5e", "5a")]//, TestName ="BeAbleToMoveToInRangeToBackAsWhitePlayer")]
        public void AllowValidMoves(PlayerType player, string positionFrom, string positionTo)
        {
            var rook = new Rook(player, positionFrom);

            var isMoveLegal = rook.IsMoveLegal(positionTo);

            Assert.True(isMoveLegal);
        }

		[Theory]
        [InlineData(PlayerType.Black, "5e", new string[] {"5e5d", "5e5c", "5e5b", "5e5a", "5e5f", "5e5g", "5e5h", "5e5i", "5e4e", "5e3e", "5e2e", "5e1e", "5e6e", "5e7e", "5e8e", "5e9e"})]//"AsBlackPlayer"
        [InlineData(PlayerType.White, "5e", new string[] {"5e5d", "5e5c", "5e5b", "5e5a", "5e5f", "5e5g", "5e5h", "5e5i", "5e4e", "5e3e", "5e2e", "5e1e", "5e6e", "5e7e", "5e8e", "5e9e"})]//"AsWhitePlayer"
        public void KnowAllItsPossibleMoves(PlayerType player, string position,
            IEnumerable<string> expectedPossibleMovements)
        {
            var rook = new Rook(player, position);

            var possibleMovements = rook.PossibleMovements;

            Assert.Equal(expectedPossibleMovements, possibleMovements);
        }
    }
}