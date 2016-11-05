namespace Core.Shogi
{
    public class Bishop : Piece
    {
        public Bishop(Player ownerPlayer, string position) : base(ownerPlayer, position)
        {
            ShortName = 'B';
        }
    }
}