using Chess20.Models.Chess;
using NUnit.Framework;

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
            Assert.AreEqual(Board1.tiles[1, 4].Piece.Position, Board2.tiles[1, 4].Piece.Position);
            Assert.AreEqual(Board1.tiles[6, 7].Piece, Board2.tiles[6, 7].Piece);
            Assert.AreEqual(Board1.tiles[7, 1].Piece.Position, Board2.tiles[7, 1].Piece.Position);
            Assert.AreEqual(Board1.tiles[7, 1].Piece, Board2.tiles[7, 1].Piece);
            Assert.AreEqual(Board1.tiles[7, 1], Board2.tiles[7, 1]);
            Assert.AreEqual(Board1.tiles, Board2.tiles);
            Assert.AreNotEqual(Board1.tiles, board3.tiles);
            //Assert.AreEqual(Board1, Board2);
        }
    }
}