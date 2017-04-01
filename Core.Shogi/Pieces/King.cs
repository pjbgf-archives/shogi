namespace Core.Shogi.Pieces
{
    public class King : Piece
    {
        public King(PlayerType ownerPlayer, string position) : base(ownerPlayer, position)
        {
            ShortName = 'K';
            CanMoveBack = true;
            CanMoveBackwardsDiagonally = true;
            CanMoveForwards = true;
            CanMoveForwardsDiagonally = true;
            CanMoveSideways = true;
        }
    }
}