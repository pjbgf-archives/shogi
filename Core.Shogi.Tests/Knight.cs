namespace Core.Shogi.Tests
{
    internal class Knight : Piece
    {
        public Knight(Player ownerPlayer, string position) : base(ownerPlayer, position)
        {
            ShortName = 'N';
        }
    }
}