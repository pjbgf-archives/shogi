namespace Core.Shogi.Pieces
{
    public class Silver : Piece
    {
        public Silver(Player ownerPlayer, string position) : base(ownerPlayer, position)
        {
            ShortName = 'S';
            CanMoveForwards = true;
            CanMoveForwardsDiagonally = true;
            CanMoveBackwardsDiagonally = true;
        }
    }
}