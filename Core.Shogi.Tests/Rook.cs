namespace Core.Shogi.Tests
{
    internal class Rook : Piece
    {
        public Rook(Player ownerPlayer, string position) : base(ownerPlayer, position)
        {
            ShortName = 'R';
        }
    }
}