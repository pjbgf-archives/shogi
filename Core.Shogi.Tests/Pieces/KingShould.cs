using Core.Shogi.Pieces;
using NUnit.Framework;

namespace Core.Shogi.Tests.Pieces
{
    [TestFixture]
    public class KingShould
    {
        [Test]
        public void Have_K_AsShortName()
        {
            var king = new King(Player.Black, "5i");

            Assert.AreEqual('K', king.ShortName);
        }

        public void NotAllowIllegalMoves(Player player, string positionFrom, string positionTo)
        {
            var king = new King(player, positionFrom);

            var isMoveLegal = king.IsMoveLegal(positionTo);

            Assert.IsFalse(isMoveLegal);
        }

        [TestCase(Player.Black, "7i", "7h", TestName = "BeAbleToMoveForwardAsBlackPlayer")]
        [TestCase(Player.White, "7a", "7b", TestName = "BeAbleToMoveForwardAsWhitePlayer")]
        [TestCase(Player.Black, "7i", "8h", TestName = "BeAbleToMoveForwardLeftAsBlackPlayer")]
        [TestCase(Player.White, "7a", "6b", TestName = "BeAbleToMoveForwardLeftAsWhitePlayer")]
        [TestCase(Player.Black, "5e", "6f", TestName = "BeAbleToBackLeftAsBlackPlayer")]
        [TestCase(Player.White, "5e", "4d", TestName = "BeAbleToBackLeftAsWhitePlayer")]
        [TestCase(Player.Black, "6h", "6i", TestName = "BeAbleToMoveBackAsBlackPlayer")]
        [TestCase(Player.White, "6b", "6a", TestName = "BeAbleToMoveBackAsWhitePlayer")]
        [TestCase(Player.Black, "5e", "4f", TestName = "BeAbleToBackRightAsBlackPlayer")]
        [TestCase(Player.White, "5e", "6d", TestName = "BeAbleToBackRightAsWhitePlayer")]
        [TestCase(Player.Black, "7i", "6h", TestName = "BeAbleToMoveForwardRightAsBlackPlayer")]
        [TestCase(Player.White, "7a", "8b", TestName = "BeAbleToMoveForwardRightAsWhitePlayer")]
        public void AllowValidMoves(Player player, string positionFrom, string positionTo)
        {
            var king = new King(player, positionFrom);

            var isMoveLegal = king.IsMoveLegal(positionTo);

            Assert.IsTrue(isMoveLegal);
        }
    }
}