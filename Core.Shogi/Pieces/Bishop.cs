namespace Core.Shogi.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Player ownerPlayer, string position) : base(ownerPlayer, position)
        {
            ShortName = 'B';
            CanMoveDiagnonallyInRange = true;
        }
    }
}