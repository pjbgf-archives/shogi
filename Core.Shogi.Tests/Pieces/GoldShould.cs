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

        //[InlineData(Player.Black, "5e", "6f", TestName = "NotMoveBackLeftAsBlackPlayer")]
        //[InlineData(Player.Black, "5e", "4f", TestName = "NotMoveBackRightAsBlackPlayer")]
        //[InlineData(Player.White, "5e", "4d", TestName = "NotMoveBackLeftAsWhitePlayer")]
        //[InlineData(Player.White, "5e", "6d", TestName = "NotMoveBackRightAsWhitePlayer")]
        public void NotAllowIllegalMoves(Player player, string positionFrom, string positionTo)
        {
            var gold = new Gold(player, positionFrom);

            var isMoveLegal = gold.IsMoveLegal(positionTo);

            Assert.False(isMoveLegal);
        }

        //[InlineData(Player.Black, "7i", "7h", TestName = "BeAbleToMoveForwardAsBlackPlayer")]
        //[InlineData(Player.White, "7a", "7b", TestName = "BeAbleToMoveForwardAsWhitePlayer")]
        //[InlineData(Player.Black, "7i", "8h", TestName = "BeAbleToMoveForwardLeftAsBlackPlayer")]
        //[InlineData(Player.White, "7a", "6b", TestName = "BeAbleToMoveForwardLeftAsWhitePlayer")]
        //[InlineData(Player.Black, "7i", "6h", TestName = "BeAbleToMoveForwardRightAsBlackPlayer")]
        //[InlineData(Player.White, "7a", "8b", TestName = "BeAbleToMoveForwardRightAsWhitePlayer")]
        //[InlineData(Player.Black, "6h", "6i", TestName = "BeAbleToMoveBackAsBlackPlayer")]
        //[InlineData(Player.White, "6b", "6a", TestName = "BeAbleToMoveBackAsWhitePlayer")]
        public void AllowValidMoves(Player player, string positionFrom, string positionTo)
        {
            var gold = new Gold(player, positionFrom);

            var isMoveLegal = gold.IsMoveLegal(positionTo);

            Assert.True(isMoveLegal);
        }
    }
}