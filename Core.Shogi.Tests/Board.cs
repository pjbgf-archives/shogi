using System.Collections.Generic;

namespace Core.Shogi.Tests
{
    public class Board
    {
        readonly Dictionary<string, Piece> _pieces = new Dictionary<string, Piece>(81);

        public Player CurrentTurn = Player.Black;

        public Board()
        {
            ResetBoard();
        }

        private void ResetBoard()
        {
            CurrentTurn = Player.Black;

            _pieces.Clear();
            _pieces.Add("1a", new Lance(Player.White, "1a"));
            _pieces.Add("2a", new Knight(Player.White, "2a"));
            _pieces.Add("3a", new Silver(Player.White, "3a"));
            _pieces.Add("4a", new Gold(Player.White, "4a"));
            _pieces.Add("5a", new King(Player.White, "5a"));
            _pieces.Add("6a", new Gold(Player.White, "6a"));
            _pieces.Add("7a", new Silver(Player.White, "7a"));
            _pieces.Add("8a", new Knight(Player.White, "8a"));
            _pieces.Add("9a", new Lance(Player.White, "9a"));
            _pieces.Add("8b", new Rook(Player.White, "8b"));
            _pieces.Add("2b", new Bishop(Player.White, "2b"));
            _pieces.Add("1c", new Pawn(Player.White, "1c"));
            _pieces.Add("2c", new Pawn(Player.White, "2c"));
            _pieces.Add("3c", new Pawn(Player.White, "3c"));
            _pieces.Add("4c", new Pawn(Player.White, "4c"));
            _pieces.Add("5c", new Pawn(Player.White, "5c"));
            _pieces.Add("6c", new Pawn(Player.White, "6c"));
            _pieces.Add("7c", new Pawn(Player.White, "7c"));
            _pieces.Add("8c", new Pawn(Player.White, "8c"));
            _pieces.Add("9c", new Pawn(Player.White, "9c"));


            _pieces.Add("1g", new Pawn(Player.Black, "1g"));
            _pieces.Add("2g", new Pawn(Player.Black, "2g"));
            _pieces.Add("3g", new Pawn(Player.Black, "3g"));
            _pieces.Add("4g", new Pawn(Player.Black, "4g"));
            _pieces.Add("5g", new Pawn(Player.Black, "5g"));
            _pieces.Add("6g", new Pawn(Player.Black, "6g"));
            _pieces.Add("7g", new Pawn(Player.Black, "7g"));
            _pieces.Add("8g", new Pawn(Player.Black, "8g"));
            _pieces.Add("9g", new Pawn(Player.Black, "9g"));
            _pieces.Add("8h", new Bishop(Player.Black, "8h"));
            _pieces.Add("2h", new Rook(Player.Black, "2h"));
            _pieces.Add("1i", new Lance(Player.Black, "1i"));
            _pieces.Add("2i", new Knight(Player.Black, "2i"));
            _pieces.Add("3i", new Silver(Player.Black, "3i"));
            _pieces.Add("4i", new Gold(Player.Black, "4i"));
            _pieces.Add("5i", new King(Player.Black, "5i"));
            _pieces.Add("6i", new Gold(Player.Black, "6i"));
            _pieces.Add("7i", new Silver(Player.Black, "7i"));
            _pieces.Add("8i", new Knight(Player.Black, "8i"));
            _pieces.Add("9i", new Lance(Player.Black, "9i"));
        }

        public BoardResult Move(Player player, string fromPosition, string toPosition)
        {
            if (player != CurrentTurn)
                return BoardResult.NotPlayersTurn;

            var piece = GetPiece(fromPosition);
            if (player != piece.OwnerPlayer)
                return BoardResult.NotPlayersPiece;

            var targetPiece = GetPiece(toPosition);
            if (piece.IsMoveLegal(toPosition) && (targetPiece == null || targetPiece?.OwnerPlayer != player))
            {
                piece.Move(toPosition);

                _pieces.Remove(fromPosition);
                _pieces.Add(toPosition, piece);

                return BoardResult.ValidOperation;
            }

            return BoardResult.InvalidOperation;
        }

        private Piece GetPiece(string fromPosition)
        {
            Piece piece;

            _pieces.TryGetValue(fromPosition, out piece);

            return piece;
        }
    }
}