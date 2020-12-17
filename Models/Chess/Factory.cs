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

        public static Pawn GetPawn(Color c)
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

            for (int i = 0; i < 8; i++)
            {
                var indexPiece = 0;
                for (int j = 0; j < boardLines[i].Length; j++)
                {
                    var c = boardLines[i][j];
                    int number;
                    bool isNum = int.TryParse(c.ToString(), out number);
                    if (isNum)
                    {
                        for (; indexPiece < number; indexPiece++)
                        {
                            board.tiles[i, j].SetPiece();
                        }
                    }
                    else
                    {
                        board.tiles[i, j].SetPiece(GetPiece(boardLines[i][j]), new Position(i, j));
                        indexPiece++;
                    }
                }
            }

            return board;
        }
    }
}