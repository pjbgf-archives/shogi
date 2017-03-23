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

		[Theory]
        [InlineData(Player.Black, "7i", "8h")]//, TestName ="NotMoveForwardLeftAsBlackPlayer")]
        [InlineData(Player.White, "7a", "6b")]//, TestName ="NotMoveForwardLeftAsWhitePlayer")]
        [InlineData(Player.Black, "5e", "6f")]//, TestName ="NotBackLeftAsBlackPlayer")]
        [InlineData(Player.White, "5e", "4d")]//, TestName ="NotBackLeftAsWhitePlayer")]
        [InlineData(Player.Black, "5e", "4f")]//, TestName ="NotBackRightAsBlackPlayer")]
        [InlineData(Player.White, "5e", "6d")]//, TestName ="NotBackRightAsWhitePlayer")]
        [InlineData(Player.Black, "7i", "6h")]//, TestName ="NotMoveForwardRightAsBlackPlayer")]
        [InlineData(Player.White, "7a", "8b")]//, TestName ="NotMoveForwardRightAsWhitePlayer")]
        public void NotAllowIllegalMoves(Player player, string positionFrom, string positionTo)
        {
            var rook = new Rook(player, positionFrom);

            var isMoveLegal = rook.IsMoveLegal(positionTo);

            Assert.False(isMoveLegal);
        }

		[Theory]
        [InlineData(Player.Black, "5e", "9e")]//, TestName ="BeAbleToMoveToInRangeToLeftAsBlackPlayer")]
        [InlineData(Player.Black, "5e", "1e")]//, TestName ="BeAbleToMoveToInRangeToRightAsBlackPlayer")]
        [InlineData(Player.Black, "5e", "5a")]//, TestName ="BeAbleToMoveToInRangeToForwardAsBlackPlayer")]
        [InlineData(Player.Black, "5e", "5i")]//, TestName ="BeAbleToMoveToInRangeToBackAsBlackPlayer")]
        [InlineData(Player.White, "5e", "1e")]//, TestName ="BeAbleToMoveToInRangeToLeftAsWhitePlayer")]
        [InlineData(Player.White, "5e", "9e")]//, TestName ="BeAbleToMoveToInRangeToRightAsWhitePlayer")]
        [InlineData(Player.White, "5e", "5i")]//, TestName ="BeAbleToMoveToInRangeToForwardAsWhitePlayer")]
        [InlineData(Player.White, "5e", "5a")]//, TestName ="BeAbleToMoveToInRangeToBackAsWhitePlayer")]
        public void AllowValidMoves(Player player, string positionFrom, string positionTo)
        {
            var rook = new Rook(player, positionFrom);

            var isMoveLegal = rook.IsMoveLegal(positionTo);

            Assert.True(isMoveLegal);
        }

		[Theory]
        [InlineData(Player.Black, "5e", new string[] {"5e5d", "5e5c", "5e5b", "5e5a", "5e5f", "5e5g", "5e5h", "5e5i", "5e4e", "5e3e", "5e2e", "5e1e", "5e6e", "5e7e", "5e8e", "5e9e"})]//"AsBlackPlayer"
        [InlineData(Player.White, "5e", new string[] {"5e5d", "5e5c", "5e5b", "5e5a", "5e5f", "5e5g", "5e5h", "5e5i", "5e4e", "5e3e", "5e2e", "5e1e", "5e6e", "5e7e", "5e8e", "5e9e"})]//"AsWhitePlayer"
        public void KnowAllItsPossibleMoves(Player player, string position,
            IEnumerable<string> expectedPossibleMovements)
        {
            var rook = new Rook(player, position);

            var possibleMovements = rook.PossibleMovements;

            Assert.Equal(expectedPossibleMovements, possibleMovements);
        }
    }
}