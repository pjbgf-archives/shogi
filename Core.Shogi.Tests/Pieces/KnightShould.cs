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

        //[InlineDataWithName(Player.Black, "7i", "7h", TestName = "NotMoveForwardAsBlackPlayer")]
        //[InlineDataWithName(Player.White, "7a", "7b", TestName = "NotMoveForwardAsWhitePlayer")]
        //[InlineDataWithName(Player.Black, "7i", "8h", TestName = "NotMoveForwardLeftAsBlackPlayer")]
        //[InlineDataWithName(Player.White, "7a", "6b", TestName = "NotMoveForwardLeftAsWhitePlayer")]
        //[InlineDataWithName(Player.Black, "5e", "6f", TestName = "NotBackLeftAsBlackPlayer")]
        //[InlineDataWithName(Player.White, "5e", "4d", TestName = "NotBackLeftAsWhitePlayer")]
        //[InlineDataWithName(Player.Black, "6h", "6i", TestName = "NotMoveBackAsBlackPlayer")]
        //[InlineDataWithName(Player.White, "6b", "6a", TestName = "NotMoveBackAsWhitePlayer")]
        //[InlineDataWithName(Player.Black, "5e", "4f", TestName = "NotBackRightAsBlackPlayer")]
        //[InlineDataWithName(Player.White, "5e", "6d", TestName = "NotBackRightAsWhitePlayer")]
        //[InlineDataWithName(Player.Black, "7i", "6h", TestName = "NotMoveForwardRightAsBlackPlayer")]
        //[InlineDataWithName(Player.White, "7a", "8b", TestName = "NotMoveForwardRightAsWhitePlayer")]
        public void NotAllowIllegalMoves(Player player, string positionFrom, string positionTo)
        {
            var knight = new Knight(player, positionFrom);

            var isMoveLegal = knight.IsMoveLegal(positionTo);

            Assert.False(isMoveLegal);
        }

        //[InlineDataWithName(Player.Black, "8i", "9g", TestName = "BeAbleToMoveInLShapeToTheLeftAsBlackPlayer")]
        //[InlineDataWithName(Player.Black, "8i", "7g", TestName = "BeAbleToMoveInLShapeToTheRightAsBlackPlayer")]
        public void AllowValidMoves(Player player, string positionFrom, string positionTo)
        {
            var knight = new Knight(player, positionFrom);

            var isMoveLegal = knight.IsMoveLegal(positionTo);

            Assert.True(isMoveLegal);
        }
    }
}