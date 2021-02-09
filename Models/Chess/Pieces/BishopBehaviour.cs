using Chess20.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess20.Models.Chess.Pieces
{
    public static class BishopBehaviour
    {
        public static Move[] GetMoves(BoardTiles tiles, Position position)
        {
            var moves = new List<Move>(9);

            moves.AddRange(GetMovesWithOffsets(tiles, position, 1, 1));
            moves.AddRange(GetMovesWithOffsets(tiles, position, 1, -1));
            moves.AddRange(GetMovesWithOffsets(tiles, position, -1, 1));
            moves.AddRange(GetMovesWithOffsets(tiles, position, -1, -1));

            return moves.ToArray();
        }

        private static List<Move> GetMovesWithOffsets(BoardTiles tiles, Position position, int offsetX, int offsetY)
        {
            var moves = new List<Move>(9);
            for (int y = position.Y, x = position.X; CONSTANTS.IsInside(y, x); y += offsetY, x += offsetX)
            {
                moves.Add(Factory.GetMove(tiles[position], tiles[y, x]));

                if (tiles[y, x]?.IsEmpty() == false)
                {
                    return moves;
                }
            }
            return moves;
        }
    }
}