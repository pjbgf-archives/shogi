using Core.Shogi.BitVersion;

namespace Core.Shogi
{
    public interface IBoardRender
    {
        void Refresh(IBoardState boardState);

        void InvalidOperation(BoardResult boardResult);
    }
}