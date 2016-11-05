using Core.Shogi.Pieces;
using NUnit.Framework;

namespace Core.Shogi.Tests.Pieces
{
    [TestFixture]
    public class BishopShould
    {
        [Test]
        public void Have_B_AsShortName()
        {
            var bishop = new Bishop(Player.Black, "2b");

            Assert.AreEqual('B', bishop.ShortName);
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
    }
}