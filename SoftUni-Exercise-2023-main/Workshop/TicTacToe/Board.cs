using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Board : IBoard
    {
        private Symbol[,] board;

        public Board(int rows, int cols)
        {
            if (rows != cols)
            {
                throw new ArgumentException("Rows should be equal to columns!");
            }

            Rows = rows;
            Cols = cols;
            board = new Symbol[rows, cols];
        }

        public Board() : this(3, 3)
        {

        }

        public int Rows { get; }

        public int Cols { get; }

        public Symbol[,] TBoard => this.board;

        public Symbol GetRowSymbols(int row)
        {
            var symbol = this.board[row, 0];

            if (symbol == Symbol.None)
            {
                return Symbol.None;
            }

            for (int col = 1; col < this.Cols; col++)
            {
                if (this.board[row, col] != symbol)
                {
                    return Symbol.None;
                }
            }

            return symbol;
        }

        public Symbol GetColSymbols(int col)
        {
            var symbol = this.board[0, col];

            if (symbol == Symbol.None)
            {
                return Symbol.None;
            }

            for (int row = 1; row < this.Rows; row++)
            {
                if (this.board[row, col] != symbol)
                {
                    return Symbol.None;
                }
            }

            return symbol;
        }

        public Symbol GetDiagonalTLBRSymbols()
        {
            var symbol = this.board[0, 0];

            if (symbol == Symbol.None)
            {
                return Symbol.None;
            }

            for (int i = 1; i < this.Rows; i++)
            {
                if (this.board[i, i] != symbol)
                {
                    return Symbol.None;
                }
            }

            return symbol;
        }

        public Symbol GetDiagonalTRBLSymbols()
        {
            var symbol = this.board[0, this.Rows - 1];

            if (symbol == Symbol.None)
            {
                return Symbol.None;
            }

            for (int row = 1; row < this.Rows; row++)
            {
                if (this.board[row, this.Rows - row - 1] != symbol)
                {
                    return Symbol.None;
                }
            }

            return symbol;
        }

        public bool IsFull()
        {
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    if (board[i, j] == Symbol.None)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void PlaceSymbol(Index index, Symbol symbol)
        {
            if (index.Row < 0 || index.Col < 0 || index.Row >= this.Rows || index.Col >= this.Cols)
            {
                throw new IndexOutOfRangeException("Index is out of range!");
            }

            this.board[index.Row, index.Col] = symbol;
        }

        public IEnumerable<Index> GetEmptyPositions()
        {
            List<Index> positions = new List<Index>();

            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    if (this.board[i, j] == Symbol.None)
                    {
                        positions.Add(new Index(i, j));
                    }
                }
            }
            return positions;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Cols; j++)
                {
                    if (this.board[i, j] == Symbol.None)
                    {
                        sb.Append('.');
                    }
                    else
                    {
                        sb.Append(this.board[i, j]);
                    }
                }
                sb.AppendLine();
            }

            return sb.ToString().TrimEnd();
        }
    }
}
