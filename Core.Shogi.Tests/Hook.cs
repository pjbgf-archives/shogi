namespace Core.Shogi.Tests
{
    internal class Hook : Piece
    {
        public Hook(Player ownerPlayer, string position) : base(ownerPlayer, position)
        {
            ShortName = 'H';
        }
    }
}