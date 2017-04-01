namespace Core.Shogi.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(PlayerType ownerPlayer, string position) : base(ownerPlayer, position)
        {
            ShortName = 'B';
            CanMoveDiagonallyInRange = true;
        }
    }
}