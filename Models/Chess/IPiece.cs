using Chess20.Common;
using Chess20.Models.Chess.Pieces;

namespace Chess20.Models.Chess
{
    public interface IPiece
    {
        Color Color { get; }
        char Symbol { get; }
        Position Position { get; }

        bool Move(Position to);
    }
}