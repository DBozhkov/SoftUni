using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class GameWinnerAnalizer
    {
        public Symbol GetWinner(Board board)
        {
            for (int row = 0; row < board.Rows; row++)
            {
                var winner = board.GetRowSymbols(row);
                if (board.GetRowSymbols(row) != Symbol.None)
                {
                    return winner;
                }
            }

            for (int col = 0; col < board.Cols; col++)
            {
                var winner = board.GetColSymbols(col);
                if (board.GetColSymbols(col) != Symbol.None)
                {
                    return winner;
                }
            }

            var firstDiagonal = board.GetDiagonalTLBRSymbols();
            if (board.GetDiagonalTLBRSymbols() != Symbol.None)
            {
                return firstDiagonal;
            }

            var secondDiagonal = board.GetDiagonalTRBLSymbols();
            if (board.GetDiagonalTRBLSymbols() != Symbol.None)
            {
                return secondDiagonal;
            }

            return Symbol.None;
        }

        public bool IsGameOver(Board board)
        {
            for (int row = 0; row < board.Rows; row++)
            {
                if (board.GetRowSymbols(row) != Symbol.None)
                {
                    return true;
                }
            }

            for (int col = 0; col < board.Cols; col++)
            {
                if (board.GetColSymbols(col) != Symbol.None)
                {
                    return true;
                }
            }

            if (board.GetDiagonalTLBRSymbols() != Symbol.None)
            {
                return true;
            }

            if (board.GetDiagonalTRBLSymbols() != Symbol.None)
            {
                return true;
            }

            return board.IsFull();
        }
    }
}

