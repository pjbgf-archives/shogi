using System.Text.RegularExpressions;

namespace Core.Shogi
{
    public class Board
    {
        readonly BoardState _boardState = new BoardState();
        public Player CurrentPlayer = Player.Black;

        public Board()
        {
            ResetBoard();
        }

        //TODO: Tell Don't Ask!
        public BoardState State => _boardState;

        public Board(BoardState boardState, Player currentPlayer) : this()
        {
            _boardState = boardState;
            CurrentPlayer = currentPlayer;
        }

        public void ResetBoard()
        {
            CurrentPlayer = Player.Black;
            _boardState.Reset();
        }

        //TODO: Refactoring to keep right level of abstraction
        public virtual BoardResult Move(Player player, string fromPosition, string toPosition)
        {
            if (!Regex.IsMatch(toPosition, "^[1-9]{1}[a-i]{1}$", RegexOptions.Compiled | RegexOptions.CultureInvariant))
                return BoardResult.InvalidOperation;

            if (player != CurrentPlayer)
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
                CurrentPlayer = (player == Player.Black) ? Player.White : Player.Black;

                return BoardResult.ValidOperation;
            }

            return BoardResult.InvalidOperation;
        }
    }
}