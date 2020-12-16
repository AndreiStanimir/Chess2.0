using Chess20.Models.Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess20.Models.Chess
{
    public class Board
    {
        public const int MAX_X = 8;
        public const int MAX_Y = 8;
        public Tile[,] tiles { get; private set; }

        public Board()
        {
            tiles = new Tile[MAX_X, MAX_Y];
        }
        public void SetPiece(Position pos,Piece piece)
        {
            tiles[pos.X, pos.Y].Piece = piece;
        }
    }
}