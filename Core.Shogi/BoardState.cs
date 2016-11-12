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

        public IEnumerable<Piece> GetAllPiecesFromPlayer(Player player)
        {
            return _pieces.Values.Where(x => x.OwnerPlayer == player);
        }

        public void Reset()
        {
            Clear();

            //TODO: Review, not sure whether this is the right place for this.
            Add(new Lance(Player.White, "1a"));
            Add(new Knight(Player.White, "2a"));
            Add(new Silver(Player.White, "3a"));
            Add(new Gold(Player.White, "4a"));
            Add(new King(Player.White, "5a"));
            Add(new Gold(Player.White, "6a"));
            Add(new Silver(Player.White, "7a"));
            Add(new Knight(Player.White, "8a"));
            Add(new Lance(Player.White, "9a"));
            Add(new Rook(Player.White, "8b"));
            Add(new Bishop(Player.White, "2b"));
            Add(new Pawn(Player.White, "1c"));
            Add(new Pawn(Player.White, "2c"));
            Add(new Pawn(Player.White, "3c"));
            Add(new Pawn(Player.White, "4c"));
            Add(new Pawn(Player.White, "5c"));
            Add(new Pawn(Player.White, "6c"));
            Add(new Pawn(Player.White, "7c"));
            Add(new Pawn(Player.White, "8c"));
            Add(new Pawn(Player.White, "9c"));

            Add(new Pawn(Player.Black, "1g"));
            Add(new Pawn(Player.Black, "2g"));
            Add(new Pawn(Player.Black, "3g"));
            Add(new Pawn(Player.Black, "4g"));
            Add(new Pawn(Player.Black, "5g"));
            Add(new Pawn(Player.Black, "6g"));
            Add(new Pawn(Player.Black, "7g"));
            Add(new Pawn(Player.Black, "8g"));
            Add(new Pawn(Player.Black, "9g"));
            Add(new Bishop(Player.Black, "8h"));
            Add(new Rook(Player.Black, "2h"));
            Add(new Lance(Player.Black, "1i"));
            Add(new Knight(Player.Black, "2i"));
            Add(new Silver(Player.Black, "3i"));
            Add(new Gold(Player.Black, "4i"));
            Add(new King(Player.Black, "5i"));
            Add(new Gold(Player.Black, "6i"));
            Add(new Silver(Player.Black, "7i"));
            Add(new Knight(Player.Black, "8i"));
            Add(new Lance(Player.Black, "9i"));
        }
    }
}