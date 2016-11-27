using System.Runtime.InteropServices;
using NUnit.Framework;

namespace Core.Shogi.Tests.BitBoard
{
    [TestFixture]
    public class BitboardStateShould
    {
        [Test]
        public void BeAbleToCalculateMoveCapturingPiece()
        {
            var boardState = new BitboardState(
                new Bitboard(0, 0, 0,           0, "000010000", 0, 0, 0, 0),
                new Bitboard(0, 0, 0, "000100000",           0, 0, 0, 0, 0),
                new Bitboard(0, 0, 0,           0, "000010000", 0, 0, 0, 0));

            var expected = boardState.WhitePieces;
            var actual = boardState.GetNextState();

            Assert.AreEqual(expected, actual);
        }
    }
}