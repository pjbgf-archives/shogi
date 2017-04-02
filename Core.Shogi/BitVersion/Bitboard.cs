using System.Text.RegularExpressions;

namespace Core.Shogi.BitVersion
{
    public class Bitboard : IBoard
    {
        public Bitboard(FullBitboardState fullBitboardState)
        {
            FullBitboardState = fullBitboardState;
        }

        public void Reset()
        {

        }

        public FullBitboardState FullBitboardState { get; }

        public BoardResult Move(PlayerType player, string moveDescription)
        {
            //TODO: Hack while drop is not implemented
            if (moveDescription.Contains("*"))
                return BoardResult.CheckMate;

            if (!Regex.IsMatch(moveDescription, "^([1-9]{1}[a-i]{1}|G\\*)+[1-9]{1}[a-i]{1}$", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase))
                return BoardResult.InvalidOperation;

            var from = moveDescription.Substring(0, 2);
            var to = moveDescription.Substring(2, 2);

            var playerPieces = FullBitboardState.BlackPieces;
            var targetPosition = BitboardPredefinedStates.PositionState[to];
            var currentPosition = BitboardPredefinedStates.PositionState[from];

            if (IsPlayerTryingToMoveOntoOwnPiece(playerPieces, targetPosition))
                return BoardResult.InvalidOperation;

            UpdateBitboardState(currentPosition, targetPosition);

            return BoardResult.ValidOperation;
        }

        private void UpdateBitboardState(BitboardState currentPiecePosition, BitboardState targetPosition)
        {
            var flippedBitsOfCurrentPosition = ~currentPiecePosition;
            FullBitboardState.BlackPieces &= flippedBitsOfCurrentPosition;
            FullBitboardState.BlackPieces ^= targetPosition;
        }

        private static bool IsPlayerTryingToMoveOntoOwnPiece(BitboardState playerPieces, BitboardState targetPosition)
        {
            return (playerPieces & targetPosition) != BitboardState.Empty;
        }
    }
}