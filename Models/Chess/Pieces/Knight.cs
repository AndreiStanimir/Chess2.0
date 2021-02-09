using Chess20.Common;
using System.Collections.Generic;

namespace Chess20.Models.Chess.Pieces
{
    public class Knight : Piece
    {
        public Knight(Color color) : base(color, 'n')
        {
        }

        public override Move[] GetMoves(BoardTiles tiles)
        {
            var offsetsY = new int[] { -2, -2, 2, 2, -1, -1, 1, 1 };
            var offsetsX = new int[] { 1, -1, 1, -1, 2, -2, 2, -2 };
            var moves = new List<Move>(8);

            foreach (var offX in offsetsX)
            {
                foreach (var offY in offsetsY)
                {
                    Tile? destination = tiles[Position.Y + offY, Position.X + offX];
                    if (destination is not null)
                        moves.Add(Factory.GetMove(tiles[Position], destination));
                }
            }
            return moves.ToArray();
        }
    }
}