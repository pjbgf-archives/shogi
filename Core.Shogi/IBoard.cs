using Core.Shogi.BitVersion;

namespace Core.Shogi
{
    public interface IBoard
    {
        void Reset();

        IBoardState State { get; }

        BoardResult Move(Player player, string fromPosition, string toPosition);
    }
}