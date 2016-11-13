namespace Core.Shogi
{
    public interface IBoardInput
    {
        string AskForNextMove();
        Player Player { get; }
    }
}