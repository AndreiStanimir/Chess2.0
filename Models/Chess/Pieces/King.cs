using Chess20.Common;

namespace Chess20.Models.Chess.Pieces
{
    public class King : Piece
    {
        public King(Color color) : base(color, 'k')
        {
        }

        public override Move[] GetMoves(BoardTiles tiles)
        {
            throw new System.NotImplementedException();
        }
    }
}