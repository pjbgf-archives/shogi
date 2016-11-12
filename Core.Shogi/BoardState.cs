using System.Collections.Generic;
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
    }
}