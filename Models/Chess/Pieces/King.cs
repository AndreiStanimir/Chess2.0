using Chess20.Common;
using System.Collections.Generic;

namespace Chess20.Models.Chess.Pieces
{
    public class King : Piece
    {
        public King(Color color) : base(color, 'k')
        {
        }

        public override Move[] GetMoves(BoardTiles tiles)
        {
            var moves = new List<Move>(9);
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i != 0 && j != 0)
                    {
                        Tile? destination = tiles[Position.Y + i, Position.X + j];
                        if (destination is not null)
                            if (!destination.IsAttacked)
                                moves.Add(Factory.GetMove(tiles[Position], destination));
                    }
                }
            }
            return moves.ToArray();
        }
    }
}