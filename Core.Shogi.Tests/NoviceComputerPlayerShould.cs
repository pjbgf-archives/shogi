using Core.Shogi.Pieces;
using Xunit;

namespace Core.Shogi.Tests
{
    public class NoviceComputerPlayerShould
    {
        [Fact(Skip="A lot more development needed to achieve this level of evaluation.")]
        public void MoveToCheckMateIfPossible()
        {
            var boardState = new BoardState();
            boardState.Add(new King(PlayerType.White, "1c"));
            boardState.Add(new Lance(PlayerType.White, "1b"));
            boardState.Add(new Pawn(PlayerType.White, "1d"));
            boardState.Add(new Bishop(PlayerType.Black, "5c"));
            boardState.Add(new Lance(PlayerType.Black, "2e"));

            var board = new Board(boardState, PlayerType.Black);

            var moveAdvisor = NoviceComputerPlayer.CreateFor(PlayerType.Black, board);
            var bestMove = moveAdvisor.AskForNextMove();

            Assert.Equal("5c3a", bestMove);
        }

        [Fact]
        public void FavourExposedMoveToRiskOfCaptureMove()
        {
            var boardState = new BoardState();
            boardState.Add(new Pawn(PlayerType.Black, "3g"));
            boardState.Add(new Pawn(PlayerType.Black, "2g", false));
            boardState.Add(new Bishop(PlayerType.White, "5c"));

            var board = new Board(boardState, PlayerType.Black);
            var moveAdvisor = NoviceComputerPlayer.CreateFor(PlayerType.Black, board);
            var bestMove = moveAdvisor.AskForNextMove();

            Assert.Equal("3g3f", bestMove);
        }
    }
}