using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Players
{
    public class AIPlayer : IPlayer
    {
        public AIPlayer()
        {
            this.WinnerAnalizer = new GameWinnerAnalizer();
        }

        public GameWinnerAnalizer WinnerAnalizer { get; }

        public Index Play(Board board, Symbol symbol)
        {
            Index bestMove = null;
            int bestMoveValue = -9999;

            var moves = board.GetEmptyPositions();
            foreach (var move in moves)
            {
                board.PlaceSymbol(move, symbol);
                var value = MiniMax(board, symbol, symbol == Symbol.X ? Symbol.O : Symbol.X);
                board.PlaceSymbol(move, Symbol.None);

                if (value > bestMoveValue)
                {
                    bestMove = move;
                    bestMoveValue = value;
                }
            }
            return bestMove;
        }

        private int MiniMax(Board board, Symbol player, Symbol currentPlayer)
        {
            if (this.WinnerAnalizer.IsGameOver(board))
            {
                var winner = WinnerAnalizer.GetWinner(board);
                if (winner == player) return 1;
                else if (winner == Symbol.None) return 0;
                else return -1;
            }

            var bestValue = player == currentPlayer ? -100 : 100; 
            var availablePositions = board.GetEmptyPositions();
            foreach (var availablePos in availablePositions)
            {
                board.PlaceSymbol(availablePos, currentPlayer);
                var value = MiniMax(board, player, currentPlayer == Symbol.O ? Symbol.X : Symbol.O);
                board.PlaceSymbol(availablePos, Symbol.None);

                bestValue = currentPlayer == player ? Math.Max(bestValue, value) : Math.Min(bestValue, value);
            }
            return bestValue;
        }
    }
}
