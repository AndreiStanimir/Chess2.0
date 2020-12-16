using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess20.Models.Chess
{
    public class Board
    {
        const int MAX_X = 8;
        const int MAX_Y = 8;
        public Tile[,] tiles { get; }

        Board()
        {
            tiles = new Tile[MAX_X, MAX_Y];
        }
    }
}