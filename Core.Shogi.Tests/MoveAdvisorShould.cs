using System.Collections.Generic;
using Core.Shogi.Pieces;
using NUnit.Framework;

namespace Core.Shogi.Tests
{
    [TestFixture]
    public class MoveAdvisorShould
    {
        readonly Dictionary<string, Piece> _boardState = new Dictionary<string, Piece>(81);

        [SetUp]
        public void BeforeEachTest()
        {
            _boardState.Clear();
        }

        [Test]
        public void MoveToCheckMateIfPossible()
        {
            _boardState.Add("1c", new King(Player.White, "1c"));
            _boardState.Add("1b", new Lance(Player.White, "1b"));
            _boardState.Add("1d", new Pawn(Player.White, "1d"));
            _boardState.Add("5c", new Bishop(Player.Black, "5c"));
            _boardState.Add("2e", new Lance(Player.Black, "2e"));

            var moveAdvisor = new MoveAdvisor(_boardState, Player.Black);
            var bestMove = moveAdvisor.GetBestMove();

            Assert.AreEqual("3a", bestMove);
        }
    }
}