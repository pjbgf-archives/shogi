using Core.Shogi.Pieces;
using NUnit.Framework;

namespace Core.Shogi.Tests.Pieces
{
    [TestFixture]
    public class GoldShould
    {
        [Test]
        public void Have_G_AsShortName()
        {
            var gold = new Gold(Player.Black, "6i");

            Assert.AreEqual('G', gold.ShortName);
        }

        [TestCase(Player.Black, "5e", "6f", TestName = "NotMoveBackLeftAsBlackPlayer")]
        [TestCase(Player.Black, "5e", "4f", TestName = "NotMoveBackRightAsBlackPlayer")]
        [TestCase(Player.White, "5e", "4d", TestName = "NotMoveBackLeftAsWhitePlayer")]
        [TestCase(Player.White, "5e", "6d", TestName = "NotMoveBackRightAsWhitePlayer")]
        public void NotAllowIllegalMoves(Player player, string positionFrom, string positionTo)
        {
            var gold = new Gold(player, positionFrom);

            var isMoveLegal = gold.IsMoveLegal(positionTo);

            Assert.IsFalse(isMoveLegal);
        }

        [TestCase(Player.Black, "7i", "7h", TestName = "BeAbleToMoveForwardAsBlackPlayer")]
        [TestCase(Player.White, "7a", "7b", TestName = "BeAbleToMoveForwardAsWhitePlayer")]
        [TestCase(Player.Black, "7i", "8h", TestName = "BeAbleToMoveForwardLeftAsBlackPlayer")]
        [TestCase(Player.White, "7a", "6b", TestName = "BeAbleToMoveForwardLeftAsWhitePlayer")]
        [TestCase(Player.Black, "7i", "6h", TestName = "BeAbleToMoveForwardRightAsBlackPlayer")]
        [TestCase(Player.White, "7a", "8b", TestName = "BeAbleToMoveForwardRightAsWhitePlayer")]
        [TestCase(Player.Black, "6h", "6i", TestName = "BeAbleToMoveBackAsBlackPlayer")]
        [TestCase(Player.White, "6b", "6a", TestName = "BeAbleToMoveBackAsWhitePlayer")]
        public void AllowValidMoves(Player player, string positionFrom, string positionTo)
        {
            var gold = new Gold(player, positionFrom);

            var isMoveLegal = gold.IsMoveLegal(positionTo);

            Assert.IsTrue(isMoveLegal);
        }
    }
}