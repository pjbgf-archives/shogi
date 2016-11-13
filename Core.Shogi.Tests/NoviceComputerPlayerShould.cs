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
        [Ignore("Lacking implementation to make test pass.")]
        public void FavourLowerRiskMoves()
        {
            var boardState = new BoardState();
            boardState.Add(new Pawn(Player.Black, "9g"));
            boardState.Add(new Pawn(Player.Black, "8g"));
            boardState.Add(new Lance(Player.White, "9a"));

            var board = new Board(boardState, Player.Black);
            var moveAdvisor = NoviceComputerPlayer.CreateFor(Player.Black, board);
            var bestMove = moveAdvisor.AskForNextMove();

            Assert.AreEqual("8g8f", bestMove);
        }
    }
}