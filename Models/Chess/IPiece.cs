using Chess20.Common;
using Chess20.Models.Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess20.Models.Chess
{
    interface IPiece
    {
        public Color Color { get; }
        public char Symbol { get; }
        public Position Position { get; }

        public bool Move(Position to);
    }
}
