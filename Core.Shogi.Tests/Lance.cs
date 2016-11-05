namespace Core.Shogi.Tests
{
    internal class Lance : Piece
    {
        public Lance(Player ownerPlayer, string position) : base(ownerPlayer, position)
        {
            ShortName = 'L';
        }
    }
}