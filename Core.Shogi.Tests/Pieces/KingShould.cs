using System.Collections.Generic;
using Core.Shogi.Pieces;
using Xunit;

namespace Core.Shogi.Tests.Pieces
{
    
    public class KingShould
    {
        [Fact]
        public void Have_K_AsShortName()
        {
            var king = new King(Player.Black, "5i");

            Assert.Equal('K', king.ShortName);
        }

        //[InlineData(Player.Black, "7i", "7h", TestName = "BeAbleToMoveForwardAsBlackPlayer")]
        //[InlineData(Player.White, "7a", "7b", TestName = "BeAbleToMoveForwardAsWhitePlayer")]
        //[InlineData(Player.Black, "7i", "8h", TestName = "BeAbleToMoveForwardLeftAsBlackPlayer")]
        //[InlineData(Player.White, "7a", "6b", TestName = "BeAbleToMoveForwardLeftAsWhitePlayer")]
        //[InlineData(Player.Black, "5e", "6f", TestName = "BeAbleToMoveBackLeftAsBlackPlayer")]
        //[InlineData(Player.White, "5e", "4d", TestName = "BeAbleToMoveBackLeftAsWhitePlayer")]
        //[InlineData(Player.Black, "6h", "6i", TestName = "BeAbleToMoveBackAsBlackPlayer")]
        //[InlineData(Player.White, "6b", "6a", TestName = "BeAbleToMoveBackAsWhitePlayer")]
        //[InlineData(Player.Black, "5e", "4f", TestName = "BeAbleToBackRightAsBlackPlayer")]
        //[InlineData(Player.White, "5e", "6d", TestName = "BeAbleToBackRightAsWhitePlayer")]
        //[InlineData(Player.Black, "7i", "6h", TestName = "BeAbleToMoveForwardRightAsBlackPlayer")]
        //[InlineData(Player.White, "7a", "8b", TestName = "BeAbleToMoveForwardRightAsWhitePlayer")]
        //[InlineData(Player.Black, "5e", "6e", TestName = "BeAbleToMoveLeftAsBlackPlayer")]
        //[InlineData(Player.White, "5e", "4e", TestName = "BeAbleToMoveLeftAsWhitePlayer")]
        //[InlineData(Player.Black, "5e", "4e", TestName = "BeAbleToMoveRightAsBlackPlayer")]
        //[InlineData(Player.White, "5e", "6e", TestName = "BeAbleToMoveRightAsWhitePlayer")]
        public void AllowValidMoves(Player player, string positionFrom, string positionTo)
        {
            var king = new King(player, positionFrom);

            var isMoveLegal = king.IsMoveLegal(positionTo);

            Assert.True(isMoveLegal);
        }

        //[InlineData(Player.Black, "5e", new string[] {"5e5d", "5e5f", "5e4e", "5e6e", "5e6d", "5e4d", "5e6f", "5e4f"},
        //     TestName = "AsBlackPlayer")]
        //[InlineData(Player.White, "5e", new string[] {"5e5d", "5e5f", "5e4e", "5e6e", "5e6d", "5e4d", "5e6f", "5e4f"},
        //     TestName = "AsWhitePlayer")]
        public void KnowAllItsPossibleMoves(Player player, string position,
            IEnumerable<string> expectedPossibleMovements)
        {
            var king = new King(player, position);

            var possibleMovements = king.PossibleMovements;

            Assert.Equal(expectedPossibleMovements, possibleMovements);
        }
    }
}