using System;
using System.Collections.Generic;

namespace Core.Shogi.BitVersion
{
    public struct Bitboard
    {
        public Bitboard(
            BitboardRow rowA,
            BitboardRow rowB,
            BitboardRow rowC,
            BitboardRow rowD,
            BitboardRow rowE,
            BitboardRow rowF,
            BitboardRow rowG,
            BitboardRow rowH,
            BitboardRow rowI)
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

        public BitboardRow RowA { get; }
        public BitboardRow RowB { get; }
        public BitboardRow RowC { get; }
        public BitboardRow RowD { get; }
        public BitboardRow RowE { get; }
        public BitboardRow RowF { get; }
        public BitboardRow RowG { get; }
        public BitboardRow RowH { get; }
        public BitboardRow RowI { get; }

        public static Bitboard Empty => new Bitboard(
            "000000000",
            "000000000",
            "000000000",
            "000000000",
            "000000000",
            "000000000",
            "000000000",
            "000000000",
            "000000000"
        );

        public static Bitboard operator &(Bitboard bitboard1, Bitboard bitboard2)
        {
            return new Bitboard(
                bitboard1.RowA & bitboard2.RowA,
                bitboard1.RowB & bitboard2.RowB,
                bitboard1.RowC & bitboard2.RowC,
                bitboard1.RowD & bitboard2.RowD,
                bitboard1.RowE & bitboard2.RowE,
                bitboard1.RowF & bitboard2.RowF,
                bitboard1.RowG & bitboard2.RowG,
                bitboard1.RowH & bitboard2.RowH,
                bitboard1.RowI & bitboard2.RowI
            );
        }

        public static Bitboard operator ^(Bitboard bitboard1, Bitboard bitboard2)
        {
            return new Bitboard(
                bitboard1.RowA ^ bitboard2.RowA,
                bitboard1.RowB ^ bitboard2.RowB,
                bitboard1.RowC ^ bitboard2.RowC,
                bitboard1.RowD ^ bitboard2.RowD,
                bitboard1.RowE ^ bitboard2.RowE,
                bitboard1.RowF ^ bitboard2.RowF,
                bitboard1.RowG ^ bitboard2.RowG,
                bitboard1.RowH ^ bitboard2.RowH,
                bitboard1.RowI ^ bitboard2.RowI
            );
        }

        public static Bitboard operator ~(Bitboard bitboard)
        {
            return new Bitboard(
                ~bitboard.RowA,
                ~bitboard.RowB,
                ~bitboard.RowC,
                ~bitboard.RowD,
                ~bitboard.RowE,
                ~bitboard.RowF,
                ~bitboard.RowG,
                ~bitboard.RowH,
                ~bitboard.RowI
            );
        }

        public bool this[int index]
        {
            get
            {
                if (index < 0 || index > 80)
                    throw new IndexOutOfRangeException();

                var subIndex = index % 9;

                if (index < 9)
                    return RowA[subIndex];
                if (index < 18)
                    return RowB[subIndex];
                if (index < 27)
                    return RowC[subIndex];
                if (index < 36)
                    return RowD[subIndex];
                if (index < 45)
                    return RowE[subIndex];
                if (index < 54)
                    return RowF[subIndex];
                if (index < 63)
                    return RowG[subIndex];
                if (index < 72)
                    return RowH[subIndex];

                return RowI[subIndex];
            }
        }

        public IEnumerable<byte> GetOccuppiedIndexes()
        {
            byte index = 0;
            do
            {
                if (this[index])
                    yield return index++;
            } while (++index < 81);
        }
    }
}