namespace Core.Shogi
{
    public class Silver : Piece
    {
        public Silver(Player ownerPlayer, string position) : base(ownerPlayer, position)
        {
            ShortName = 'S';
            CanMoveForwards = true;
            CanMoveForwardsDiagnonally = true;
            CanMoveBackwardsDiagnonally = true;
        }
    }
}