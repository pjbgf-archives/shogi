using System.Collections.Generic;
using Core.Shogi.Pieces;
using Xunit;

namespace Core.Shogi.Tests.Pieces
{
    
    public class PawnShould
    {
        [Fact]
        public void Have_P_AsShortName()
        {
            var pawn = new Pawn(Player.Black, "1g");

            Assert.Equal('P', pawn.ShortName);
        }

        [Theory]
        [InlineData(Player.Black, "1g", "1h")] 
        [InlineData(Player.White, "1c", "1b")] 
        [InlineData(Player.Black, "5g", "6g")] 
        [InlineData(Player.White, "5c", "4c")] 
        [InlineData(Player.Black, "5g", "4g")] 
        [InlineData(Player.White, "5c", "6c")] 
        [InlineData(Player.Black, "5g", "6h")] 
        [InlineData(Player.White, "5c", "4b")] 
        [InlineData(Player.Black, "5g", "4h")] 
        [InlineData(Player.White, "5c", "6b")] 
        [InlineData(Player.Black, "5g", "6f")] 
        [InlineData(Player.White, "5c", "4d")] 
        [InlineData(Player.Black, "5g", "4f")] 
        [InlineData(Player.White, "5c", "6d")] 
        public void NotAllowIllegalMoves(Player player, string positionFrom, string positionTo)
        {
            var pawn = new Pawn(player, positionFrom);

            var isMoveLegal = pawn.IsMoveLegal(positionTo);

            Assert.False(isMoveLegal);
        }

        [Theory]
        [InlineData(Player.Black, "8g", "8f")] 
        [InlineData(Player.White, "8c", "8d")] 
        [InlineData(Player.Black, "8g", "8e")] 
        [InlineData(Player.White, "8c", "8e")] 
        public void AllowValidMoves(Player player, string positionFrom, string positionTo)
        {
            var pawn = new Pawn(player, positionFrom);

            var isMoveLegal = pawn.IsMoveLegal(positionTo);

            Assert.True(isMoveLegal);
        }

        [Theory]
        [InlineData(Player.Black, "8g", new string[] { "8g8f", "8g8e" })] 
        [InlineData(Player.White, "1c", new string[] { "1c1d", "1c1e" })] 
        public void KnowAllItsPossibleMoves(Player player, string position,
            IEnumerable<string> expectedPossibleMovements)
        {
            var pawn = new Pawn(player, position);

            var possibleMovements = pawn.PossibleMovements;

            Assert.Equal(expectedPossibleMovements, possibleMovements);
        }
    }
}