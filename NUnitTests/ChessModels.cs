using Chess20.Models.Chess;
using Chess20.Models.Chess.Pieces;
using NUnit.Framework;
using System.Linq;

namespace NUnitTests
{
    [TestFixture]
    public class ChessModels
    {
        [Test]
        public void FenStartBoard()
        {
            // TODO: Add your test code here
            var Board1 = Factory.GetNewBoard();
            var Board2 = Factory.GetBoardFromFEN("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
            var board3 = Factory.GetBoardFromFEN("rnbqkbnr/pppppppp/8/8/4P3/8/PPPP1PPP/RNBQKBNR w KQkq - 0 1");
            //Assert.AreEqual(Board1.tiles[1, 4].Piece.Position, Board2.tiles[1, 4].Piece.Position);
            //Assert.AreEqual(Board1.tiles[6, 7].Piece.Position, Board2.tiles[6, 7].Piece.Position);
            //Assert.AreEqual(Board1.tiles[6, 7].Piece, Board2.tiles[6, 7].Piece);
            //Assert.AreEqual(Board1.tiles[7, 1].Piece.Position, Board2.tiles[7, 1].Piece.Position);
            //Assert.AreEqual(Board1.tiles[7, 1].Piece, Board2.tiles[7, 1].Piece);
            //Assert.AreEqual(Board1.tiles[7, 1], Board2.tiles[7, 1]);
            var tile1 = Board1.tiles.GetTiles().ToList();
            var tile2 = Board2.tiles.GetTiles().ToList();
            CollectionAssert.AreEqual(tile1, tile2);
            Assert.AreNotEqual(Board1.tiles, board3.tiles);
            //Assert.AreEqual(Board1, Board2);
        }

        [Test]
        public void ConvertBoardToFen()
        {
            const string startPosition = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";

            var board1 = Factory.GetBoardFromFEN(startPosition);
            var board1Fen = Factory.GetFenFromBoard(board1);
            Assert.AreEqual(startPosition, board1Fen);

            const string randomPuzzle = "r1bq2rk/1p1p4/p1n1pPQp/3n4/4N3/1N1Bb3/PPP3PP/R4R1K w KQkq - 0 1";
            var board = Factory.GetBoardFromFEN(randomPuzzle);
            var actualFen = Factory.GetFenFromBoard(board);
            Assert.AreEqual(randomPuzzle, actualFen);
        }

        [Test]
        public void PawnMoves()
        {
            var board = Factory.GetNewBoard();
            var tiles = board.GetTilesWithPieces(Factory.GetPawn());

            Position position = new Position(6, 4);
            var pawn = tiles
                .Where(t => t.Piece.Position.Equals(position))
                .First();
            Move[] actualMoves = pawn.Piece.GetMoves(board.tiles);
            Move[] expectedMoves = new Move[]
               {
                    new Move(pawn,new Tile(position.Y-1,position.X)),
                    new Move(pawn,new Tile(position.Y-2,position.X))
               };
            Assert.IsTrue(AreMovesEqual(actualMoves, expectedMoves));

            position = new Position(1, 5);
            pawn = tiles
                .Where(t => t.Piece.Position.Equals(position))
                .First();
            actualMoves = pawn.Piece.GetMoves(board.tiles);
            expectedMoves = new Move[]
               {
                    new Move(pawn,new Tile(position.Y+1,position.X)),
                    new Move(pawn,new Tile(position.Y+2,position.X))
               };
            Assert.IsTrue(AreMovesEqual(actualMoves, expectedMoves));
            //foreach (var piece in tiles)
            //{
            //    Move[] moves = piece.Piece.GetMoves(board.tiles);
            //    Move[] expectedMoves = new Move[]
            //    {
            //        new Move(piece,new Tile()
            //    }
            //    }
        }

        private bool AreMovesEqual(Move[] moves, Move[] moves1)
        {
            return moves.All(m =>
                moves1.Where(move =>
                m.Source.Position.Equals(move.Source.Position)
                && m.Target.Position.Equals(move.Target.Position))
                .Count() == 1
            );
        }
    }
}