namespace Core.Shogi.Tests
{
    internal class Bishop : Piece
    {
        public Bishop(Player ownerPlayer, string position) : base(ownerPlayer, position)
        {
            ShortName = 'B';
        }
    }
}