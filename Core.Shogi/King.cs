namespace Core.Shogi
{
    public class King : Piece
    {
        public King(Player ownerPlayer, string position) : base(ownerPlayer, position)
        {
            ShortName = 'K';
            CanMoveBack = true;
            CanMoveBackwardsDiagnonally = true;
            CanMoveForwards = true;
            CanMoveForwardsDiagnonally = true;
        }
    }
}