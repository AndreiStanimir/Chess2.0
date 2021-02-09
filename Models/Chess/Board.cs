using Chess20.Common;
using Chess20.Models.Chess.Pieces;
using System.Collections.Generic;
using System.Linq;

namespace Chess20.Models.Chess
{
    public class Board
    {
        public const int MAX_X = 8;
        public const int MAX_Y = 8;
        public BoardTiles tiles { get; private set; }

        public Color sideToMove;
        public int halfmovesCount;
        public int fullmovesCount;
        public string castling;
        public bool CanWhiteCastle;
        public bool CanBlackCastle;
        public string enpassantTargetSquare;

        public Board()
        {
            tiles = new BoardTiles(MAX_X, MAX_Y);
        }

        public void SetPiece(Position pos, Piece piece)
        {
            piece.Position = pos;
            tiles[pos.Y, pos.X].SetPiece(piece, pos);
        }

        public override bool Equals(object obj)
        {
            if (obj is not Board)
                return false;
            var tiles2 = ((Board)obj).tiles;
            for (int i = 0; i < MAX_X; i++)
            {
                for (int j = 0; j < MAX_Y; j++)
                {
                    if (tiles2[i, j] != tiles[i, j])
                        return false;
                }
            }
            return true;
        }

        private void Turn()
        {
            //check if current player in check

            //check if checkmate
        }

        public IEnumerable<Tile> GetTilesWithPieces(Piece piece = null)
        {
            if (piece is null)
            {
                return tiles.GetTiles().Where(t => !t.IsEmpty());
            }
            else
                return tiles.GetTiles()
                    .Where(t => t.Piece != null)
                    .Where(t => piece.GetType().Equals(t?.Piece.GetType()));
        }

        public Tile? this[int y, int x]
        {
            get
            {
                if (CONSTANTS.IsInside(y, x))
                    return tiles[y, x];
                return null;
            }
            set
            {
                if (CONSTANTS.IsInside(y, x))
                    tiles[y, x] = value;
            }
        }

        public Tile? this[Position p]
        {
            get { return this[p.Y, p.X]; }
            set { tiles[p.Y, p.X] = value; }
        }
    }
}