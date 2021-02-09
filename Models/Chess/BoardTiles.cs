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
            for (int x = 0; x < mAX_X; x++)
            {
                for (int y = 0; y < mAX_Y; y++)
                {
                    tiles[y, x] = new Tile(y, x);
                }
            }
        }

        public Tile? this[int y, int x]
        {
            get
            {
                if (CONSTANTS.IsInside(y, x))
                    return tiles[y, x];
                return null;
            }
            set
            {
                if (CONSTANTS.IsInside(y, x))
                    tiles[y, x] = value;
            }
        }

        public Tile? this[Position p]
        {
            get { return this[p.Y, p.X]; }
            set { tiles[p.Y, p.X] = value; }
        }

        public IEnumerable<Tile> GetTiles()
        {
            foreach (var t in tiles)
            {
                yield return (Tile)t;
            }
        }
    }
}