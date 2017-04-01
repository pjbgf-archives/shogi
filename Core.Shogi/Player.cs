namespace Core.Shogi
{
    public class Player
    {
        public Player(PlayerType playerType)
        {
        }

        public BoardResult Move(string moveDescription)
        {
            return BoardResult.InvalidOperation;
        }
    }
}