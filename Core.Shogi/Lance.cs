namespace Core.Shogi
{
    public class Lance : Piece
    {
        public Lance(Player ownerPlayer, string position) : base(ownerPlayer, position)
        {
            ShortName = 'L';
            CanMoveForwardInRange = true;
        }
    }
}