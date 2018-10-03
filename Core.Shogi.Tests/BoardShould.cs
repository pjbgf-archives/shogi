using Core.Shogi.FullVersion;
using Core.Shogi.Pieces;
using Xunit;

namespace Core.Shogi.Tests
{
    public class BoardShould
    {
        [Fact]
        public void NotAllowWhiteToPlayFirst()
        {
            var board = new Board();

            var result = board.Move(Player.White, "1c", "1d");

            Assert.Equal(BoardResult.NotPlayersTurn, result);
        }

        [Fact]
        public void NotAllowBlackToMoveWhitesPiece()
        {
            var board = new Board();

            var result = board.Move(Player.Black, "1c", "1d");

            Assert.Equal(BoardResult.NotPlayersPiece, result);
        }

        [Fact]
        public void NotAllowPlayerToMoveIntoAPositionFilledBySamePlayer()
        {
            var board = new Board();

            var result = board.Move(Player.Black, "2h", "2g");

            Assert.Equal(BoardResult.InvalidOperation, result);
        }

        [Fact]
        public void NotAllowPlayerToMoveIntoNonExistentColumn()
        {
            var board = new Board();

            var result = board.Move(Player.Black, "9i", "10i");

            Assert.Equal(BoardResult.InvalidOperation, result);
        }

        [Fact]
        public void NotAllowPlayerToMoveIntoNonExistentRow()
        {
            var board = new Board();

            var result = board.Move(Player.Black, "5i", "5j");

            Assert.Equal(BoardResult.InvalidOperation, result);
        }

        [Fact]
        public void AllowPlayerToMakeLegalMove()
        {
            var board = new Board();

            var result = board.Move(Player.Black, "1g", "1f");

            Assert.Equal(BoardResult.ValidOperation, result);
        }

        [Fact]
        public void AllowPlayerToCaptureOpponentPiece()
        {
            var boardState = new BoardState();
            boardState.Add(new Pawn(Player.White, "1f"));
            boardState.Add(new Pawn(Player.Black, "1g"));
            var board = new Board(boardState, Player.Black);

            var result = board.Move(Player.Black, "1g", "1f");

            Assert.Equal(BoardResult.ValidOperation, result);
        }

        [Fact]
        public void UpdateCurrentPlayerAfterValidMove()
        {
            var board = new Board();

            board.Move(Player.Black, "1g", "1f");

            Assert.Equal(Player.White, board.CurrentPlayer);
        }
    }
}