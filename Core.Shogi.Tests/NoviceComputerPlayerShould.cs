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
            boardState.Add(new King(Player.White, "1c"));
            boardState.Add(new Lance(Player.White, "1b"));
            boardState.Add(new Pawn(Player.White, "1d"));
            boardState.Add(new Bishop(Player.Black, "5c"));
            boardState.Add(new Lance(Player.Black, "2e"));

            var board = new Board(boardState, Player.Black);

            var moveAdvisor = NoviceComputerPlayer.CreateFor(Player.Black, board);
            var bestMove = moveAdvisor.AskForNextMove();

            Assert.Equal("5c3a", bestMove);
        }

        [Fact]
        public void FavourExposedMoveToRiskOfCaptureMove()
        {
            var boardState = new BoardState();
            boardState.Add(new Pawn(Player.Black, "3g"));
            boardState.Add(new Pawn(Player.Black, "2g", false));
            boardState.Add(new Bishop(Player.White, "5c"));

            var board = new Board(boardState, Player.Black);
            var moveAdvisor = NoviceComputerPlayer.CreateFor(Player.Black, board);
            var bestMove = moveAdvisor.AskForNextMove();

            Assert.Equal("3g3f", bestMove);
        }
    }
}