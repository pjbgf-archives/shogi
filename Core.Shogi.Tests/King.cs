namespace Core.Shogi.Tests
{
    internal class King : Piece
    {
        public King(Player ownerPlayer, string position) : base(ownerPlayer, position)
        {
            ShortName = 'K';
        }
    }
}