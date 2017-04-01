using System.ComponentModel;
using Core.Shogi.Pieces;
using Xunit;

namespace Core.Shogi.Tests.Pieces
{
    public class SilverShould
    {
        [Fact]
        public void Have_P_AsShortName()
        {
            var silver = new Silver(PlayerType.Black, "7i");

            Assert.Equal('S', silver.ShortName);
        }

        [Theory]
        [InlineData(PlayerType.Black, "7h", "7i")]//"NotMoveBackAsBlackPlayer"
        [InlineData(PlayerType.White, "7b", "7a")]//"NotMoveBackAsWhitePlayer"
        public void NotAllowIllegalMoves(PlayerType player, string positionFrom, string positionTo)
        {
            var silver = new Silver(player, positionFrom);

            var isMoveLegal = silver.IsMoveLegal(positionTo);

            Assert.False(isMoveLegal);
        }

        [Theory]
        [InlineData(PlayerType.Black, "7i", "7h")]//"BeAbleToMoveForwardAsBlackPlayer"
        [InlineData(PlayerType.White, "7a", "7b")]//"BeAbleToMoveForwardAsWhitePlayer"
        [InlineData(PlayerType.Black, "7i", "8h")]//"BeAbleToMoveForwardLeftAsBlackPlayer"
        [InlineData(PlayerType.White, "7a", "6b")]//"BeAbleToMoveForwardLeftAsWhitePlayer"
        [InlineData(PlayerType.Black, "7i", "6h")]//"BeAbleToMoveForwardRightAsBlackPlayer"
        [InlineData(PlayerType.White, "7a", "8b")]//"BeAbleToMoveForwardRightAsWhitePlayer"
        [InlineData(PlayerType.Black, "5e", "6f")]//"BeAbleToMoveBackLeftAsBlackPlayer"
        [InlineData(PlayerType.White, "5e", "4d")]//"BeAbleToMoveBackLeftAsWhitePlayer"
        [InlineData(PlayerType.Black, "5e", "4f")]//"BeAbleToMoveBackRightAsBlackPlayer"
        [InlineData(PlayerType.White, "5e", "6d")]//"BeAbleToMoveBackRightAsWhitePlayer"
        public void AllowValidMoves(PlayerType player, string positionFrom, string positionTo)
        {
            var silver = new Silver(player, positionFrom);

            var isMoveLegal = silver.IsMoveLegal(positionTo);

            Assert.True(isMoveLegal);
        }
    }
}