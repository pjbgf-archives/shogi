using Core.Shogi.BitVersion;

namespace Core.Shogi
{
    public interface IBoardRender
    {
        void Refresh(BoardState boardState);
        void Refresh(BitboardState boardState);
        void InvalidOperation(BoardResult boardResult);
    }
}