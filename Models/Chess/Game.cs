using System.Collections.Generic;
using System.Linq;

namespace Chess20.Models.Chess
{
    public class Game
    {
        public Board Board { get; set; }

        private enum GameState
        {
            W
        }

        private string clickedPiece;

        private async void Turn()
        {
            //check if current player in check
            var pieces = GetTilesWithPieces();

            var kingSymbol = 'K';
            if (Board.sideToMove == Common.Color.Black)
                kingSymbol = 'k';
            List<Move> moves = new List<Move>();

            foreach (var tile in pieces)
            {
                var piece = tile.Piece;
                if (!piece.IsPinned)
                {
                    moves.AddRange(piece.GetMoves(Board));
                }
            }
            var king = pieces.First(t => t.Piece.Symbol == kingSymbol);

            //check if checkmate
        }

        public IEnumerable<Tile> GetTilesWithPieces(char? pieceSymbol = null)
        {
            if (pieceSymbol is null)
            {
                return Board.GetTiles().Where(t => !t.IsEmpty());
            }
            else
                return Board.GetTiles()
                    .Where(t => t.Piece != null)
                    .Where(t => pieceSymbol.Equals(t?.Piece.Symbol));
        }
    }
}