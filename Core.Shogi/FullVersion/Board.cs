using System.Text.RegularExpressions;

namespace Core.Shogi.FullVersion
{
    public class Board : IBoard
    {
        private readonly BoardState _boardState = new BoardState();
        private readonly Player _initialPlayer = Player.Black;
        public Player CurrentPlayer { get; private set; }

        public Board()
        {
            Reset();
        }
        
        public IBoardState State
        {
            get
            {
                return _boardState;
            }
        }

        public Board(BoardState boardState, Player currentPlayer) : this()
        {
            _boardState = boardState;
            CurrentPlayer = currentPlayer;
        }

        public void Reset()
        {
            CurrentPlayer = _initialPlayer;
            _boardState.ResetToStartPosition();
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

        public BoardResult Move(Player player, string fromPosition, string toPosition)
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
                CurrentPlayer = (player == Player.Black) ? Player.White : Player.Black;

                return BoardResult.ValidOperation;
            }

            return BoardResult.InvalidOperation;
        }
    }
}