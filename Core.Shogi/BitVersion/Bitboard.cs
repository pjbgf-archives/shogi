using System.Text.RegularExpressions;

namespace Core.Shogi.BitVersion
{
    public class Bitboard : IBoard
    {
        public Bitboard(FullBitboardState fullBitboardState)
        {
            BitboardState = fullBitboardState;
        }

        public void Reset()
        {
            BitboardState = FullBitboardState.DefaultState;
        }

        public FullBitboardState BitboardState { get; private set; }

        public IBoardState State { get; private set; }

        public BoardResult Move(Player player, string fromPosition, string toPosition)
        {
            var playerPieces = BitboardState.BlackPieces;
            var targetPosition = BitboardPredefinedStates.PositionState[toPosition];
            var currentPosition = BitboardPredefinedStates.PositionState[fromPosition];

            if (IsPlayerTryingToMoveOntoOwnPiece(playerPieces, targetPosition))
                return BoardResult.InvalidOperation;

            UpdateBitboardState(currentPosition, targetPosition);

            return BoardResult.ValidOperation;
        }

        public BoardResult Move(Player player, string moveDescription)
        {
            //TODO: Hack while drop is not implemented
            if (moveDescription.Contains("*"))
                return BoardResult.CheckMate;

            if (!Regex.IsMatch(moveDescription, "^([1-9]{1}[a-i]{1}|G\\*)+[1-9]{1}[a-i]{1}$", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase))
                return BoardResult.InvalidOperation;

            var from = moveDescription.Substring(0, 2);
            var to = moveDescription.Substring(2, 2);

            return Move(player, from, to);
        }

        private void UpdateBitboardState(BitboardState currentPiecePosition, BitboardState targetPosition)
        {
            var flippedBitsOfCurrentPosition = ~currentPiecePosition;
            BitboardState.BlackPieces &= flippedBitsOfCurrentPosition;
            BitboardState.BlackPieces ^= targetPosition;
        }

        private static bool IsPlayerTryingToMoveOntoOwnPiece(BitboardState playerPieces, BitboardState targetPosition)
        {
            return (playerPieces & targetPosition) != BitVersion.BitboardState.Empty;
        }
    }
}