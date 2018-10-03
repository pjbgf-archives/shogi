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
            var board = new Bitboard(new FullBitboardState(BitboardPredefinedStates.InitialWhitePositions, BitboardPredefinedStates.InitialBlackPositions));
            var render = Substitute.For<IBoardRender>();
            var shogi = new BitboardShogiGame(board, render);

            shogi.Start();

            board.Move(Player.Black, "7g7f");
            board.Move(Player.White, "6a7b");
            board.Move(Player.Black, "8h3c");
            board.Move(Player.White, "4a4b");
            board.Move(Player.Black, "3c4b");
            board.Move(Player.White, "5a6a");

            var result = board.Move(Player.Black, "G*5b");

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

            render.Received(1).Refresh(Arg.Any<BitboardState>());
        }
    }
}