namespace Core.Shogi
{
    public class Hook : Piece
    {
        public Hook(Player ownerPlayer, string position) : base(ownerPlayer, position)
        {
            ShortName = 'H';
        }
    }
}