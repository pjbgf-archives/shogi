using System.Collections.Generic;
using Core.Shogi.Pieces;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Core.Shogi.Tests.Pieces
{
    [TestFixture]
    public class RookShould
    {
        [Test]
        public void Have_R_AsShortName()
        {
            var rook = new Rook(Player.Black, "2h");

            Assert.AreEqual('R', rook.ShortName);
        }

        [TestCase(Player.Black, "7i", "8h", TestName = "NotMoveForwardLeftAsBlackPlayer")]
        [TestCase(Player.White, "7a", "6b", TestName = "NotMoveForwardLeftAsWhitePlayer")]
        [TestCase(Player.Black, "5e", "6f", TestName = "NotBackLeftAsBlackPlayer")]
        [TestCase(Player.White, "5e", "4d", TestName = "NotBackLeftAsWhitePlayer")]
        [TestCase(Player.Black, "5e", "4f", TestName = "NotBackRightAsBlackPlayer")]
        [TestCase(Player.White, "5e", "6d", TestName = "NotBackRightAsWhitePlayer")]
        [TestCase(Player.Black, "7i", "6h", TestName = "NotMoveForwardRightAsBlackPlayer")]
        [TestCase(Player.White, "7a", "8b", TestName = "NotMoveForwardRightAsWhitePlayer")]
        public void NotAllowIllegalMoves(Player player, string positionFrom, string positionTo)
        {
            var rook = new Rook(player, positionFrom);

            var isMoveLegal = rook.IsMoveLegal(positionTo);

            Assert.IsFalse(isMoveLegal);
        }

        [TestCase(Player.Black, "5e", "9e", TestName = "BeAbleToMoveToInRangeToLeftAsBlackPlayer")]
        [TestCase(Player.Black, "5e", "1e", TestName = "BeAbleToMoveToInRangeToRightAsBlackPlayer")]
        [TestCase(Player.Black, "5e", "5a", TestName = "BeAbleToMoveToInRangeToForwardAsBlackPlayer")]
        [TestCase(Player.Black, "5e", "5i", TestName = "BeAbleToMoveToInRangeToBackAsBlackPlayer")]
        [TestCase(Player.White, "5e", "1e", TestName = "BeAbleToMoveToInRangeToLeftAsWhitePlayer")]
        [TestCase(Player.White, "5e", "9e", TestName = "BeAbleToMoveToInRangeToRightAsWhitePlayer")]
        [TestCase(Player.White, "5e", "5i", TestName = "BeAbleToMoveToInRangeToForwardAsWhitePlayer")]
        [TestCase(Player.White, "5e", "5a", TestName = "BeAbleToMoveToInRangeToBackAsWhitePlayer")]
        public void AllowValidMoves(Player player, string positionFrom, string positionTo)
        {
            var rook = new Rook(player, positionFrom);

            var isMoveLegal = rook.IsMoveLegal(positionTo);

            Assert.IsTrue(isMoveLegal);
        }

        [TestCase(Player.Black, "5e", new string[] {"5e5d", "5e5c", "5e5b", "5e5a", "5e5f", "5e5g", "5e5h", "5e5i", "5e4e", "5e3e", "5e2e", "5e1e", "5e6e", "5e7e", "5e8e", "5e9e"},
             TestName = "AsBlackPlayer")]
        [TestCase(Player.White, "5e", new string[] {"5e5d", "5e5c", "5e5b", "5e5a", "5e5f", "5e5g", "5e5h", "5e5i", "5e4e", "5e3e", "5e2e", "5e1e", "5e6e", "5e7e", "5e8e", "5e9e"},
             TestName = "AsWhitePlayer")]
        public void KnowAllItsPossibleMoves(Player player, string position,
            IEnumerable<string> expectedPossibleMovements)
        {
            var rook = new Rook(player, position);

            var possibleMovements = rook.PossibleMovements;

            Assert.AreEqual(expectedPossibleMovements, possibleMovements);
        }
    }
}