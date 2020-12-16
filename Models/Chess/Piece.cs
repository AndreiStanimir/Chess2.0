using Chess20.Common;
using Chess20.Models.Chess.Pieces;

namespace Chess20.Models.Chess
{
    public abstract class Piece : IPiece
    {
        public Color Color { get; }

        public char Symbol => throw new System.NotImplementedException();

        public Position Position { get; set; }

        public bool Move(Position to)
        {
            throw new System.NotImplementedException();
        }

        protected Piece(Color color)
        {
            Color = color;
        }
    }
}