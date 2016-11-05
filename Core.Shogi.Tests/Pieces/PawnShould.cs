using Core.Shogi.Pieces;
using NUnit.Framework;

namespace Core.Shogi.Tests.Pieces
{
    [TestFixture]
    public class PawnShould
    {
        [Test]
        public void Have_P_AsShortName()
        {
            var pawn = new Pawn(Player.Black, "1g");
            
            Assert.AreEqual('P', pawn.ShortName);
        }

        [TestCase(Player.Black, "1g", "1h", TestName = "NotMoveBackwardAsBlackPlayer")]
        [TestCase(Player.White, "1c", "1b", TestName = "NotMoveBackwardAsWhitePlayer")]
        [TestCase(Player.Black, "5g", "6g", TestName = "NotMoveLeftAsBlackPlayer")]
        [TestCase(Player.White, "5c", "4c", TestName = "NotMoveLeftAsWhitePlayer")]
        [TestCase(Player.Black, "5g", "4g", TestName = "NotMoveRightAsBlackPlayer")]
        [TestCase(Player.White, "5c", "6c", TestName = "NotMoveRightAsWhitePlayer")]
        [TestCase(Player.Black, "5g", "6h", TestName = "NotMoveBackLeftAsBlackPlayer")]
        [TestCase(Player.White, "5c", "4b", TestName = "NotMoveBackLeftAsWhitePlayer")]
        [TestCase(Player.Black, "5g", "4h", TestName = "NotMoveBackRightAsBlackPlayer")]
        [TestCase(Player.White, "5c", "6b", TestName = "NotMoveBackRightAsWhitePlayer")]
        [TestCase(Player.Black, "5g", "6f", TestName = "NotMoveForwardLeftAsBlackPlayer")]
        [TestCase(Player.White, "5c", "4d", TestName = "NotMoveForwardLeftAsWhitePlayer")]
        [TestCase(Player.Black, "5g", "4f", TestName = "NotMoveForwardRightAsBlackPlayer")]
        [TestCase(Player.White, "5c", "6d", TestName = "NotMoveForwardRightAsWhitePlayer")]
        public void NotAllowIllegalMoves(Player player, string positionFrom, string positionTo)
        {
            var pawn = new Pawn(player, positionFrom);

            var isMoveLegal = pawn.IsMoveLegal(positionTo);

            Assert.IsFalse(isMoveLegal);
        }

        [TestCase(Player.Black, "8g", "8f", TestName = "BeAbleToMove1RowUpAsBlackPlayer")]
        [TestCase(Player.White, "8c", "8d", TestName = "BeAbleToMove1RowDownAsWhitePlayer")]
        [TestCase(Player.Black, "8g", "8e", TestName = "BeAbleToMove2RowsUpAsBlackPlayerIfFirstMove")]
        [TestCase(Player.White, "8c", "8e", TestName = "BeAbleToMove2RowsDownAsWhitePlayerIfFirstMove")]
        public void AllowValidMoves(Player player, string positionFrom, string positionTo)
        {
            var pawn = new Pawn(player, positionFrom);

            var isMoveLegal = pawn.IsMoveLegal(positionTo);

            Assert.IsTrue(isMoveLegal);
        }
    }
}
