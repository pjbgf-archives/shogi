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
        [InlineData(Player.Black, "5e", "6f")] 
        [InlineData(Player.Black, "5e", "4f")] 
        [InlineData(Player.White, "5e", "4d")] 
        [InlineData(Player.White, "5e", "6d")] 
        public void NotAllowIllegalMoves(Player player, string positionFrom, string positionTo)
        {
            var gold = new Gold(player, positionFrom);

            var isMoveLegal = gold.IsMoveLegal(positionTo);

            Assert.False(isMoveLegal);
        }

        [Theory]
        [InlineData(Player.Black, "7i", "7h")] 
        [InlineData(Player.White, "7a", "7b")] 
        [InlineData(Player.Black, "7i", "8h")] 
        [InlineData(Player.White, "7a", "6b")] 
        [InlineData(Player.Black, "7i", "6h")] 
        [InlineData(Player.White, "7a", "8b")] 
        [InlineData(Player.Black, "6h", "6i")] 
        [InlineData(Player.White, "6b", "6a")] 
        public void AllowValidMoves(Player player, string positionFrom, string positionTo)
        {
            var gold = new Gold(player, positionFrom);

            var isMoveLegal = gold.IsMoveLegal(positionTo);

            Assert.True(isMoveLegal);
        }
    }
}