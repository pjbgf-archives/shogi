namespace Core.Shogi.BitBoard
{
    public struct BitboardState
    {
        public BitboardState(
            BoardRow rowA,
            BoardRow rowB,
            BoardRow rowC,
            BoardRow rowD,
            BoardRow rowE,
            BoardRow rowF,
            BoardRow rowG,
            BoardRow rowH,
            BoardRow rowI)
        {
            RowA = rowA;
            RowB = rowB;
            RowC = rowC;
            RowD = rowD;
            RowE = rowE;
            RowF = rowF;
            RowG = rowG;
            RowH = rowH;
            RowI = rowI;
        }

        public BoardRow RowA { get; }
        public BoardRow RowB { get; }
        public BoardRow RowC { get; }
        public BoardRow RowD { get; }
        public BoardRow RowE { get; }
        public BoardRow RowF { get; }
        public BoardRow RowG { get; }
        public BoardRow RowH { get; }
        public BoardRow RowI { get; }

        public static BitboardState operator &(BitboardState state1, BitboardState state2)
        {
            return new BitboardState(
                state1.RowA & state2.RowA,
                state1.RowB & state2.RowB,
                state1.RowC & state2.RowC,
                state1.RowD & state2.RowD,
                state1.RowE & state2.RowE,
                state1.RowF & state2.RowF,
                state1.RowG & state2.RowG,
                state1.RowH & state2.RowH,
                state1.RowI & state2.RowI
            );
        }
    }
}