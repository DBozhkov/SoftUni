using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TicTacToe;
using TicTacToe.Players;

namespace TicTacToeTests
{
    [TestFixture]
    class TicTacToeGameTests
    {
        [Test]
        public void PlayShouldReturnValue()
        {
            var player = new Mock<IPlayer>();
            player.Setup(x => x.Play(It.IsAny<Board>(), It.IsAny<Symbol>())).Returns((Board x, Symbol s) =>
            {
                return x.GetEmptyPositions().First();
            }
            );

            var game = new TicTacToeGame(player.Object, player.Object);
        }

        [Test]
        public void PlayShouldReturnCorrectWinner()
        {
            var playerOneCurrentCol = 0;
            var firstPlayer = new Mock<IPlayer>();
            firstPlayer.Setup(x => x.Play(It.IsAny<Board>(), It.IsAny<Symbol>())).Returns((Board x, Symbol s) => new Index(0, playerOneCurrentCol++));

            var playerTwoCurrentCol = 0;
            var secondPlayer = new Mock<IPlayer>();
            secondPlayer.Setup(x => x.Play(It.IsAny<Board>(), It.IsAny<Symbol>())).Returns((Board x, Symbol s) => new Index(1, playerTwoCurrentCol++));

            var game = new TicTacToeGame(firstPlayer.Object, secondPlayer.Object);
            var winner = game.Play();

            Assert.AreEqual(Symbol.X, winner);
        }
    }
}
