using Chess20.Common;

namespace Chess20.Models.Chess.Pieces
{
    public class Rook : Piece
    {
        public Rook(Color color) : base(color, 'r')
        {
        }

        public override Move[] GetMoves(BoardTiles tiles)
        {
            return RookBehaviour.GetMoves(tiles, Position);
        }
    }
}