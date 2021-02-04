using Chess20.Common;
using Chess20.Models.Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess20.Models.Chess
{
    public class BoardTiles
    {
        private Tile[,] tiles;

        public BoardTiles(int mAX_X, int mAX_Y)
        {
            tiles = new Tile[mAX_X, mAX_Y];
            for (int i = 0; i < mAX_X; i++)
            {
                for (int j = 0; j < mAX_Y; j++)
                {
                    tiles[i, j] = new Tile();
                }
            }
        }

        public Tile? this[int x, int y]
        {
            get
            {
                if (CONSTANTS.IsInside(x, y))
                    return tiles[x, y];
                return null;
            }
            set
            {
                if (CONSTANTS.IsInside(x, y))
                    tiles[x, y] = value;
            }
        }

        public Tile? this[Position p]
        {
            get { return this[p.X, p.Y]; }
            set { tiles[p.X, p.Y] = value; }
        }
    }
}