using NSubstitute;
using NUnit.Framework;

namespace Core.Shogi.Tests
{
    [TestFixture]
    public class BoardShould
    {
        private IBoardRender _boardRenderMock;
        private IBoardInput _blackPlayer;
        private IBoardInput _whitePlayer;

        [SetUp]
        public void BeforeEachTest()
        {
            _boardRenderMock = Substitute.For<IBoardRender>();
            _blackPlayer = Substitute.For<IBoardInput>();
            _whitePlayer = Substitute.For<IBoardInput>();
        }

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
            board.StartGame();

            var result = board.Move(Player.Black, "1c", "1d");

            Assert.AreEqual(BoardResult.NotPlayersPiece, result);
        }

        [Test]
        public void NotAllowPlayerToMoveIntoAPositionFilledBySamePlayer()
        {
            var board = new Board();
            board.StartGame();

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
            board.StartGame();

            var result = board.Move(Player.Black, "1g", "1f");

            Assert.AreEqual(BoardResult.ValidOperation, result);
        }

        [Test]
        public void AllowPlayerToCapturePieces()
        {
            var board = new Board();
            board.StartGame();

            var result = board.Move(Player.Black, "1g", "1f");

            Assert.AreEqual(BoardResult.ValidOperation, result);
        }

        [Test]
        public void RenderItSelfOnStart()
        {
            var board = new Board(_boardRenderMock, _blackPlayer, _whitePlayer);

            board.StartGame();

            _boardRenderMock.Received(1).Refresh(Arg.Any<BoardState>());
        }

        [Test]
        public void RenderItSelfAfterMove()
        {
            var board = new Board(_boardRenderMock, _blackPlayer, _whitePlayer);

            board.StartGame();
            board.Move(Player.Black, "1g", "1f");

            _boardRenderMock.Received(2).Refresh(Arg.Any<BoardState>());
        }

        [Test]
        public void AskBlackPlayerMoveAfterStart()
        {
            var board = new Board(_boardRenderMock, _blackPlayer, _whitePlayer);

            board.StartGame();

            _blackPlayer.Received(1).AskForNextMove();
        }

        [Test]
        public void ChangeCurrentPlayerTurnAfterMove()
        {
            _blackPlayer.AskForNextMove().Returns("1g1f");
            var board = new Board(_boardRenderMock, _blackPlayer, _whitePlayer);

            board.StartGame();

            _blackPlayer.WhenForAnyArgs(x => x.AskForNextMove()).Do(x =>
                        Assert.AreEqual(Player.White, board.CurrentTurn)
            );
        }
    }
}