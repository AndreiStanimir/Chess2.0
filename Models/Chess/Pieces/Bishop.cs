using Chess20.Common;

namespace Chess20.Models.Chess.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(Color color) : base(color, 'b')
        {
        }

        public override Move[] GetMoves(BoardTiles tiles)
        {
            return BishopBehaviour.GetMoves(tiles, Position);
        }
    }
}