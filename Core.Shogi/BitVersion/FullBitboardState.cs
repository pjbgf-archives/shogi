namespace Core.Shogi.BitVersion
{
    //TODO: Better naming required
    public class FullBitboardState
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
    }
}