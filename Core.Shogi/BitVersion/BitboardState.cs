namespace Core.Shogi.BitVersion
{
    public struct BitboardState
    {
        public BitboardState(Bitboard blackPieces, Bitboard whitePieces, Bitboard blackGolds)
        {
            BlackPieces = blackPieces;
            WhitePieces = whitePieces;
            BlackGolds = blackGolds;
            Occupied = blackPieces ^ whitePieces;
        }

        public Bitboard BlackPieces { get; private set; }
        public Bitboard WhitePieces { get; private set; }
        public Bitboard Occupied { get; private set; }
        public Bitboard BlackGolds { get; private set; }

        public Bitboard GetNextState()
        { 
            var pieceIndexes = BlackPieces.GetOccuppiedIndexes();
            var nextState = Bitboard.Empty;

            foreach (var pieceIndex in pieceIndexes)
            {
                var potentialAttack = Precalculated.Attacks[0, pieceIndex];
                var attackOverlayWithBlacks = potentialAttack & ~BlackPieces;

                nextState = (WhitePieces & attackOverlayWithBlacks);
            }

            return nextState;
        }
    }
}