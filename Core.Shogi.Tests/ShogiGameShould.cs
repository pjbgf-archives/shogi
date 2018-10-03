using NSubstitute;
using Xunit;

namespace Core.Shogi.Tests
{
    public class ShogiGameShould
    {
        private readonly IBoardRender _boardRenderMock;
        private readonly IBoard _boardMock;

        public ShogiGameShould()
        {
            _boardRenderMock = Substitute.For<IBoardRender>();
            _boardMock = Substitute.For<IBoard>();
        }

        [Fact]
        public void ResetBoardOnStart()
        {
            var shogiGame = new ShogiGame(_boardRenderMock, null, null, _boardMock);

            shogiGame.Start();

            _boardMock.Received(1).Reset();
        }

        [Fact]
        public void RenderBoardOnStart()
        {
            var shogiGame = new ShogiGame(_boardRenderMock, null, null, _boardMock);

            shogiGame.Start();

            _boardRenderMock.ReceivedWithAnyArgs(1).Refresh(Arg.Any<IBoardState>());
        }
    }
}