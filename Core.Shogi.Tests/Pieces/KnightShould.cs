using Core.Shogi.Pieces;
using NUnit.Framework;

namespace Core.Shogi.Tests.Pieces
{
    [TestFixture]
    public class KnightShould
    {
        [Test]
        public void Have_N_AsShortName()
        {
            var knight = new Knight(Player.Black, "8i");

            Assert.AreEqual('N', knight.ShortName);
        }

        [TestCase(Player.Black, "7i", "7h", TestName = "NotMoveForwardAsBlackPlayer")]
        [TestCase(Player.White, "7a", "7b", TestName = "NotMoveForwardAsWhitePlayer")]
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
            var knight = new Knight(player, positionFrom);

            var isMoveLegal = knight.IsMoveLegal(positionTo);

            Assert.IsFalse(isMoveLegal);
        }

        [TestCase(Player.Black, "8i", "9g", TestName = "BeAbleToMoveInLShapeToTheLeftAsBlackPlayer")]
        [TestCase(Player.Black, "8i", "7g", TestName = "BeAbleToMoveInLShapeToTheRightAsBlackPlayer")]
        public void AllowValidMoves(Player player, string positionFrom, string positionTo)
        {
            var knight = new Knight(player, positionFrom);

            var isMoveLegal = knight.IsMoveLegal(positionTo);

            Assert.IsTrue(isMoveLegal);
        }
    }
}