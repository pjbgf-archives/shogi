using System.Collections.Generic;
using System.Linq;
using Core.Shogi.Pieces;

namespace Core.Shogi
{
    public class BoardState
    {
        readonly Dictionary<string, Piece> _pieces = new Dictionary<string, Piece>(81);

        public void Add(Piece piece)
        {
            _pieces.Add(piece.Position, piece);
        }

        public void Clear()
        {
            _pieces.Clear();
        }

        public void Remove(string fromPosition)
        {
            _pieces.Remove(fromPosition);
        }

        public Piece GetPiece(string fromPosition)
        {
            Piece piece;

            _pieces.TryGetValue(fromPosition, out piece);

            return piece;
        }

        public IEnumerable<Piece> GetAllPiecesFromPlayer(PlayerType player)
        {
            return _pieces.Values.Where(x => x.OwnerPlayer == player);
        }

        public void ResetToStartPosition()
        {
            Clear();

            //TODO: Review, not sure whether this is the right place for this.
            Add(new Lance(PlayerType.White, "1a"));
            Add(new Knight(PlayerType.White, "2a"));
            Add(new Silver(PlayerType.White, "3a"));
            Add(new Gold(PlayerType.White, "4a"));
            Add(new King(PlayerType.White, "5a"));
            Add(new Gold(PlayerType.White, "6a"));
            Add(new Silver(PlayerType.White, "7a"));
            Add(new Knight(PlayerType.White, "8a"));
            Add(new Lance(PlayerType.White, "9a"));
            Add(new Rook(PlayerType.White, "8b"));
            Add(new Bishop(PlayerType.White, "2b"));
            Add(new Pawn(PlayerType.White, "1c"));
            Add(new Pawn(PlayerType.White, "2c"));
            Add(new Pawn(PlayerType.White, "3c"));
            Add(new Pawn(PlayerType.White, "4c"));
            Add(new Pawn(PlayerType.White, "5c"));
            Add(new Pawn(PlayerType.White, "6c"));
            Add(new Pawn(PlayerType.White, "7c"));
            Add(new Pawn(PlayerType.White, "8c"));
            Add(new Pawn(PlayerType.White, "9c"));

            Add(new Pawn(PlayerType.Black, "1g"));
            Add(new Pawn(PlayerType.Black, "2g"));
            Add(new Pawn(PlayerType.Black, "3g"));
            Add(new Pawn(PlayerType.Black, "4g"));
            Add(new Pawn(PlayerType.Black, "5g"));
            Add(new Pawn(PlayerType.Black, "6g"));
            Add(new Pawn(PlayerType.Black, "7g"));
            Add(new Pawn(PlayerType.Black, "8g"));
            Add(new Pawn(PlayerType.Black, "9g"));
            Add(new Bishop(PlayerType.Black, "8h"));
            Add(new Rook(PlayerType.Black, "2h"));
            Add(new Lance(PlayerType.Black, "1i"));
            Add(new Knight(PlayerType.Black, "2i"));
            Add(new Silver(PlayerType.Black, "3i"));
            Add(new Gold(PlayerType.Black, "4i"));
            Add(new King(PlayerType.Black, "5i"));
            Add(new Gold(PlayerType.Black, "6i"));
            Add(new Silver(PlayerType.Black, "7i"));
            Add(new Knight(PlayerType.Black, "8i"));
            Add(new Lance(PlayerType.Black, "9i"));
        }
    }
}