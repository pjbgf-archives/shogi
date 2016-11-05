using NUnit.Framework;

namespace Core.Shogi.Tests
{
    [TestFixture]
    public class LanceShould
    {
        [Test]
        public void HavePAsShortName()
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
    }
}