using System.Text.RegularExpressions;
using Core.Shogi.Pieces;

namespace Core.Shogi
{
    public class Board
    {
        readonly BoardState _boardState = new BoardState();
        public Player CurrentTurn = Player.Black;

        public Board()
        {
            ResetBoard();
        }

        //TODO: Tell Don't Ask!
        public BoardState State => _boardState;

        public Board(BoardState boardState, Player currentTurn) : this()
        {
            _boardState = boardState;
            CurrentTurn = currentTurn;
        }

        public void ResetBoard()
        {
            CurrentTurn = Player.Black;
            _boardState.Reset();
        }

        //TODO: Refactoring to keep right level of abstraction
        public virtual BoardResult Move(Player player, string fromPosition, string toPosition)
        {
            if (!Regex.IsMatch(toPosition, "^[1-9]{1}[a-i]{1}$", RegexOptions.Compiled | RegexOptions.CultureInvariant))
                return BoardResult.InvalidOperation;

            if (player != CurrentTurn)
                return BoardResult.NotPlayersTurn;

            var piece = _boardState.GetPiece(fromPosition);
            if (player != piece.OwnerPlayer)
                return BoardResult.NotPlayersPiece;

            var targetPiece = _boardState.GetPiece(toPosition);
            if (piece.IsMoveLegal(toPosition) && (targetPiece == null || targetPiece?.OwnerPlayer != player))
            {
                piece.Move(toPosition);

                _boardState.Remove(fromPosition);
                _boardState.Add(piece);

                return BoardResult.ValidOperation;
            }

            return BoardResult.InvalidOperation;
        }
    }
}