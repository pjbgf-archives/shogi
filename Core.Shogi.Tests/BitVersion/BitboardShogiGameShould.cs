using Core.Shogi.BitVersion;
using NSubstitute;
using Xunit;

namespace Core.Shogi.Tests.BitVersion
{
    public class BitboardShogiGameShould
    {
        [Fact]
        public void IdentifyACheckMateState()
        {
            var blackPlayer = new Player(PlayerType.Black);
            var whitePlayer = new Player(PlayerType.White);
            var board = new Bitboard(blackPlayer, whitePlayer);
            var render = Substitute.For<IBoardRender>();
            var shogi = new BitboardShogiGame(board, render);

            shogi.Start();

            blackPlayer.Move("7g7f");
            whitePlayer.Move("6a7b");
            blackPlayer.Move("8h3c");
            whitePlayer.Move("4a4b");
            blackPlayer.Move("3c4b");
            whitePlayer.Move("5a6a");

            var result = blackPlayer.Move("G*5b");

            Assert.Equal(BoardResult.CheckMate, result);
        }

        [Fact]
        public void EnsureBoardIsResetAtStartOfGame()
        {
            var board = Substitute.For<IBoard>();
            var render = Substitute.For<IBoardRender>();
            var shogi = new BitboardShogiGame(board, render);

            shogi.Start();

            board.Received(1).Reset();
        }

        [Fact]
        public void RenderBoardAtStartOfGame()
        {
            var board = Substitute.For<IBoard>();
            var render = Substitute.For<IBoardRender>();
            var shogi = new BitboardShogiGame(board, render);

            shogi.Start();

            render.Received(1).Refresh(Arg.Any<BoardState>());
        }
    }
}