using Chess20.Common;
using Chess20.Models.Chess.Pieces;

namespace Chess20.Models.Chess
{
    public interface IPiece
    {
        Color Color { get; }
        char Symbol { get; }
        Position Position { get; set; }

        bool Move(Position to);

        public abstract Move[] GetMoves(BoardTiles tiles);
    }
}