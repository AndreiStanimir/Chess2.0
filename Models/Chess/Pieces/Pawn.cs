using Chess20.Common;
using System.Collections.Generic;

namespace Chess20.Models.Chess.Pieces
{
    public class Pawn : Piece
    {
        private int offset;

        public Pawn(Color color) : base(color, 'p')
        {
            offset = color == Color.White ? -1 : 1;
        }

        public override Move[] GetMoves(Board tiles)
        {
            var moves = new List<Move>(4);

            if (tiles[y + 1 * offset, x]?.IsEmpty() == true)
            {
                moves.Add(Factory.GetMove(tiles[Position], tiles[y + 1 * offset, x]));

                if (tiles[y + 2 * offset, x]?.IsEmpty() == true && IsOnInitialPosition())
                {
                    moves.Add(Factory.GetMove(tiles[Position], tiles[y + 2 * offset, x]));
                }
            }
            if (tiles[y + 1 * offset, x - 1]?.IsEmpty() == false)
            {
                moves.Add(Factory.GetMove(tiles[Position], tiles[y + 1 * offset, x - 1]));
            }
            if (tiles[y + 1 * offset, x + 1]?.IsEmpty() == false)
            {
                moves.Add(Factory.GetMove(tiles[Position], tiles[y + 1 * offset, x + 1]));
            }
            return moves.ToArray();
        }

        private bool IsOnInitialPosition()
        {
            return Color == Color.White ? y == CONSTANTS.MAX_Y - 1 : y == 1;
        }
    }
}