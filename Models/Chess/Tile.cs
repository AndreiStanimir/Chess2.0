using Chess20.Models.Chess.Pieces;
using System;
using System.Collections.Generic;

namespace Chess20.Models.Chess
{
    public class Tile : ICloneable
    {
        private IPiece piece;
        public Position Position { get; set; }

        public IPiece Piece
        {
            get => this.piece;
            set
            {
                this.piece = value;
                if (piece is not null)
                {
                    this.piece.Position = this.Position;
                }
            }
        }

        public Tile(int y, int x)
        {
            Piece = null;
            Position = new Position(y, x);
        }

        public void SetPiece()
        {
            Piece = null;
        }

        public void SetPiece(Piece piece, Position position)
        {
            Piece = piece;
            Position = piece.Position = position;
        }

        public override bool Equals(object obj)
        {
            return obj is Tile tile &&
                   EqualityComparer<IPiece>.Default.Equals(Piece, tile.Piece);
        }

        public bool IsEmpty() => Piece == null;

        public override int GetHashCode()
        {
            return 816749037 + EqualityComparer<IPiece>.Default.GetHashCode(Piece);
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}