using NUnit.Framework;

namespace Core.Shogi.Tests.BitBoard
{
    [TestFixture]
    public class BinaryShould
    {
        [Test]
        public void CanCastImplicitlyFromString0001()
        {
            BitboardRow row = "0001";
            ushort expected = 1;

            Assert.AreEqual(expected, row.Value);
        }

        [Test]
        public void CanCastImplicitlyFromString0010()
        {
            BitboardRow row = "0010";
            ushort expected = 2;

            Assert.AreEqual(expected, row.Value);
        }
    }
}