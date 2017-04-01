namespace Core.Shogi.Pieces
{
    public class Lance : Piece
    {
        public Lance(PlayerType ownerPlayer, string position) : base(ownerPlayer, position)
        {
            ShortName = 'L';
            CanMoveForwardInRange = true;
        }
    }
}