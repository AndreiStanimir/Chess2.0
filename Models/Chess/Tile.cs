using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess20.Models.Chess
{
    public class Tile
    {
        public Piece Piece { get; set; }

        bool IsEmpty() => Piece == null;
    }
}