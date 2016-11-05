namespace Core.Shogi.Tests
{
    internal class Gold : Piece
    {
        public Gold(Player ownerPlayer, string position) : base(ownerPlayer, position)
        {
            ShortName = 'G';
            CanMoveBack = true;
            CanMoveForwardsDiagnonally = true;
            CanMoveForwards = true;
        }
    }
}