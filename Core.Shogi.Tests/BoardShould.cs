using NUnit.Framework;

namespace Core.Shogi.Tests
{
    [TestFixture]
    public class BoardShould
    {
        [Test]
        public void NotAllowWhiteToPlayFirst()
        {
            var board = new Board();

            var result = board.Move(Player.White, "1c", "1d");

            Assert.AreEqual(BoardResult.NotPlayersTurn, result);
        }

        [Test]
        public void NotAllowBlackToMoveWhitesPiece()
        {
            var board = new Board();

            var result = board.Move(Player.Black, "1c", "1d");

            Assert.AreEqual(BoardResult.NotPlayersPiece, result);
        }

        [Test]
        public void NotAllowPlayerToMoveIntoAPositionFilledBySamePlayer()
        {
            var board = new Board();

            var result = board.Move(Player.Black, "2h", "2g");

            Assert.AreEqual(BoardResult.InvalidOperation, result);
        }

        [Test]
        public void NotAllowPlayerToMoveIntoNonExistentColumn()
        {
            var board = new Board();

            var result = board.Move(Player.Black, "9i", "10i");

            Assert.AreEqual(BoardResult.InvalidOperation, result);
        }

        [Test]
        public void NotAllowPlayerToMoveIntoNonExistentRow()
        {
            var board = new Board();

            var result = board.Move(Player.Black, "5i", "5j");

            Assert.AreEqual(BoardResult.InvalidOperation, result);
        }

        [Test]
        public void AllowPlayerToMakeLegalMove()
        {
            var board = new Board();

            var result = board.Move(Player.Black, "1g", "1f");

            Assert.AreEqual(BoardResult.ValidOperation, result);
        }

        [Test]
        [Ignore("Some design considerations needed to get this test done")]
        public void AllowPlayerToCaptureOpponentPiece()
        {
        }

        [Test]
        [Ignore("Some design considerations needed to get this test done")]
        public void NotAllowPlayerToCaptureOwnPiece()
        {
        }

        [Test]
        public void UpdateCurrentPlayerAfterValidMove()
        {
            var board = new Board();

            board.Move(Player.Black, "1g", "1f");

            Assert.AreEqual(Player.White, board.CurrentPlayer);
        }
    }
}