using NUnit.Framework;

namespace Core.Shogi.Tests
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

        [TestCase(Player.Black, "7h", "7i", TestName = "NotMoveBackwardsAsBlackPlayer")]
        [TestCase(Player.White, "7b", "7a", TestName = "NotMoveBackwardsAsWhitePlayer")]
        public void NotAllowIllegalMoves(Player player, string positionFrom, string positionTo)
        {
            var silver = new Silver(player, positionFrom);

            var isMoveLegal = silver.IsMoveLegal(positionTo);

            Assert.IsFalse(isMoveLegal);
        }

        [TestCase(Player.Black, "7i", "7h", TestName = "BeAbleToMoveForwardsAsBlackPlayer")]
        [TestCase(Player.White, "7a", "7b", TestName = "BeAbleToMoveForwardsAsWhitePlayer")]
        [TestCase(Player.Black, "7i", "8h", TestName = "BeAbleToMoveForwardsLeftAsBlackPlayer")]
        [TestCase(Player.Black, "7i", "6h", TestName = "BeAbleToMoveForwardsRightAsBlackPlayer")]
        [TestCase(Player.White, "7a", "6b", TestName = "BeAbleToMoveForwardsLeftAsWhitePlayer")]
        [TestCase(Player.White, "7a", "8b", TestName = "BeAbleToMoveForwardsRightAsWhitePlayer")]
        [TestCase(Player.Black, "5e", "6f", TestName = "BeAbleToMoveBackwardsLeftAsBlackPlayer")]
        [TestCase(Player.Black, "5e", "4f", TestName = "BeAbleToMoveBackwardsRightAsBlackPlayer")]
        [TestCase(Player.White, "5e", "4d", TestName = "BeAbleToMoveBackwardsLeftAsWhitePlayer")]
        [TestCase(Player.White, "5e", "6d", TestName = "BeAbleToMoveBackwardsRightAsWhitePlayer")]
        public void AllowValidMoves(Player player, string positionFrom, string positionTo)
        {
            var silver = new Silver(player, positionFrom);

            var isMoveLegal = silver.IsMoveLegal(positionTo);

            Assert.IsTrue(isMoveLegal);
        }
    }
}