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

        //[InlineDataWithName(Player.Black, "7i", "7h", TestName = "BeAbleToMoveForwardAsBlackPlayer")]
        //[InlineDataWithName(Player.White, "7a", "7b", TestName = "BeAbleToMoveForwardAsWhitePlayer")]
        //[InlineDataWithName(Player.Black, "7i", "8h", TestName = "BeAbleToMoveForwardLeftAsBlackPlayer")]
        //[InlineDataWithName(Player.White, "7a", "6b", TestName = "BeAbleToMoveForwardLeftAsWhitePlayer")]
        //[InlineDataWithName(Player.Black, "5e", "6f", TestName = "BeAbleToMoveBackLeftAsBlackPlayer")]
        //[InlineDataWithName(Player.White, "5e", "4d", TestName = "BeAbleToMoveBackLeftAsWhitePlayer")]
        //[InlineDataWithName(Player.Black, "6h", "6i", TestName = "BeAbleToMoveBackAsBlackPlayer")]
        //[InlineDataWithName(Player.White, "6b", "6a", TestName = "BeAbleToMoveBackAsWhitePlayer")]
        //[InlineDataWithName(Player.Black, "5e", "4f", TestName = "BeAbleToBackRightAsBlackPlayer")]
        //[InlineDataWithName(Player.White, "5e", "6d", TestName = "BeAbleToBackRightAsWhitePlayer")]
        //[InlineDataWithName(Player.Black, "7i", "6h", TestName = "BeAbleToMoveForwardRightAsBlackPlayer")]
        //[InlineDataWithName(Player.White, "7a", "8b", TestName = "BeAbleToMoveForwardRightAsWhitePlayer")]
        //[InlineDataWithName(Player.Black, "5e", "6e", TestName = "BeAbleToMoveLeftAsBlackPlayer")]
        //[InlineDataWithName(Player.White, "5e", "4e", TestName = "BeAbleToMoveLeftAsWhitePlayer")]
        //[InlineDataWithName(Player.Black, "5e", "4e", TestName = "BeAbleToMoveRightAsBlackPlayer")]
        //[InlineDataWithName(Player.White, "5e", "6e", TestName = "BeAbleToMoveRightAsWhitePlayer")]
        public void AllowValidMoves(Player player, string positionFrom, string positionTo)
        {
            var king = new King(player, positionFrom);

            var isMoveLegal = king.IsMoveLegal(positionTo);

            Assert.True(isMoveLegal);
        }

        //[InlineDataWithName(Player.Black, "5e", new string[] {"5e5d", "5e5f", "5e4e", "5e6e", "5e6d", "5e4d", "5e6f", "5e4f"},
        //     TestName = "AsBlackPlayer")]
        //[InlineDataWithName(Player.White, "5e", new string[] {"5e5d", "5e5f", "5e4e", "5e6e", "5e6d", "5e4d", "5e6f", "5e4f"},
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