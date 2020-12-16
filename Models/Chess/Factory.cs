using Chess20.Common;
using Chess20.Models.Chess.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chess20.Models.Chess
{
    public class Factory
    {
        private const int MAX_X = 8;
        public Game GetNewGame()
        {
            var game = new Game();
            return game;
        }
        public Board GetNewBoard()
        {
            const string startingPositionPieces = "rnbqkbnr";
            const string startingPositionPiecesWhite = "RNBQKBNR";
            var board = new Board();
            for (int i = 0; i < MAX_X; i++)
            {
                board.SetPiece(new Position(0, i), GetPiece(startingPositionPieces[i]));
                board.SetPiece(new Position(7, i), GetPiece(startingPositionPiecesWhite[i]));

                board.SetPiece(new Position(1, i), GetPawn(Color.Black));
                board.SetPiece(new Position(6, i), GetPawn(Color.White));
            }

            return board;
        }
        public Pawn GetPawn(Color c)
        {
            return new Pawn(c);
        }
        public Piece GetPiece(char piece)
        {
            Dictionary<char, Piece> pieceDictionary = new Dictionary<char, Piece>
            {
                {'p',new Pawn(Color.Black)},
                {'b',new Bishop(Color.Black)},
                {'k',new King(Color.Black)},
                {'n',new Knight(Color.Black)},
                {'q',new Queen(Color.Black)},
                {'r',new Rook(Color.Black)},

                {'P',new Pawn(Color.White)},
                {'B',new Bishop(Color.White)},
                {'K',new King(Color.White)},
                {'N',new Knight(Color.White)},
                {'Q',new Queen(Color.White)},
                {'R',new Rook(Color.White)},
            };
            return pieceDictionary[piece];
        }
    }
}