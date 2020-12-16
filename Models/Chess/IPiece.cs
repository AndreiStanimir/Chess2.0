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
        Color Color { get; }
        char Symbol { get; }
        Position Position { get; }

        bool Move(Position to);
    }
}
