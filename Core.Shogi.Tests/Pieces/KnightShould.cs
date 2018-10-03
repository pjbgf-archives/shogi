using Core.Shogi.Pieces;
using Xunit;

namespace Core.Shogi.Tests.Pieces
{

    public class KnightShould
    {
        [Fact]
        public void Have_N_AsShortName()
        {
            var knight = new Knight(Player.Black, "8i");

            Assert.Equal('N', knight.ShortName);
        }

        [Theory]
        [InlineData("NotMoveForwardAsBlackPlayer", Player.Black, "7i", "7h")]
        [InlineData("NotMoveForwardAsWhitePlayer", Player.White, "7a", "7b")]
        [InlineData("NotMoveForwardLeftAsBlackPlayer", Player.Black, "7i", "8h")]
        [InlineData("NotMoveForwardLeftAsWhitePlayer", Player.White, "7a", "6b")]
        [InlineData("NotBackLeftAsBlackPlayer", Player.Black, "5e", "6f")]
        [InlineData("NotBackLeftAsWhitePlayer", Player.White, "5e", "4d")]
        [InlineData("NotMoveBackAsBlackPlayer", Player.Black, "6h", "6i")]
        [InlineData("NotMoveBackAsWhitePlayer", Player.White, "6b", "6a")]
        [InlineData("NotBackRightAsBlackPlayer", Player.Black, "5e", "4f")]
        [InlineData("NotBackRightAsWhitePlayer", Player.White, "5e", "6d")]
        [InlineData("NotMoveForwardRightAsBlackPlayer", Player.Black, "7i", "6h")]
        [InlineData("NotMoveForwardRightAsWhitePlayer", Player.White, "7a", "8b")]
        public void NotAllowIllegalMoves(string testName, Player player, string positionFrom, string positionTo)
        {
            var knight = new Knight(player, positionFrom);

            var isMoveLegal = knight.IsMoveLegal(positionTo);

            Assert.False(isMoveLegal);
        }

        [Theory]
        [InlineData("BeAbleToMoveInLShapeToTheLeftAsBlackPlayer", Player.Black, "8i", "9g")]
        [InlineData("BeAbleToMoveInLShapeToTheRightAsBlackPlayer", Player.Black, "8i", "7g")]
        public void AllowValidMoves(string testName, Player player, string positionFrom, string positionTo)
        {
            var knight = new Knight(player, positionFrom);

            var isMoveLegal = knight.IsMoveLegal(positionTo);

            Assert.True(isMoveLegal);
        }
    }
}