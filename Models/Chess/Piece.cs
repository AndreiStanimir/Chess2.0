using Chess20.Common;
using Chess20.Models.Chess.Pieces;
using System.Collections;
using System.Collections.Generic;

namespace Chess20.Models.Chess
{
    public abstract class Piece : IPiece
    {
        public Color Color { get; }

        public char Symbol { get; }

        public Position Position { get; set; }

        public int x { get => Position.X; }
        public int y { get => Position.Y; }

        public bool IsPinned { get; set; }

        public bool Move(Position to)
        {
            throw new System.NotImplementedException();
        }

        public Move[] GetValidMoves(Board tiles)
        {
            if (IsPinned)
                return new Move[0];

            return GetMoves(tiles);
        }

        public abstract Move[] GetMoves(Board tiles);

        public override bool Equals(object obj)
        {
            return obj is Piece piece &&
                   Color == piece.Color &&
                   Symbol == piece.Symbol &&
                   EqualityComparer<Position>.Default.Equals(Position, piece.Position);
        }

        public override int GetHashCode()
        {
            int hashCode = 1569584699;
            hashCode = hashCode * -1521134295 + Color.GetHashCode();
            hashCode = hashCode * -1521134295 + Symbol.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Position>.Default.GetHashCode(Position);
            return hashCode;
        }

        protected Piece(Color color)
        {
            this.Color = color;
        }

        protected Piece(Color color, char symbol)
        {
            this.Color = color;
            Symbol = symbol;
        }
    }
}