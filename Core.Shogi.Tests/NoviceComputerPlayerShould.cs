using Core.Shogi.Pieces;
using NUnit.Framework;

namespace Core.Shogi.Tests
{
    [TestFixture]
    public class NoviceComputerPlayerShould
    {
        [Test]
        [Ignore("A lot more development needed to achieve this level of evaluation.")]
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

            Assert.AreEqual("5c3a", bestMove);
        }

        [Test]
        [Ignore("NoviceComputerPlayer needs to assess movement values in order for this to run.")]
        public void FavourLowerRiskMoves()
        {
            var boardState = new BoardState();
            boardState.Add(new Pawn(Player.Black, "3g"));
            boardState.Add(new Pawn(Player.Black, "2g", false));
            boardState.Add(new Bishop(Player.White, "5c"));

            var board = new Board(boardState, Player.Black);
            var moveAdvisor = NoviceComputerPlayer.CreateFor(Player.Black, board);
            var bestMove = moveAdvisor.AskForNextMove();

            Assert.AreEqual("3g3f", bestMove);
        }
    }
}