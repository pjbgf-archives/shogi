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
            var silver = new Silver(Player.Black, "7i");

            Assert.Equal('S', silver.ShortName);
        }

        [Theory]
        [InlineData(Player.Black, "7h", "7i")]//"NotMoveBackAsBlackPlayer"
        [InlineData(Player.White, "7b", "7a")]//"NotMoveBackAsWhitePlayer"
        public void NotAllowIllegalMoves(Player player, string positionFrom, string positionTo)
        {
            var silver = new Silver(player, positionFrom);

            var isMoveLegal = silver.IsMoveLegal(positionTo);

            Assert.False(isMoveLegal);
        }

        [Theory]
        [InlineData(Player.Black, "7i", "7h")]//"BeAbleToMoveForwardAsBlackPlayer"
        [InlineData(Player.White, "7a", "7b")]//"BeAbleToMoveForwardAsWhitePlayer"
        [InlineData(Player.Black, "7i", "8h")]//"BeAbleToMoveForwardLeftAsBlackPlayer"
        [InlineData(Player.White, "7a", "6b")]//"BeAbleToMoveForwardLeftAsWhitePlayer"
        [InlineData(Player.Black, "7i", "6h")]//"BeAbleToMoveForwardRightAsBlackPlayer"
        [InlineData(Player.White, "7a", "8b")]//"BeAbleToMoveForwardRightAsWhitePlayer"
        [InlineData(Player.Black, "5e", "6f")]//"BeAbleToMoveBackLeftAsBlackPlayer"
        [InlineData(Player.White, "5e", "4d")]//"BeAbleToMoveBackLeftAsWhitePlayer"
        [InlineData(Player.Black, "5e", "4f")]//"BeAbleToMoveBackRightAsBlackPlayer"
        [InlineData(Player.White, "5e", "6d")]//"BeAbleToMoveBackRightAsWhitePlayer"
        public void AllowValidMoves(Player player, string positionFrom, string positionTo)
        {
            var silver = new Silver(player, positionFrom);

            var isMoveLegal = silver.IsMoveLegal(positionTo);

            Assert.True(isMoveLegal);
        }
    }
}