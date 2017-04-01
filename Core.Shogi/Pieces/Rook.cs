namespace Core.Shogi.Pieces
{
    public class Rook : Piece
    {
        public Rook(PlayerType ownerPlayer, string position) : base(ownerPlayer, position)
        {
            ShortName = 'R';
            CanMoveHorizontallyAndVerticallyInRange = true;
        }
    }
}