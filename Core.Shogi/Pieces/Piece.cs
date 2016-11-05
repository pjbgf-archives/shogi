namespace Core.Shogi.Pieces
{
    public abstract class Piece
    {
        public Player OwnerPlayer { get; }
        public string Position { get; private set; }
        public char ShortName { get; protected set; }
        public bool CanMoveBack { get; protected set; }
        public bool CanMoveForwards { get; protected set; }
        public bool CanMoveForwardInRange { get; protected set; }
        public bool CanMoveDiagnonallyInRange { get; protected set; }
        public bool CanMoveForwardsDiagnonally { get; protected set; }
        public bool CanMoveBackwardsDiagnonally { get; protected set; }

        protected Piece(Player ownerPlayer, string position)
        {
            OwnerPlayer = ownerPlayer;
            Position = position;
        }

        public virtual bool IsMoveLegal(string toPosition)
        {
            return (CanMoveBack && HasMovedBack(toPosition)) ||
                   (CanMoveForwards && HasMovedForwards(toPosition)) ||
                   (CanMoveForwardsDiagnonally && HasMovedForwardsDiagnonally(toPosition)) ||
                   (CanMoveBackwardsDiagnonally && HasMovedBackwardsDiagnonally(toPosition)) ||
                   (CanMoveDiagnonallyInRange && HasMovedDiagnonallyInRange(toPosition)) ||
                   (CanMoveForwardInRange && HasMovedForwardInRange(toPosition));
        }

        public virtual void Move(string toPosition)
        {
            Position = toPosition;
        }

        private bool HasMovedBack(string toPosition)
        {
            if (OwnerPlayer == Player.Black)
                return (Position[0] == toPosition[0] && (Position[1] + 1 == toPosition[1]));

            return (Position[0] == toPosition[0] && (Position[1] - 1 == toPosition[1]));
        }

        private bool HasMovedForwards(string toPosition)
        {
            if (OwnerPlayer == Player.Black)
                return (Position[0] == toPosition[0] && (Position[1] - 1 == toPosition[1]));

            return (Position[0] == toPosition[0] && (Position[1] + 1 == toPosition[1]));
        }

        private bool HasMovedForwardInRange(string toPosition)
        {
            if (OwnerPlayer == Player.Black)
                return (Position[0] == toPosition[0] && (Position[1] > toPosition[1]));

            return (Position[0] == toPosition[0] && (Position[1] < toPosition[1]));
        }

        private bool HasMovedForwardsDiagnonally(string toPosition)
        {
            if (OwnerPlayer == Player.Black)
                return ((Position[0] + 1 == toPosition[0] || Position[0] - 1 == toPosition[0]) && (Position[1] - 1 == toPosition[1]));

            return ((Position[0] + 1 == toPosition[0] || Position[0] - 1 == toPosition[0]) && (Position[1] + 1 == toPosition[1]));
        }

        private bool HasMovedDiagnonallyInRange(string toPosition)
        {
            return false;
        }

        private bool HasMovedBackwardsDiagnonally(string toPosition)
        {
            if (OwnerPlayer == Player.Black)
                return ((Position[0] + 1 == toPosition[0] || Position[0] - 1 == toPosition[0]) && (Position[1] + 1 == toPosition[1]));

            return ((Position[0] + 1 == toPosition[0] || Position[0] - 1 == toPosition[0]) && (Position[1] - 1 == toPosition[1]));
        }
    }
}