namespace Core.Shogi.Pieces
{
    public class Knight : Piece
    {
        public Knight(PlayerType ownerPlayer, string position) : base(ownerPlayer, position)
        {
            ShortName = 'N';
        }

        public override bool IsMoveLegal(string toPosition)
        {
            if (OwnerPlayer == PlayerType.Black)
                return ((Position[0] == toPosition[0] + 1 || Position[0] == toPosition[0] - 1) && (Position[1] - 2 == toPosition[1]));

            return ((Position[0] == toPosition[0] - 1 || Position[0] == toPosition[0] + 1) && (Position[1] + 2 == toPosition[1]));
        }
    }
}