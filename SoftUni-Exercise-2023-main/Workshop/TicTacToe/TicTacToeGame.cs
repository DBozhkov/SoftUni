using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Players;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        public TicTacToeGame(IPlayer firstPlayer, IPlayer secondPlayer)
        {
            FirstPlayer = firstPlayer;
            SecondPlayer = secondPlayer;
            this.WinnerAnalizer = new GameWinnerAnalizer();
        }

        public IPlayer FirstPlayer { get; }

        public IPlayer SecondPlayer { get; }
        public GameWinnerAnalizer WinnerAnalizer { get; }

        public GameResult Play()
        {
            Board board = new Board();
            IPlayer currPlayer = FirstPlayer;
            Symbol symbol = Symbol.X;

            while (!this.WinnerAnalizer.IsGameOver(board))
            {
                var move = currPlayer.Play(board, symbol);
                board.PlaceSymbol(move, symbol);

                if (currPlayer == FirstPlayer)
                {
                    currPlayer = this.SecondPlayer;
                    symbol = Symbol.O;
                }
                else
                {
                    currPlayer = FirstPlayer;
                    symbol = Symbol.X;
                }
            }
            var winner = this.WinnerAnalizer.GetWinner(board);
            return new GameResult(winner, board);
        }
    }
}
