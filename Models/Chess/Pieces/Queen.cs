using Chess20.Common;
using System.Linq;

namespace Chess20.Models.Chess.Pieces
{
    public class Queen : Piece
    {
        public Queen(Color color) : base(color, 'q')
        {
        }

        public override Move[] GetMoves(Board tiles)
        {
            return BishopBehaviour.GetMoves(tiles, Position)
                .Concat(RookBehaviour.GetMoves(tiles, Position))
                .ToArray();
        }
    }
}