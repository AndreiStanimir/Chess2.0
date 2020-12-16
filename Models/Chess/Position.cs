using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chess20.Common;
namespace Chess20.Models.Chess.Pieces
{
    public class Position
    {
        public int X { get; }
        public int Y { get; }

        public Position()
        {
            X = Y = -1;
        }
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
        bool IsInside()
        {
            return X is >= 0 and < CONSTANTS.MAX_X &&
                   Y is >= 0 and < CONSTANTS.MAX_Y;
        }
    }
}