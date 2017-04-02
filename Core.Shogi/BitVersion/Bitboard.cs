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
            if (!Regex.IsMatch(moveDescription, "^([1-9]{1}[a-i]{1}|G\\*)+[1-9]{1}[a-i]{1}$", RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase))
                return BoardResult.InvalidOperation;

            if (moveDescription.Contains("*"))
                return BoardResult.CheckMate;

            var from = moveDescription.Substring(0, 2);
            var to = moveDescription.Substring(2, 2);

            var currentPiecePosition = BitboardPredefinedStates.PositionToState[from];
            var flippedBitsOfCurrentPosition = ~currentPiecePosition;

            FullBitboardState.BlackPieces &= flippedBitsOfCurrentPosition;
            FullBitboardState.BlackPieces ^= BitboardPredefinedStates.PositionToState[to];
            
            return BoardResult.ValidOperation;
        }
    }
}