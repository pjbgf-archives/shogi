using Core.Shogi.Pieces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Shogi
{
    public interface IBoardState
    {
        Piece GetPiece(string pieceLocation);
    }
}
