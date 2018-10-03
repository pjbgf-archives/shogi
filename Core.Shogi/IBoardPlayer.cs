namespace Core.Shogi
{
    public interface IBoardPlayer
    {
        string AskForNextMove();
        Player Player { get; }
    }
}