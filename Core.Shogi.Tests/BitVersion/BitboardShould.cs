using Core.Shogi.BitVersion;
using Xunit;

namespace Core.Shogi.Tests.BitVersion
{
    public class BitboardShould
    {
        [Fact]
        public void NotAcceptInvalidInput()
        {
            var complexState = new FullBitboardState(
                BitboardPredefinedStates.InitialWhitePositions, BitboardPredefinedStates.InitialBlackPositions);

            var board = new Bitboard(complexState);

            var actualResult = board.Move(PlayerType.Black, "352176");
            Assert.Equal(BoardResult.InvalidOperation, actualResult);
        }

        [Fact]
        public void UpdateBitboardStateForValidMoves()
        {
            var complexState = new FullBitboardState(
                BitboardPredefinedStates.InitialWhitePositions, BitboardPredefinedStates.InitialBlackPositions);

            var expectedState = new BitboardState(HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, 0x100, 0xFF, HexValues.TwoPieceRow, HexValues.FullRow);
            var board = new Bitboard(complexState);

            board.Move(PlayerType.Black, "9g9f");

            Assert.Equal(BitboardPredefinedStates.InitialWhitePositions, board.FullBitboardState.WhitePieces);
            Assert.Equal(expectedState, board.FullBitboardState.BlackPieces);
        }

        [Fact]
        public void NotAllowPlayerToCaptureOwnPiece()
        {
            var complexState = new FullBitboardState(
                BitboardPredefinedStates.InitialWhitePositions, BitboardPredefinedStates.InitialBlackPositions);

            var board = new Bitboard(complexState);

            var result = board.Move(PlayerType.Black, "9i9g");

            Assert.Equal(BoardResult.InvalidOperation, result);
            Assert.Equal(BitboardPredefinedStates.InitialWhitePositions, board.FullBitboardState.WhitePieces);
            Assert.Equal(BitboardPredefinedStates.InitialBlackPositions, board.FullBitboardState.BlackPieces);
        }
    }
}