using Core.Shogi.Pieces;
using Xunit;

namespace Core.Shogi.Tests.Pieces
{

    public class KnightShould
    {
        [Fact]
        public void Have_N_AsShortName()
        {
            var knight = new Knight(PlayerType.Black, "8i");

            Assert.Equal('N', knight.ShortName);
        }

        [Theory]
        [InlineData("NotMoveForwardAsBlackPlayer", PlayerType.Black, "7i", "7h")]
        [InlineData("NotMoveForwardAsWhitePlayer", PlayerType.White, "7a", "7b")]
        [InlineData("NotMoveForwardLeftAsBlackPlayer", PlayerType.Black, "7i", "8h")]
        [InlineData("NotMoveForwardLeftAsWhitePlayer", PlayerType.White, "7a", "6b")]
        [InlineData("NotBackLeftAsBlackPlayer", PlayerType.Black, "5e", "6f")]
        [InlineData("NotBackLeftAsWhitePlayer", PlayerType.White, "5e", "4d")]
        [InlineData("NotMoveBackAsBlackPlayer", PlayerType.Black, "6h", "6i")]
        [InlineData("NotMoveBackAsWhitePlayer", PlayerType.White, "6b", "6a")]
        [InlineData("NotBackRightAsBlackPlayer", PlayerType.Black, "5e", "4f")]
        [InlineData("NotBackRightAsWhitePlayer", PlayerType.White, "5e", "6d")]
        [InlineData("NotMoveForwardRightAsBlackPlayer", PlayerType.Black, "7i", "6h")]
        [InlineData("NotMoveForwardRightAsWhitePlayer", PlayerType.White, "7a", "8b")]
        public void NotAllowIllegalMoves(string testName, PlayerType player, string positionFrom, string positionTo)
        {
            var knight = new Knight(player, positionFrom);

            var isMoveLegal = knight.IsMoveLegal(positionTo);

            Assert.False(isMoveLegal);
        }

        [Theory]
        [InlineData("BeAbleToMoveInLShapeToTheLeftAsBlackPlayer", PlayerType.Black, "8i", "9g")]
        [InlineData("BeAbleToMoveInLShapeToTheRightAsBlackPlayer", PlayerType.Black, "8i", "7g")]
        public void AllowValidMoves(string testName, PlayerType player, string positionFrom, string positionTo)
        {
            var knight = new Knight(player, positionFrom);

            var isMoveLegal = knight.IsMoveLegal(positionTo);

            Assert.True(isMoveLegal);
        }
    }
}