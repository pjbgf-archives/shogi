using NSubstitute;
using NUnit.Framework;

namespace Core.Shogi.Tests
{
    [TestFixture]
    public class ShogiGameShould
    {
        private IBoardRender _boardRenderMock;
        private IBoardInput _blackPlayerMock;
        private IBoardInput _whitePlayerMock;
        private Board _boardMock;

        [SetUp]
        public void BeforeEachTest()
        {
            _boardRenderMock = Substitute.For<IBoardRender>();
            _blackPlayerMock = Substitute.For<IBoardInput>();
            _whitePlayerMock = Substitute.For<IBoardInput>();
            _boardMock = Substitute.For<Board>();
        }

        [Test]
        public void ResetTheBoardOnStart()
        {
            var shogiGame = new ShogiGame(_boardRenderMock, _blackPlayerMock, _whitePlayerMock, _boardMock);

            shogiGame.Start();

            _boardMock.Received(1).ResetBoard();
        }
    }
}