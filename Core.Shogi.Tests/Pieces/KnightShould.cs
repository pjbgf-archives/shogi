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

        //[InlineData(Player.Black, "7i", "7h", TestName = "NotMoveForwardAsBlackPlayer")]
        //[InlineData(Player.White, "7a", "7b", TestName = "NotMoveForwardAsWhitePlayer")]
        //[InlineData(Player.Black, "7i", "8h", TestName = "NotMoveForwardLeftAsBlackPlayer")]
        //[InlineData(Player.White, "7a", "6b", TestName = "NotMoveForwardLeftAsWhitePlayer")]
        //[InlineData(Player.Black, "5e", "6f", TestName = "NotBackLeftAsBlackPlayer")]
        //[InlineData(Player.White, "5e", "4d", TestName = "NotBackLeftAsWhitePlayer")]
        //[InlineData(Player.Black, "6h", "6i", TestName = "NotMoveBackAsBlackPlayer")]
        //[InlineData(Player.White, "6b", "6a", TestName = "NotMoveBackAsWhitePlayer")]
        //[InlineData(Player.Black, "5e", "4f", TestName = "NotBackRightAsBlackPlayer")]
        //[InlineData(Player.White, "5e", "6d", TestName = "NotBackRightAsWhitePlayer")]
        //[InlineData(Player.Black, "7i", "6h", TestName = "NotMoveForwardRightAsBlackPlayer")]
        //[InlineData(Player.White, "7a", "8b", TestName = "NotMoveForwardRightAsWhitePlayer")]
        public void NotAllowIllegalMoves(Player player, string positionFrom, string positionTo)
        {
            var knight = new Knight(player, positionFrom);

            var isMoveLegal = knight.IsMoveLegal(positionTo);

            Assert.False(isMoveLegal);
        }

        //[InlineData(Player.Black, "8i", "9g", TestName = "BeAbleToMoveInLShapeToTheLeftAsBlackPlayer")]
        //[InlineData(Player.Black, "8i", "7g", TestName = "BeAbleToMoveInLShapeToTheRightAsBlackPlayer")]
        public void AllowValidMoves(Player player, string positionFrom, string positionTo)
        {
            var knight = new Knight(player, positionFrom);

            var isMoveLegal = knight.IsMoveLegal(positionTo);

            Assert.True(isMoveLegal);
        }
    }
}