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

        //[InlineDataWithName("NotMoveBackAsBlackPlayer", Player.Black, "7h", "7i")]
        //[InlineDataWithName("NotMoveBackAsWhitePlayer", Player.White, "7b", "7a")]
        public void NotAllowIllegalMoves(Player player, string positionFrom, string positionTo)
        {
            var silver = new Silver(player, positionFrom);

            var isMoveLegal = silver.IsMoveLegal(positionTo);

            Assert.False(isMoveLegal);
        }

        //[InlineDataWithName("BeAbleToMoveForwardAsBlackPlayer", Player.Black, "7i", "7h")]
        //[InlineDataWithName("BeAbleToMoveForwardAsWhitePlayer", Player.White, "7a", "7b")]
        //[InlineDataWithName("BeAbleToMoveForwardLeftAsBlackPlayer", Player.Black, "7i", "8h")]
        //[InlineDataWithName("BeAbleToMoveForwardLeftAsWhitePlayer", Player.White, "7a", "6b")]
        //[InlineDataWithName("BeAbleToMoveForwardRightAsBlackPlayer",Player.Black, "7i", "6h")]
        //[InlineDataWithName("BeAbleToMoveForwardRightAsWhitePlayer", Player.White, "7a", "8b")]
        //[InlineDataWithName("BeAbleToMoveBackLeftAsBlackPlayer", Player.Black, "5e", "6f")]
        //[InlineDataWithName("BeAbleToMoveBackLeftAsWhitePlayer", Player.White, "5e", "4d")]
        //[InlineDataWithName("BeAbleToMoveBackRightAsBlackPlayer", Player.Black, "5e", "4f")]
        //[InlineDataWithName("BeAbleToMoveBackRightAsWhitePlayer", Player.White, "5e", "6d")]
        public void AllowValidMoves(Player player, string positionFrom, string positionTo)
        {
            var silver = new Silver(player, positionFrom);

            var isMoveLegal = silver.IsMoveLegal(positionTo);

            Assert.True(isMoveLegal);
        }
    }
}