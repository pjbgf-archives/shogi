using System;
using System.Collections.Generic;
using Core.Shogi.Pieces;

namespace Core.Shogi.BitVersion
{
    public struct BitboardState : IBoardState
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

        public static BitboardState Empty => new BitboardState(BinaryValues.EmptyRow, BinaryValues.EmptyRow, BinaryValues.EmptyRow, BinaryValues.EmptyRow, BinaryValues.EmptyRow, BinaryValues.EmptyRow, BinaryValues.EmptyRow, BinaryValues.EmptyRow, BinaryValues.EmptyRow);

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

        public static bool operator ==(BitboardState bitboard1, BitboardState bitboard2)
        {
            return bitboard1.Equals(bitboard2);
        }

        public static bool operator !=(BitboardState bitboard1, BitboardState bitboard2)
        {
            return
                (bitboard1.StateRowA != bitboard2.StateRowA) ||
                (bitboard1.StateRowB != bitboard2.StateRowB) ||
                (bitboard1.StateRowC != bitboard2.StateRowC) ||
                (bitboard1.StateRowD != bitboard2.StateRowD) ||
                (bitboard1.StateRowE != bitboard2.StateRowE) ||
                (bitboard1.StateRowF != bitboard2.StateRowF) ||
                (bitboard1.StateRowG != bitboard2.StateRowG) ||
                (bitboard1.StateRowH != bitboard2.StateRowH) ||
                (bitboard1.StateRowI != bitboard2.StateRowI);
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

        public override bool Equals(object bitboard)
        {
            BitboardState bitboard2 = (BitboardState)bitboard;

            if (bitboard2 == null)
                return false;

            return
                (this.StateRowA == bitboard2.StateRowA) &&
                (this.StateRowB == bitboard2.StateRowB) &&
                (this.StateRowC == bitboard2.StateRowC) &&
                (this.StateRowD == bitboard2.StateRowD) &&
                (this.StateRowE == bitboard2.StateRowE) &&
                (this.StateRowF == bitboard2.StateRowF) &&
                (this.StateRowG == bitboard2.StateRowG) &&
                (this.StateRowH == bitboard2.StateRowH) &&
                (this.StateRowI == bitboard2.StateRowI);
        }

        public override int GetHashCode()
        {
            return (this.StateRowA.GetHashCode() + 
                    this.StateRowB.GetHashCode() + 
                    this.StateRowC.GetHashCode() + 
                    this.StateRowD.GetHashCode() + 
                    this.StateRowE.GetHashCode() + 
                    this.StateRowF.GetHashCode() + 
                    this.StateRowG.GetHashCode() + 
                    this.StateRowH.GetHashCode() + 
                    this.StateRowI.GetHashCode());
        }

        public Piece GetPiece(string pieceLocation)
        {
            throw new NotImplementedException();
        }
    }
}