namespace Core.Shogi.Pieces
{
    public class Gold : Piece
    {
        public Gold(PlayerType ownerPlayer, string position) : base(ownerPlayer, position)
        {
            ShortName = 'G';
            CanMoveBack = true;
            CanMoveForwardsDiagonally = true;
            CanMoveForwards = true;
        }
    }
}