using Core.Shogi.Pieces;
using Xunit;

namespace Core.Shogi.Tests.Pieces
{
    
    public class GoldShould
    {
        [Fact]
        public void Have_G_AsShortName()
        {
            var gold = new Gold(PlayerType.Black, "6i");

            Assert.Equal('G', gold.ShortName);
        }

        [Theory]
        [InlineData(PlayerType.Black, "5e", "6f")] //"NotMoveBackLeftAsBlackPlayer")]
        [InlineData(PlayerType.Black, "5e", "4f")] //"NotMoveBackRightAsBlackPlayer")]
        [InlineData(PlayerType.White, "5e", "4d")] //"NotMoveBackLeftAsWhitePlayer")]
        [InlineData(PlayerType.White, "5e", "6d")] //"NotMoveBackRightAsWhitePlayer")]
        public void NotAllowIllegalMoves(PlayerType player, string positionFrom, string positionTo)
        {
            var gold = new Gold(player, positionFrom);

            var isMoveLegal = gold.IsMoveLegal(positionTo);

            Assert.False(isMoveLegal);
        }

        [Theory]
        [InlineData(PlayerType.Black, "7i", "7h")] //"BeAbleToMoveForwardAsBlackPlayer")]
        [InlineData(PlayerType.White, "7a", "7b")] //"BeAbleToMoveForwardAsWhitePlayer")]
        [InlineData(PlayerType.Black, "7i", "8h")] //"BeAbleToMoveForwardLeftAsBlackPlayer")]
        [InlineData(PlayerType.White, "7a", "6b")] //"BeAbleToMoveForwardLeftAsWhitePlayer")]
        [InlineData(PlayerType.Black, "7i", "6h")] //"BeAbleToMoveForwardRightAsBlackPlayer")]
        [InlineData(PlayerType.White, "7a", "8b")] //"BeAbleToMoveForwardRightAsWhitePlayer")]
        [InlineData(PlayerType.Black, "6h", "6i")] //"BeAbleToMoveBackAsBlackPlayer")]
        [InlineData(PlayerType.White, "6b", "6a")] //"BeAbleToMoveBackAsWhitePlayer")]
        public void AllowValidMoves(PlayerType player, string positionFrom, string positionTo)
        {
            var gold = new Gold(player, positionFrom);

            var isMoveLegal = gold.IsMoveLegal(positionTo);

            Assert.True(isMoveLegal);
        }
    }
}