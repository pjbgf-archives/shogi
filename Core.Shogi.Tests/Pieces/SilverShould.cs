using Core.Shogi.Pieces;
using NUnit.Framework;

namespace Core.Shogi.Tests.Pieces
{
    [TestFixture]
    public class SilverShould
    {
        [Test]
        public void HavePAsShortName()
        {
            var silver = new Silver(Player.Black, "7i");

            Assert.AreEqual('S', silver.ShortName);
        }

        [TestCase(Player.Black, "7h", "7i", TestName = "NotMoveBackAsBlackPlayer")]
        [TestCase(Player.White, "7b", "7a", TestName = "NotMoveBackAsWhitePlayer")]
        public void NotAllowIllegalMoves(Player player, string positionFrom, string positionTo)
        {
            var silver = new Silver(player, positionFrom);

            var isMoveLegal = silver.IsMoveLegal(positionTo);

            Assert.IsFalse(isMoveLegal);
        }

        [TestCase(Player.Black, "7i", "7h", TestName = "BeAbleToMoveForwardAsBlackPlayer")]
        [TestCase(Player.White, "7a", "7b", TestName = "BeAbleToMoveForwardAsWhitePlayer")]
        [TestCase(Player.Black, "7i", "8h", TestName = "BeAbleToMoveForwardLeftAsBlackPlayer")]
        [TestCase(Player.White, "7a", "6b", TestName = "BeAbleToMoveForwardLeftAsWhitePlayer")]
        [TestCase(Player.Black, "7i", "6h", TestName = "BeAbleToMoveForwardRightAsBlackPlayer")]
        [TestCase(Player.White, "7a", "8b", TestName = "BeAbleToMoveForwardRightAsWhitePlayer")]
        [TestCase(Player.Black, "5e", "6f", TestName = "BeAbleToMoveBackLeftAsBlackPlayer")]
        [TestCase(Player.White, "5e", "4d", TestName = "BeAbleToMoveBackLeftAsWhitePlayer")]
        [TestCase(Player.Black, "5e", "4f", TestName = "BeAbleToMoveBackRightAsBlackPlayer")]
        [TestCase(Player.White, "5e", "6d", TestName = "BeAbleToMoveBackRightAsWhitePlayer")]
        public void AllowValidMoves(Player player, string positionFrom, string positionTo)
        {
            var silver = new Silver(player, positionFrom);

            var isMoveLegal = silver.IsMoveLegal(positionTo);

            Assert.IsTrue(isMoveLegal);
        }
    }
}