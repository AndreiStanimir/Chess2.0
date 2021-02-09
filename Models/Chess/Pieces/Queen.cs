﻿using Chess20.Common;

namespace Chess20.Models.Chess.Pieces
{
    public class Queen : Piece
    {
        public Queen(Color color) : base(color, 'q')
        {
        }

        public override Move[] GetMoves(BoardTiles tiles)
        {
            throw new System.NotImplementedException();
        }
    }
}