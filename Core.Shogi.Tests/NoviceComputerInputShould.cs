using System.Collections.Generic;
using Core.Shogi.Pieces;
using NUnit.Framework;

namespace Core.Shogi.Tests
{
    [TestFixture]
    public class NoviceComputerInputShould
    {
        readonly BoardState _boardState = new BoardState();

        [SetUp]
        public void BeforeEachTest()
        {
            _boardState.Clear();
        }

        [Test]
        public void MoveToCheckMateIfPossible()
        {
            _boardState.Add(new King(Player.White, "1c"));
            _boardState.Add(new Lance(Player.White, "1b"));
            _boardState.Add(new Pawn(Player.White, "1d"));
            _boardState.Add(new Bishop(Player.Black, "5c"));
            _boardState.Add(new Lance(Player.Black, "2e"));

            var moveAdvisor = new Shogi.NoviceComputerInput(_boardState, Player.Black);
            var bestMove = moveAdvisor.AskForNextMove();

            Assert.AreEqual("3a", bestMove);
        }
    }
}