namespace Core.Shogi
{
    public interface IBoardPlayer
    {
        string AskForNextMove();
        PlayerType Player { get; }
    }
}