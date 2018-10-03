using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Core.Shogi.Pieces
{
    public abstract class Piece
    {
        private List<string> _possibleMovements;
        public Player OwnerPlayer { get; }
        public string Position { get; private set; }
        public char ShortName { get; protected set; }

        public bool CanMoveBack { get; protected set; }
        public bool CanMoveForwards { get; protected set; }
        public bool CanMoveForwardInRange { get; protected set; }
        public bool CanMoveDiagonallyInRange { get; protected set; }
        public bool CanMoveForwardsDiagonally { get; protected set; }
        public bool CanMoveBackwardsDiagonally { get; protected set; }
        public bool CanMoveHorizontallyAndVerticallyInRange { get; protected set; }
        public bool CanMoveSideways { get; protected set; }

        protected Piece(Player ownerPlayer, string position)
        {
            OwnerPlayer = ownerPlayer;
            Position = position;
        }

        public List<string> PossibleMovements
        {
            get
            {
                if (_possibleMovements == null)
                {
                    _possibleMovements = new List<string>();
                    UpdatePossibleMovements();
                }
                return _possibleMovements;
            }
            protected set { _possibleMovements = value; }
        }

        public virtual bool IsMoveLegal(string toPosition)
        {
            return PossibleMovements.Contains(string.Concat(Position, toPosition));
        }

        public virtual string Move(string toPosition)
        {
            var movementDescription = $"{ShortName}{Position}-{toPosition}";

            Position = toPosition;
            UpdatePossibleMovements();

            return movementDescription;
        }

        protected virtual void UpdatePossibleMovements()
        {
            PossibleMovements.Clear();

            PossibleMovements.AddRange(GetBackwardOrForwardMovements());
            PossibleMovements.AddRange(GetSidewayMovements());
            PossibleMovements.AddRange(GetBackwardAndForwardDiagonalMovements());
            PossibleMovements.AddRange(GetRangeForwardMovements());
            PossibleMovements.AddRange(GetRangeDiagonalMovements());
            PossibleMovements.AddRange(GetRangeHorizontallyAndVerticallyMovements());
        }

        private IEnumerable<string> GetBackwardAndForwardDiagonalMovements()
        {
            var possibleMovements = new List<string>();

            if ((CanMoveForwardsDiagonally && OwnerPlayer == Player.Black) ||
                (CanMoveBackwardsDiagonally && OwnerPlayer == Player.White))
            {
                possibleMovements.Add(string.Concat(Position, Convert.ToChar(Position[0] + 1),
                    Convert.ToChar(Position[1] - 1)));
                possibleMovements.Add(string.Concat(Position, Convert.ToChar(Position[0] - 1),
                    Convert.ToChar(Position[1] - 1)));
            }

            if ((CanMoveBackwardsDiagonally && OwnerPlayer == Player.Black) ||
                (CanMoveForwardsDiagonally && OwnerPlayer == Player.White))
            {
                possibleMovements.Add(string.Concat(Position, Convert.ToChar(Position[0] + 1),
                    Convert.ToChar(Position[1] + 1)));
                possibleMovements.Add(string.Concat(Position, Convert.ToChar(Position[0] - 1),
                    Convert.ToChar(Position[1] + 1)));
            }

            return possibleMovements;
        }

        private IEnumerable<string> GetRangeHorizontallyAndVerticallyMovements()
        {
            var possibleMovements = new List<string>();

            if (CanMoveHorizontallyAndVerticallyInRange)
            {
                for (var i = Position[1] - 1; i >= 'a'; i--)
                    possibleMovements.Add(string.Concat(Position, Position[0], Convert.ToChar(i)));
                for (var i = Position[1] + 1; i <= 'i'; i++)
                    possibleMovements.Add(string.Concat(Position, Position[0], Convert.ToChar(i)));
                for (var i = Position[0] - 1; i >= '1'; i--)
                    possibleMovements.Add(string.Concat(Position, Convert.ToChar(i), Position[1]));
                for (var i = Position[0] + 1; i <= '9'; i++)
                    possibleMovements.Add(string.Concat(Position, Convert.ToChar(i), Position[1]));
            }

            return possibleMovements;
        }

        private IEnumerable<string> GetRangeDiagonalMovements()
        {
            var possibleMovements = new List<string>();

            if (CanMoveDiagonallyInRange)
            {
                for (var i = 1; i <= 8; i++)
                {
                    AppendIfValidMovement(possibleMovements, string.Concat(Position, Convert.ToChar(Position[0] - i), Convert.ToChar(Position[1] - i)));
                    AppendIfValidMovement(possibleMovements, string.Concat(Position, Convert.ToChar(Position[0] + i), Convert.ToChar(Position[1] + i)));
                    AppendIfValidMovement(possibleMovements, string.Concat(Position, Convert.ToChar(Position[0] - i), Convert.ToChar(Position[1] + i)));
                    AppendIfValidMovement(possibleMovements, string.Concat(Position, Convert.ToChar(Position[0] + i), Convert.ToChar(Position[1] - i)));
                }
            }

            return possibleMovements;
        }

        private void AppendIfValidMovement(ICollection<string> possibleMovements, string position)
        {
            if (Regex.IsMatch(position, "^[1-9][a-i][1-9][a-i]$") && !possibleMovements.Contains(position))
                possibleMovements.Add(position);
        }


        private IEnumerable<string> GetRangeForwardMovements()
        {
            var possibleMovements = new List<string>();

            if (CanMoveForwardInRange)
            {
                if (OwnerPlayer == Player.Black)
                    for (int i = Position[1] - 1; i >= 'a'; i--)
                        possibleMovements.Add(string.Concat(Position, Position[0], Convert.ToChar(i)));
                else
                    for (int i = Position[1] + 1; i <= 'i'; i++)
                        possibleMovements.Add(string.Concat(Position, Position[0], Convert.ToChar(i)));
            }

            return possibleMovements;
        }

        private IEnumerable<string> GetSidewayMovements()
        {
            var possibleMovements = new List<string>();

            if (CanMoveSideways)
            {
                possibleMovements.Add(string.Concat(Position, Convert.ToChar(Position[0] - 1), Position[1]));
                possibleMovements.Add(string.Concat(Position, Convert.ToChar(Position[0] + 1), Position[1]));
            }

            return possibleMovements;
        }

        private IEnumerable<string> GetBackwardOrForwardMovements()
        {
            var possibleMovements = new List<string>();

            if ((OwnerPlayer == Player.Black && CanMoveForwards) || (OwnerPlayer == Player.White && CanMoveBack))
                possibleMovements.Add(string.Concat(Position, Position[0], Convert.ToChar(Position[1] - 1)));
            if ((OwnerPlayer == Player.White && CanMoveForwards) || (OwnerPlayer == Player.Black && CanMoveBack))
                possibleMovements.Add(string.Concat(Position, Position[0], Convert.ToChar(Position[1] + 1)));

            return possibleMovements;
        }
    }
}