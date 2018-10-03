using Core.Shogi.Pieces;

namespace Core.Shogi.BitVersion
{
    public class FullBitboardState : IBoardState
    {
        public BitboardState WhitePieces { get; }
        public BitboardState BlackPieces { get; set; }

        public static FullBitboardState DefaultState => new FullBitboardState(
            BitboardPredefinedStates.InitialWhitePositions,
            BitboardPredefinedStates.InitialBlackPositions);

        public FullBitboardState(BitboardState whitePieces, BitboardState blackPieces)
        {
            WhitePieces = whitePieces;
            BlackPieces = blackPieces;
        }

        public Piece GetPiece(string pieceLocation)
        {
            throw new System.NotImplementedException();
        }
    }
}