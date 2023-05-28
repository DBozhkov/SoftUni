using NUnit.Framework;
using System.Linq;
using TicTacToe;

namespace TicTacToeTests
{
    [TestFixture]
    public class BoardTests
    {
        [Test]
        public void IsFullShouldReturnTrueForFullBoard()
        {
            var board = new Board(3, 3);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.IsFalse(board.IsFull());
                    board.PlaceSymbol(new Index(i, j), Symbol.X);
                }
            }

            Assert.IsTrue(board.IsFull());
        }

        [Test]
        public void GetRowSymbolsShouldWorkCorrectly()
        {
            var board = new Board(4, 4);

            for (int i = 0; i < board.Cols; i++)
            {
                Assert.AreEqual(Symbol.None, board.GetRowSymbols(2));
                board.PlaceSymbol(new Index(2, i), Symbol.X);
            }

            Assert.AreEqual(Symbol.X, board.GetRowSymbols(2));
        }

        [TestCase(Symbol.X)]
        [TestCase(Symbol.O)]
        public void GetColSymbolsShouldWorkCorrectly(Symbol symbol)
        {
            var board = new Board(5, 5);

            for (int i = 0; i < board.Rows; i++)
            {
                Assert.AreEqual(Symbol.None, board.GetColSymbols(3));
                board.PlaceSymbol(new Index(i, 3), symbol);
            }

            Assert.AreEqual(symbol, board.GetColSymbols(3));
        }

        [Test]
        public void GetEmptyPositionsShouldReturnAllBoardEmptyPositions()
        {
            var board = new Board(3, 3);
            var positions = board.GetEmptyPositions();

            Assert.AreEqual(3 * 3, positions.Count());
        }

        [Test]
        public void GetEmptyPositionsShouldReturnCorrectNumberOfPositions()
        {
            var board = new Board(5, 5);
            board.PlaceSymbol(new Index(1, 1), Symbol.X);
            board.PlaceSymbol(new Index(2, 2), Symbol.O);

            var positions = board.GetEmptyPositions();

            Assert.AreEqual(5 * 5 - 2, positions.Count());
        }
    }
}