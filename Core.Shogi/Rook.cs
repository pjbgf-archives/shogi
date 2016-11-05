namespace Core.Shogi
{
    internal class Rook : Piece
    {
        public Rook(Player ownerPlayer, string position) : base(ownerPlayer, position)
        {
            ShortName = 'R';
        }
    }
}