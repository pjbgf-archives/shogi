using System.Runtime.InteropServices;
using NUnit.Framework;

namespace Core.Shogi.Tests.BitBoard
{
    [TestFixture]
    public class BitboardStateShould
    {
        [Test]
        public void BeAbleToCalculateAvailableMoves()
        {
            var boardState = new BitboardState(
                new Bitboard(
                    "000000000",
                    "000000000",
                    "000000000",
                    "000000000",
                    "000010000",
                    "000000000",
                    "000000000",
                    "000000000",
                    "000000000"),
                new Bitboard(
                    "000000000",
                    "000000000",
                    "000000000",
                    "000100000",
                    "000000000",
                    "000000000",
                    "000000000",
                    "000000000",
                    "000000000"),
                new Bitboard(
                    "000000000",
                    "000000000",
                    "000000000",
                    "000100000",
                    "000000000",
                    "000000000",
                    "000000000",
                    "000000000",
                    "000000000"));

            var expected = boardState.WhitePieces;
            var actual = boardState.GetNextState();

            Assert.AreEqual(expected, actual);
        }
    }
}