using Chess20.Models.Chess.Pieces;
using System.Collections.Generic;

namespace Chess20.Models.Chess
{
    public class Tile
    {
        public Piece Piece { get; private set; }

        public void SetPiece()
        {
            Piece = null;
        }

        public void SetPiece(Piece piece, Position position)
        {
            Piece = piece;
            piece.Position = position;
        }

        public override bool Equals(object obj)
        {
            return obj is Tile tile &&
                   EqualityComparer<Piece>.Default.Equals(Piece, tile.Piece);
        }

        public bool IsEmpty() => Piece == null;

        public override int GetHashCode()
        {
            return 816749037 + EqualityComparer<Piece>.Default.GetHashCode(Piece);
        }
    }
}