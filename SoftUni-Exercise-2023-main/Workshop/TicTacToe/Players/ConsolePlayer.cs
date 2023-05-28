using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe.Players
{
    public class ConsolePlayer : IPlayer
    {
        public Index Play(Board board, Symbol symbol)
        {
            Console.WriteLine(board.ToString());

            Index position;

            while (true)
            {
                Console.Write("Please enter position (0,0): ");
                var line = Console.ReadLine();

                try
                {
                    position = new Index(line);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid position format!");
                    continue;
                }

                if (!board.GetEmptyPositions().Any(x => x.Equals(position)))
                {
                    Console.WriteLine("This position is not available!");
                    continue;
                }

                break;
            }

            return position;
        }
    }
}
