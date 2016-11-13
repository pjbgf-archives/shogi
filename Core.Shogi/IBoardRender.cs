namespace Core.Shogi
{
    public interface IBoardRender
    {
        void Refresh(BoardState boardState);
        void InvalidOperation(BoardResult boardResult);
    }
}