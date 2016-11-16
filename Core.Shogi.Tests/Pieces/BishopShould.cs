using System.Collections.Generic;
using Core.Shogi.Pieces;
using NUnit.Framework;

namespace Core.Shogi.Tests.Pieces
{
    [TestFixture]
    public class BishopShould
    {
        [Test]
        public void DescribeSimpleMovements()
        {
            var bishop = new Bishop(Player.Black, "8h");
            string moveDescription = bishop.Move("6f");

            Assert.AreEqual("B8h-6f", moveDescription);
        }

        [TestCase(Player.Black, "1g", "1h", TestName = "NotMoveBackwardAsBlackPlayer")]
        [TestCase(Player.White, "1c", "1b", TestName = "NotMoveBackwardAsWhitePlayer")]
        [TestCase(Player.Black, "5g", "6g", TestName = "NotMoveLeftAsBlackPlayer")]
        [TestCase(Player.White, "5c", "4c", TestName = "NotMoveLeftAsWhitePlayer")]
        [TestCase(Player.Black, "5g", "4g", TestName = "NotMoveRightAsBlackPlayer")]
        [TestCase(Player.White, "5c", "6c", TestName = "NotMoveRightAsWhitePlayer")]
        [TestCase(Player.Black, "8g", "8f", TestName = "NotMoveForwardAsBlackPlayer")]
        [TestCase(Player.White, "8c", "8d", TestName = "NotMoveForwardAsWhitePlayer")]
        public void NotAllowIllegalMoves(Player player, string positionFrom, string positionTo)
        {
            var bishop = new Bishop(player, positionFrom);

            var isMoveLegal = bishop.IsMoveLegal(positionTo);

            Assert.IsFalse(isMoveLegal);
        }

        [TestCase(Player.Black, "5e", "9a", TestName = "BeAbleToMoveFromCentreToTopLeftCornerAsBlackPlayer")]
        [TestCase(Player.White, "5e", "1i", TestName = "BeAbleToMoveFromCentreToTopLeftCornerAsWhitePlayer")]
        [TestCase(Player.Black, "5e", "1a", TestName = "BeAbleToMoveFromCentreToTopRightCornerAsBlackPlayer")]
        [TestCase(Player.White, "5e", "9i", TestName = "BeAbleToMoveFromCentreToTopRightCornerAsWhitePlayer")]
        [TestCase(Player.Black, "5e", "9i", TestName = "BeAbleToMoveFromCentreToBottomLeftCornerAsBlackPlayer")]
        [TestCase(Player.White, "5e", "1a", TestName = "BeAbleToMoveFromCentreToBottomLeftCornerAsWhitePlayer")]
        [TestCase(Player.Black, "5e", "1i", TestName = "BeAbleToMoveFromCentreToBottomRightCornerAsBlackPlayer")]
        [TestCase(Player.White, "5e", "9a", TestName = "BeAbleToMoveFromCentreToBottomRightCornerAsWhitePlayer")]
        public void AllowValidMoves(Player player, string positionFrom, string positionTo)
        {
            var bishop = new Bishop(player, positionFrom);

            var isMoveLegal = bishop.IsMoveLegal(positionTo);

            Assert.IsTrue(isMoveLegal);
        }

        [TestCase(Player.Black, "5e", new string[] {"5e4d", "5e4f", "5e3c", "5e3g", "5e2b", "5e2h", "5e1a", "5e1i", "5e6f", "5e6d", "5e7g", "5e7c", "5e8h", "5e8b", "5e9i", "5e9a"},
             TestName = "AsBlackPlayer")]
        [TestCase(Player.White, "5e", new string[] {"5e4d", "5e4f", "5e3c", "5e3g", "5e2b", "5e2h", "5e1a", "5e1i", "5e6f", "5e6d", "5e7g", "5e7c", "5e8h", "5e8b", "5e9i", "5e9a"},
             TestName = "AsWhitePlayer")]
        public void KnowAllItsPossibleMoves(Player player, string position,
            IEnumerable<string> expectedPossibleMovements)
        {
            var bishop = new Bishop(player, position);

            var possibleMovements = bishop.PossibleMovements;

            Assert.AreEqual(expectedPossibleMovements, possibleMovements);
        }
    }
}