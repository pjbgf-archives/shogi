using NUnit.Framework;

namespace Core.Shogi.Tests
{
    [TestFixture]
    public class PawnShould
    {
        [Test]
        public void HavePAsShortName()
        {
            var pawn = new Pawn(Player.Black, "1g");
            
            Assert.AreEqual('P', pawn.ShortName);
        }

        [Test]
        public void NotMoveBackwardsAsBlackPlayer()
        {
            var pawn = new Pawn(Player.Black, "1g");

            var isMoveLegal = pawn.IsMoveLegal("1h");

            Assert.IsFalse(isMoveLegal);
        }

        [Test]
        public void NotMoveBackwardsAsWhitePlayer()
        {
            var pawn = new Pawn(Player.White, "1c");

            var isMoveLegal = pawn.IsMoveLegal("1b");

            Assert.IsFalse(isMoveLegal);
        }

        [Test]
        public void NotToTheLeftAsWhitePlayer()
        {
            var pawn = new Pawn(Player.White, "5c");

            var isMoveLegal = pawn.IsMoveLegal("4c");

            Assert.IsFalse(isMoveLegal);
        }

        [Test]
        public void NotToTheLeftAsBlackPlayer()
        {
            var pawn = new Pawn(Player.White, "5g");

            var isMoveLegal = pawn.IsMoveLegal("6g");

            Assert.IsFalse(isMoveLegal);
        }

        [Test]
        public void BeAbleToMove1RowUpAsBlackPlayer()
        {
            var pawn = new Pawn(Player.Black, "8g");

            var isMoveLegal = pawn.IsMoveLegal("8f");

            Assert.IsTrue(isMoveLegal);
        }

        [Test]
        public void BeAbleToMove2RowsUpAsBlackPlayerIfFirstMove()
        {
            var pawn = new Pawn(Player.Black, "8g");

            var isMoveLegal = pawn.IsMoveLegal("8e");

            Assert.IsTrue(isMoveLegal);
        }

        [Test]
        public void BeAbleToMove1RowDownAsWhitePlayer()
        {
            var pawn = new Pawn(Player.White, "8c");

            var isMoveLegal = pawn.IsMoveLegal("8d");

            Assert.IsTrue(isMoveLegal);
        }

        [Test]
        public void BeAbleToMove2RowsDownAsWhitePlayerIfFirstMove()
        {
            var pawn = new Pawn(Player.White, "8c");

            var isMoveLegal = pawn.IsMoveLegal("8e");

            Assert.IsTrue(isMoveLegal);
        }
    }
}
