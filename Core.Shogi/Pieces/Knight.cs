namespace Core.Shogi.Pieces
{
    public class Knight : Piece
    {
        public Knight(Player ownerPlayer, string position) : base(ownerPlayer, position)
        {
            ShortName = 'N';
        }
    }
}