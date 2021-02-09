using Chess20.Common;
using Chess20.Models.Chess.Pieces;

namespace Chess20.Models.Chess
{
    public static class Factory
    {
        private const int MAX_X = 8;

        public static Game GetNewGame()
        {
            var game = new Game();
            return game;
        }

        public static Board GetNewBoard()
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

        public static Pawn GetPawn(Color c = Color.White)
        {
            return new Pawn(c);
        }

        public static Piece GetPiece(char piece)
        {
            switch (piece)
            {
                case 'p':
                    return new Pawn(Color.Black);

                case 'b':
                    return new Bishop(Color.Black);

                case 'k':
                    return new King(Color.Black);

                case 'n':
                    return new Knight(Color.Black);

                case 'q':
                    return new Queen(Color.Black);

                case 'r':
                    return new Rook(Color.Black);

                case 'P':
                    return new Pawn(Color.White);

                case 'B':
                    return new Bishop(Color.White);

                case 'K':
                    return new King(Color.White);

                case 'N':
                    return new Knight(Color.White);

                case 'Q':
                    return new Queen(Color.White);

                case 'R':
                    return new Rook(Color.White);
            }
            return null;
        }

        public static Board GetBoardFromFEN(string fen)
        {
            Board board = new();

            var fen_split = fen.Split(' ');

            var boardLines = fen_split[0].Split('/');
            var sideToMove = fen_split[1];
            var castling = fen_split[2];
            var enpassantTargetSquare = fen_split[3];
            var halfmovesCount = fen_split[4];
            var fullmovesCount = fen_split[5];

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0, iLine = 0; x < 8 && iLine < boardLines[y].Length; iLine++)
                {
                    var c = boardLines[y][iLine];
                    int number;
                    bool isNum = int.TryParse(c.ToString(), out number);
                    if (isNum)
                    {
                        for (int indexPiece = 0; indexPiece < number; indexPiece++, x++)
                        {
                            board.tiles[y, x].SetPiece();
                        }
                    }
                    else
                    {
                        board.tiles[y, x].SetPiece(GetPiece(boardLines[y][iLine]), new Position(y, x));
                        x++;
                    }
                }
            }

            return board;
        }

        public static Move GetMove(Tile source, Tile destination)
        {
            return new Move(source, destination);
        }
    }
}