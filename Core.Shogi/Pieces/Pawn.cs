using System.Collections.Generic;

namespace Core.Shogi.Pieces
{
    public class Pawn : Piece
    {
        private bool _isFirstMove = true;

        public Pawn(Player ownerPlayer, string position) : base(ownerPlayer, position)
        {
            ShortName = 'P';
            CanMoveForwards = true;
        }

        public override bool IsMoveLegal(string toPosition)
        {
            if (OwnerPlayer == Player.Black)
                return (Position[0] == toPosition[0] && (Position[1] - 1 == toPosition[1] || _isFirstMove && Position[1] - 2 == toPosition[1]));
            
            return (Position[0] == toPosition[0] && (Position[1] + 1 == toPosition[1] || _isFirstMove && Position[1] + 2 == toPosition[1]));
        }

        public override string Move(string toPosition)
        {
            _isFirstMove = false;
            return base.Move(toPosition);
        }
    }
}