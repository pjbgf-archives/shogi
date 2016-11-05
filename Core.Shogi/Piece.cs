namespace Core.Shogi
{
    public abstract class Piece
    {
        protected Piece(Player ownerPlayer, string position)
        {
            OwnerPlayer = ownerPlayer;
            Position = position;
        }

        public Player OwnerPlayer { get; }
        public string Position { get; private set; }
        public char ShortName { get; protected set; }

        public virtual bool IsMoveLegal(string toPosition)
        {
            if (
                (CanMoveBack && HasMovedBack(toPosition)) ||
                (CanMoveForwards && HasMovedForwards(toPosition)) ||
                (CanMoveForwardsDiagnonally && HasMovedForwardsDiagnonally(toPosition)) ||
                (CanMoveBackwardsDiagnonally && HasMovedBackwardsDiagnonally(toPosition))
            )
                return true;

            return false;
        }

        public virtual void Move(string toPosition)
        {
            Position = toPosition;
        }

        protected bool HasMovedBack(string toPosition)
        {
            if (OwnerPlayer == Player.Black)
                return (Position[0] == toPosition[0] && (Position[1] + 1 == toPosition[1]));

            return (Position[0] == toPosition[0] && (Position[1] - 1 == toPosition[1]));
        }

        protected bool HasMovedForwards(string toPosition)
        {
            if (OwnerPlayer == Player.Black)
                return (Position[0] == toPosition[0] && (Position[1] - 1 == toPosition[1]));

            return (Position[0] == toPosition[0] && (Position[1] + 1 == toPosition[1]));
        }

        protected bool HasMovedForwardsDiagnonally(string toPosition)
        {
            if (OwnerPlayer == Player.Black)
                return ((Position[0] + 1 == toPosition[0] || Position[0] - 1 == toPosition[0]) && (Position[1] - 1 == toPosition[1]));

            return ((Position[0] + 1 == toPosition[0] || Position[0] - 1 == toPosition[0]) && (Position[1] + 1 == toPosition[1]));
        }

        protected bool HasMovedBackwardsDiagnonally(string toPosition)
        {
            if (OwnerPlayer == Player.Black)
                return ((Position[0] + 1 == toPosition[0] || Position[0] - 1 == toPosition[0]) && (Position[1] + 1 == toPosition[1]));

            return ((Position[0] + 1 == toPosition[0] || Position[0] - 1 == toPosition[0]) && (Position[1] - 1 == toPosition[1]));
        }

        protected bool CanMoveBack = false;
        protected bool CanMoveForwards = false;
        protected bool CanMoveForwardsDiagnonally = false;
        protected bool CanMoveBackwardsDiagnonally = false;
    }
}