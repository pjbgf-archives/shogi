using System;
using System.Collections.Generic;

namespace Core.Shogi.BitVersion
{
    public struct BitboardState
    {
        public BitboardState(
            BitboardStateRow stateRowA,
            BitboardStateRow stateRowB,
            BitboardStateRow stateRowC,
            BitboardStateRow stateRowD,
            BitboardStateRow stateRowE,
            BitboardStateRow stateRowF,
            BitboardStateRow stateRowG,
            BitboardStateRow stateRowH,
            BitboardStateRow stateRowI)
        {
            StateRowA = stateRowA;
            StateRowB = stateRowB;
            StateRowC = stateRowC;
            StateRowD = stateRowD;
            StateRowE = stateRowE;
            StateRowF = stateRowF;
            StateRowG = stateRowG;
            StateRowH = stateRowH;
            StateRowI = stateRowI;
        }

        public BitboardStateRow StateRowA { get; }
        public BitboardStateRow StateRowB { get; }
        public BitboardStateRow StateRowC { get; }
        public BitboardStateRow StateRowD { get; }
        public BitboardStateRow StateRowE { get; }
        public BitboardStateRow StateRowF { get; }
        public BitboardStateRow StateRowG { get; }
        public BitboardStateRow StateRowH { get; }
        public BitboardStateRow StateRowI { get; }

        public static BitboardState Empty => new BitboardState(HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow, HexValues.EmptyRow);

        public static BitboardState operator &(BitboardState bitboard1, BitboardState bitboard2)
        {
            return new BitboardState(
                bitboard1.StateRowA & bitboard2.StateRowA,
                bitboard1.StateRowB & bitboard2.StateRowB,
                bitboard1.StateRowC & bitboard2.StateRowC,
                bitboard1.StateRowD & bitboard2.StateRowD,
                bitboard1.StateRowE & bitboard2.StateRowE,
                bitboard1.StateRowF & bitboard2.StateRowF,
                bitboard1.StateRowG & bitboard2.StateRowG,
                bitboard1.StateRowH & bitboard2.StateRowH,
                bitboard1.StateRowI & bitboard2.StateRowI
            );
        }

        public static BitboardState operator ^(BitboardState bitboard1, BitboardState bitboard2)
        {
            return new BitboardState(
                bitboard1.StateRowA ^ bitboard2.StateRowA,
                bitboard1.StateRowB ^ bitboard2.StateRowB,
                bitboard1.StateRowC ^ bitboard2.StateRowC,
                bitboard1.StateRowD ^ bitboard2.StateRowD,
                bitboard1.StateRowE ^ bitboard2.StateRowE,
                bitboard1.StateRowF ^ bitboard2.StateRowF,
                bitboard1.StateRowG ^ bitboard2.StateRowG,
                bitboard1.StateRowH ^ bitboard2.StateRowH,
                bitboard1.StateRowI ^ bitboard2.StateRowI
            );
        }

        public static BitboardState operator ~(BitboardState bitboard)
        {
            return new BitboardState(
                ~bitboard.StateRowA,
                ~bitboard.StateRowB,
                ~bitboard.StateRowC,
                ~bitboard.StateRowD,
                ~bitboard.StateRowE,
                ~bitboard.StateRowF,
                ~bitboard.StateRowG,
                ~bitboard.StateRowH,
                ~bitboard.StateRowI
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
                    return StateRowA[subIndex];
                if (index < 18)
                    return StateRowB[subIndex];
                if (index < 27)
                    return StateRowC[subIndex];
                if (index < 36)
                    return StateRowD[subIndex];
                if (index < 45)
                    return StateRowE[subIndex];
                if (index < 54)
                    return StateRowF[subIndex];
                if (index < 63)
                    return StateRowG[subIndex];
                if (index < 72)
                    return StateRowH[subIndex];

                return StateRowI[subIndex];
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

        public override string ToString()
        {
            return $"{StateRowA} {StateRowB} {StateRowC} {StateRowD} {StateRowE} {StateRowF} {StateRowG} {StateRowH} {StateRowI}";
        }
    }
}