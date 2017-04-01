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

        [Theory]
        [InlineData(Player.Black, "5e", "6f")] //"NotMoveBackLeftAsBlackPlayer")]
        [InlineData(Player.Black, "5e", "4f")] //"NotMoveBackRightAsBlackPlayer")]
        [InlineData(Player.White, "5e", "4d")] //"NotMoveBackLeftAsWhitePlayer")]
        [InlineData(Player.White, "5e", "6d")] //"NotMoveBackRightAsWhitePlayer")]
        public void NotAllowIllegalMoves(Player player, string positionFrom, string positionTo)
        {
            var gold = new Gold(player, positionFrom);

            var isMoveLegal = gold.IsMoveLegal(positionTo);

            Assert.False(isMoveLegal);
        }

        [Theory]
        [InlineData(Player.Black, "7i", "7h")] //"BeAbleToMoveForwardAsBlackPlayer")]
        [InlineData(Player.White, "7a", "7b")] //"BeAbleToMoveForwardAsWhitePlayer")]
        [InlineData(Player.Black, "7i", "8h")] //"BeAbleToMoveForwardLeftAsBlackPlayer")]
        [InlineData(Player.White, "7a", "6b")] //"BeAbleToMoveForwardLeftAsWhitePlayer")]
        [InlineData(Player.Black, "7i", "6h")] //"BeAbleToMoveForwardRightAsBlackPlayer")]
        [InlineData(Player.White, "7a", "8b")] //"BeAbleToMoveForwardRightAsWhitePlayer")]
        [InlineData(Player.Black, "6h", "6i")] //"BeAbleToMoveBackAsBlackPlayer")]
        [InlineData(Player.White, "6b", "6a")] //"BeAbleToMoveBackAsWhitePlayer")]
        public void AllowValidMoves(Player player, string positionFrom, string positionTo)
        {
            var gold = new Gold(player, positionFrom);

            var isMoveLegal = gold.IsMoveLegal(positionTo);

            Assert.True(isMoveLegal);
        }
    }
}