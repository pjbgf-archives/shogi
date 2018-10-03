using Core.Shogi.FullVersion;
using Core.Shogi.Pieces;
using Xunit;

namespace Core.Shogi.Tests.FullVersion
{
    public class BoardStateShould
    {
        [Fact]
        public void BeAbleToGetExistingPiece()
        {
            var expected = new King(Player.Black, "a1");
            var boardState = new BoardState();

            boardState.Add(expected);

            var actual = boardState.GetPiece("a1");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BeAbleToHandlePieceNotFound()
        {
            var boardState = new BoardState();

            boardState.Add(new King(Player.Black, "b2"));

            var actual = boardState.GetPiece("a1");

            Assert.Null(actual);
        }
    }
}
