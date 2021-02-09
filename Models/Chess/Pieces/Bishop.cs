using Chess20.Common;

namespace Chess20.Models.Chess.Pieces
{
    public class Bishop : Piece,
    {
        private BishopBehaviour;

        public Bishop(Color color) : base(color, 'b')
        {
            BishopBehaviour = Factory.
        }

        protected override Move[] GetMoves(BoardTiles tiles)
        {
        }
    }
}