using Core.Shogi.BitBoard;
using NUnit.Framework;

namespace Core.Shogi.Tests.BitBoard
{
    [TestFixture]
    public class BinaryShould
    {
        [Test]
        public void CanCastImplicitlyFromString0001()
        {
            BoardRow row = "0001";
            ushort expected = 1;

            Assert.AreEqual(expected, row.Value);
        }

        [Test]
        public void CanCastImplicitlyFromString0010()
        {
            BoardRow row = "0010";
            ushort expected = 2;

            Assert.AreEqual(expected, row.Value);
        }
    }
}