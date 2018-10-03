namespace Core.Shogi.Pieces
{
    public class Rook : Piece
    {
        public Rook(Player ownerPlayer, string position) : base(ownerPlayer, position)
        {
            ShortName = 'R';
            CanMoveHorizontallyAndVerticallyInRange = true;
        }
    }
}