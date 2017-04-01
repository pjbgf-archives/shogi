using System.Text.RegularExpressions;

namespace Core.Shogi
{
    public class Board
    {
        private readonly BoardState _boardState = new BoardState();
        private readonly PlayerType _initialPlayer = PlayerType.Black;
        public PlayerType CurrentPlayer { get; private set; }

        public Board()
        {
            ResetBoard();
        }

        //TODO: Tell Don't Ask!
        public BoardState State
        {
            get
            {
                return _boardState;
            }
        }

        public Board(BoardState boardState, PlayerType currentPlayer) : this()
        {
            _boardState = boardState;
            CurrentPlayer = currentPlayer;
        }

        public void ResetBoard()
        {
            CurrentPlayer = _initialPlayer;
            _boardState.ResetToStartPosition();
        }

        //TODO: Refactor to keep right level of abstraction
        public virtual BoardResult Move(PlayerType player, string fromPosition, string toPosition)
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
                if (targetPiece != null)
                    _boardState.Remove(toPosition);

                _boardState.Add(piece);
                CurrentPlayer = (player == PlayerType.Black) ? PlayerType.White : PlayerType.Black;

                return BoardResult.ValidOperation;
            }

            return BoardResult.InvalidOperation;
        }
    }
}