using Core.Shogi.Pieces;
using Xunit;

namespace Core.Shogi.Tests.Pieces
{
    
    public class GoldShould
    {
        [Fact]
        public void Have_G_AsShortName()
        {
            var gold = new Gold(Player.Black, "6i");

            Assert.Equal('G', gold.ShortName);
        }

        //[InlineDataWithName(Player.Black, "5e", "6f", TestName = "NotMoveBackLeftAsBlackPlayer")]
        //[InlineDataWithName(Player.Black, "5e", "4f", TestName = "NotMoveBackRightAsBlackPlayer")]
        //[InlineDataWithName(Player.White, "5e", "4d", TestName = "NotMoveBackLeftAsWhitePlayer")]
        //[InlineDataWithName(Player.White, "5e", "6d", TestName = "NotMoveBackRightAsWhitePlayer")]
        public void NotAllowIllegalMoves(Player player, string positionFrom, string positionTo)
        {
            var gold = new Gold(player, positionFrom);

            var isMoveLegal = gold.IsMoveLegal(positionTo);

            Assert.False(isMoveLegal);
        }

        //[InlineDataWithName(Player.Black, "7i", "7h", TestName = "BeAbleToMoveForwardAsBlackPlayer")]
        //[InlineDataWithName(Player.White, "7a", "7b", TestName = "BeAbleToMoveForwardAsWhitePlayer")]
        //[InlineDataWithName(Player.Black, "7i", "8h", TestName = "BeAbleToMoveForwardLeftAsBlackPlayer")]
        //[InlineDataWithName(Player.White, "7a", "6b", TestName = "BeAbleToMoveForwardLeftAsWhitePlayer")]
        //[InlineDataWithName(Player.Black, "7i", "6h", TestName = "BeAbleToMoveForwardRightAsBlackPlayer")]
        //[InlineDataWithName(Player.White, "7a", "8b", TestName = "BeAbleToMoveForwardRightAsWhitePlayer")]
        //[InlineDataWithName(Player.Black, "6h", "6i", TestName = "BeAbleToMoveBackAsBlackPlayer")]
        //[InlineDataWithName(Player.White, "6b", "6a", TestName = "BeAbleToMoveBackAsWhitePlayer")]
        public void AllowValidMoves(Player player, string positionFrom, string positionTo)
        {
            var gold = new Gold(player, positionFrom);

            var isMoveLegal = gold.IsMoveLegal(positionTo);

            Assert.True(isMoveLegal);
        }
    }
}