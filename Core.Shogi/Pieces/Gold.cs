﻿namespace Core.Shogi.Pieces
{
    public class Gold : Piece
    {
        public Gold(Player ownerPlayer, string position) : base(ownerPlayer, position)
        {
            ShortName = 'G';
            CanMoveBack = true;
            CanMoveForwardsDiagonally = true;
            CanMoveForwards = true;
        }
    }
}