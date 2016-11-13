using System.Collections.Generic;
using Core.Shogi.Pieces;
using NUnit.Framework;

namespace Core.Shogi.Tests.Pieces
{
    [TestFixture]
    public class LanceShould
    {
        [Test]
        public void Have_L_AsShortName()
        {
            var lance = new Lance(Player.Black, "5i");

            Assert.AreEqual('L', lance.ShortName);
        }

        [TestCase(Player.Black, "7i", "8h", TestName = "NotMoveForwardLeftAsBlackPlayer")]
        [TestCase(Player.White, "7a", "6b", TestName = "NotMoveForwardLeftAsWhitePlayer")]
        [TestCase(Player.Black, "5e", "6f", TestName = "NotBackLeftAsBlackPlayer")]
        [TestCase(Player.White, "5e", "4d", TestName = "NotBackLeftAsWhitePlayer")]
        [TestCase(Player.Black, "6h", "6i", TestName = "NotMoveBackAsBlackPlayer")]
        [TestCase(Player.White, "6b", "6a", TestName = "NotMoveBackAsWhitePlayer")]
        [TestCase(Player.Black, "5e", "4f", TestName = "NotBackRightAsBlackPlayer")]
        [TestCase(Player.White, "5e", "6d", TestName = "NotBackRightAsWhitePlayer")]
        [TestCase(Player.Black, "7i", "6h", TestName = "NotMoveForwardRightAsBlackPlayer")]
        [TestCase(Player.White, "7a", "8b", TestName = "NotMoveForwardRightAsWhitePlayer")]
        public void NotAllowIllegalMoves(Player player, string positionFrom, string positionTo)
        {
            var lance = new Lance(player, positionFrom);

            var isMoveLegal = lance.IsMoveLegal(positionTo);

            Assert.IsFalse(isMoveLegal);
        }

        [TestCase(Player.Black, "7i", "7h", TestName = "BeAbleToMoveForward1RowAsBlackPlayer")]
        [TestCase(Player.Black, "7i", "7g", TestName = "BeAbleToMoveForward2RowsAsBlackPlayer")]
        [TestCase(Player.Black, "7i", "7f", TestName = "BeAbleToMoveForward3RowsAsBlackPlayer")]
        [TestCase(Player.Black, "7i", "7e", TestName = "BeAbleToMoveForward4RowsAsBlackPlayer")]
        [TestCase(Player.Black, "7i", "7d", TestName = "BeAbleToMoveForward5RowsAsBlackPlayer")]
        [TestCase(Player.Black, "7i", "7c", TestName = "BeAbleToMoveForward6RowsAsBlackPlayer")]
        [TestCase(Player.Black, "7i", "7b", TestName = "BeAbleToMoveForward7RowsAsBlackPlayer")]
        [TestCase(Player.Black, "7i", "7a", TestName = "BeAbleToMoveForward8RowsAsBlackPlayer")]
        [TestCase(Player.White, "7a", "7b", TestName = "BeAbleToMoveForward1RowAsWhitePlayer")]
        [TestCase(Player.White, "7a", "7c", TestName = "BeAbleToMoveForward2RowsAsWhitePlayer")]
        [TestCase(Player.White, "7a", "7d", TestName = "BeAbleToMoveForward3RowsAsWhitePlayer")]
        [TestCase(Player.White, "7a", "7e", TestName = "BeAbleToMoveForward4RowsAsWhitePlayer")]
        [TestCase(Player.White, "7a", "7f", TestName = "BeAbleToMoveForward5RowsAsWhitePlayer")]
        [TestCase(Player.White, "7a", "7g", TestName = "BeAbleToMoveForward6RowsAsWhitePlayer")]
        [TestCase(Player.White, "7a", "7h", TestName = "BeAbleToMoveForward7RowsAsWhitePlayer")]
        [TestCase(Player.White, "7a", "7i", TestName = "BeAbleToMoveForward8RowsAsWhitePlayer")]
        public void AllowValidMoves(Player player, string positionFrom, string positionTo)
        {
            var lance = new Lance(player, positionFrom);

            var isMoveLegal = lance.IsMoveLegal(positionTo);

            Assert.IsTrue(isMoveLegal);
        }

        [TestCase(Player.Black, "9i", new string[] {"9i9h", "9i9g", "9i9f", "9i9e", "9i9d", "9i9c", "9i9b", "9i9a"},
             TestName = "AsBlackPlayer")]
        [TestCase(Player.White, "1a", new string[] {"1a1b", "1a1c", "1a1d", "1a1e", "1a1f", "1a1g", "1a1h", "1a1i"},
             TestName = "AsWhitePlayer")]
        public void KnowAllItsPossibleMoves(Player player, string position,
            IEnumerable<string> expectedPossibleMovements)
        {
            var lance = new Lance(player, position);

            var possibleMovements = lance.GetPossibleMovements();

            Assert.AreEqual(expectedPossibleMovements, possibleMovements);
        }
    }
}