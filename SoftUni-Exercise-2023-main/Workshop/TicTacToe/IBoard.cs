using System.Collections;
using System.Collections.Generic;

namespace TicTacToe
{
    public interface IBoard
    {
        bool IsFull();

        void PlaceSymbol(Index index, Symbol symbol);

        IEnumerable<Index> GetEmptyPositions();

        Symbol GetRowSymbols(int row);

        Symbol GetColSymbols(int col);

        Symbol GetDiagonalTRBLSymbols();

        Symbol GetDiagonalTLBRSymbols();
    }
}
