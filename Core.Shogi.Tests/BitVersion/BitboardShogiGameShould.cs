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
            var board = new NewBitboard(blackPlayer, whitePlayer);
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

            board.ReceivedWithAnyArgs(1).Reset();
        }
    }

    public interface IBoard
    {
        void Reset();
    }

    public class NewBitboard : IBoard
    {
        public NewBitboard(Player blackPlayer, Player whitePlayer)
        {
        }

        public void Reset()
        {

        }
    }

    public class BitboardShogiGame
    {
        private readonly IBoard _board;

        public BitboardShogiGame(IBoard board, IBoardRender render)
        {
            _board = board;
        }

        public void Start()
        {
            _board.Reset();
        }
    }
}