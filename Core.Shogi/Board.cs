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

        public Board(BoardState boardState, Player currentTurn)
        {
            _boardState = boardState;
            CurrentTurn = currentTurn;
        }

        private void ResetBoard()
        {
            CurrentTurn = Player.Black;

            _boardState.Clear();
            _boardState.Add(new Lance(Player.White, "1a"));
            _boardState.Add(new Knight(Player.White, "2a"));
            _boardState.Add(new Silver(Player.White, "3a"));
            _boardState.Add(new Gold(Player.White, "4a"));
            _boardState.Add(new King(Player.White, "5a"));
            _boardState.Add(new Gold(Player.White, "6a"));
            _boardState.Add(new Silver(Player.White, "7a"));
            _boardState.Add(new Knight(Player.White, "8a"));
            _boardState.Add(new Lance(Player.White, "9a"));
            _boardState.Add(new Rook(Player.White, "8b"));
            _boardState.Add(new Bishop(Player.White, "2b"));
            _boardState.Add(new Pawn(Player.White, "1c"));
            _boardState.Add(new Pawn(Player.White, "2c"));
            _boardState.Add(new Pawn(Player.White, "3c"));
            _boardState.Add(new Pawn(Player.White, "4c"));
            _boardState.Add(new Pawn(Player.White, "5c"));
            _boardState.Add(new Pawn(Player.White, "6c"));
            _boardState.Add(new Pawn(Player.White, "7c"));
            _boardState.Add(new Pawn(Player.White, "8c"));
            _boardState.Add(new Pawn(Player.White, "9c"));


            _boardState.Add(new Pawn(Player.Black, "1g"));
            _boardState.Add(new Pawn(Player.Black, "2g"));
            _boardState.Add(new Pawn(Player.Black, "3g"));
            _boardState.Add(new Pawn(Player.Black, "4g"));
            _boardState.Add(new Pawn(Player.Black, "5g"));
            _boardState.Add(new Pawn(Player.Black, "6g"));
            _boardState.Add(new Pawn(Player.Black, "7g"));
            _boardState.Add(new Pawn(Player.Black, "8g"));
            _boardState.Add(new Pawn(Player.Black, "9g"));
            _boardState.Add(new Bishop(Player.Black, "8h"));
            _boardState.Add(new Rook(Player.Black, "2h"));
            _boardState.Add(new Lance(Player.Black, "1i"));
            _boardState.Add(new Knight(Player.Black, "2i"));
            _boardState.Add(new Silver(Player.Black, "3i"));
            _boardState.Add(new Gold(Player.Black, "4i"));
            _boardState.Add(new King(Player.Black, "5i"));
            _boardState.Add(new Gold(Player.Black, "6i"));
            _boardState.Add(new Silver(Player.Black, "7i"));
            _boardState.Add(new Knight(Player.Black, "8i"));
            _boardState.Add(new Lance(Player.Black, "9i"));
        }

        public BoardResult Move(Player player, string fromPosition, string toPosition)
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