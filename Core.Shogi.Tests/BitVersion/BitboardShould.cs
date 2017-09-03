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

            var expectedState = new BitboardState(BinaryValues.EmptyRow, BinaryValues.EmptyRow, BinaryValues.EmptyRow, BinaryValues.EmptyRow, BinaryValues.EmptyRow, 0x100, 0xFF, BinaryValues.TwoPieceRow, BinaryValues.FullRow);
            var board = new Bitboard(complexState);

            board.Move(PlayerType.Black, "9g9f");

            Assert.Equal(BitboardPredefinedStates.InitialWhitePositions, board.BitboardState.WhitePieces);
            Assert.Equal(expectedState, board.BitboardState.BlackPieces);
        }

        [Fact]
        public void NotAllowPlayerToCaptureOwnPiece()
        {
            var complexState = new FullBitboardState(
                BitboardPredefinedStates.InitialWhitePositions, BitboardPredefinedStates.InitialBlackPositions);

            var board = new Bitboard(complexState);

            var result = board.Move(PlayerType.Black, "9i9g");

            Assert.Equal(BoardResult.InvalidOperation, result);
            Assert.Equal(BitboardPredefinedStates.InitialWhitePositions, board.BitboardState.WhitePieces);
            Assert.Equal(BitboardPredefinedStates.InitialBlackPositions, board.BitboardState.BlackPieces);
        }

        [Fact]
        public void BeAbleToBeResetted()
        {
            var complexState = new FullBitboardState(new BitboardState(), new BitboardState());

            var board = new Bitboard(complexState);

            board.Reset();

            Assert.Equal(BitboardPredefinedStates.InitialWhitePositions, board.BitboardState.WhitePieces);
            Assert.Equal(BitboardPredefinedStates.InitialBlackPositions, board.BitboardState.BlackPieces);
        }
    }
}