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
    }
}