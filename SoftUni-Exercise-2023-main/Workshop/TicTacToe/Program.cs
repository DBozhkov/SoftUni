using System;
using TicTacToe.Players;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Title = "Tic Tac Toe";
                Console.Clear();
                Console.WriteLine("========== Tic Tac Toe =========");
                Console.WriteLine("1. Player vs Player");
                Console.WriteLine("2. Player vs Random");
                Console.WriteLine("3. Random vs Player");
                Console.WriteLine("4. Player vs AI");
                Console.WriteLine("5. AI vs Player");
                Console.WriteLine("6. Simulate Random vs Random");
                Console.WriteLine("7. Simulate Random vs AI");
                Console.WriteLine("8. Simulate AI vs Random");
                Console.WriteLine("9. Simulate AI vs AI");
                Console.WriteLine("0. Exit");

                while (true)
                {
                    Console.Write("Please enter a number between 0 and 9: ");
                    var choice = Console.ReadLine();

                    if (choice == "0")
                    {
                        return;
                    }

                    if (choice == "1")
                    {
                        PlayGame(new ConsolePlayer(), new ConsolePlayer());
                        break;
                    }

                    else if (choice == "2")
                    {
                        PlayGame(new ConsolePlayer(), new RandomPlayer());
                        break;
                    }

                    if (choice == "3")
                    {
                        PlayGame(new RandomPlayer(), new ConsolePlayer());
                        break;
                    }

                    if (choice == "4")
                    {
                        PlayGame(new ConsolePlayer(), new AIPlayer());
                        break;
                    }

                    if (choice == "5")
                    {
                        PlayGame(new AIPlayer(), new ConsolePlayer());
                        break;
                    }

                    if (choice == "6")
                    {
                        SimulateGame(new RandomPlayer(), new RandomPlayer(), 1000);
                        break;
                    }

                    if (choice == "7")
                    {
                        SimulateGame(new RandomPlayer(), new AIPlayer(), 10);
                        break;
                    }

                    if (choice == "8")
                    {
                        SimulateGame(new AIPlayer(), new RandomPlayer(), 10);
                        break;
                    }

                    if (choice == "9")
                    {
                        SimulateGame(new AIPlayer(), new AIPlayer(), 10);
                        break;
                    }
                }
                Console.WriteLine("To continue, please press enter: ");
                Console.ReadLine();
            }
        }

        static void SimulateGame(IPlayer playerOne, IPlayer playerTwo, int count)
        {
            var first = playerOne;
            var second = playerTwo;
            int x = 0, o = 0, draw = 0;
            int firstWinnerResult = 0, secondWinnerResult = 0;

            for (int i = 0; i < count; i++)
            {
                var game = new TicTacToeGame(first, second);
                var result = game.Play();
                if (result.Winner == Symbol.X && first == playerOne) firstWinnerResult++;
                if (result.Winner == Symbol.O && first == playerOne) secondWinnerResult++;
                if (result.Winner == Symbol.X && first == playerTwo) secondWinnerResult++;
                if (result.Winner == Symbol.O && first == playerTwo) firstWinnerResult++;
                
                if (result.Winner == Symbol.X) x++;
                if (result.Winner == Symbol.O) o++;
                if (result.Winner == Symbol.None) draw++;

                (first, second) = (second, first);
            }

            Console.WriteLine("Games played: " + count);
            Console.WriteLine("Games won by X: " + x);
            Console.WriteLine("Games won by O: " + o);
            Console.WriteLine("Games that resulted in a draw: " + draw);
            Console.WriteLine($"{first.GetType().Name} Won games: {firstWinnerResult}");
            Console.WriteLine($"{second.GetType().Name} Won games: {secondWinnerResult}");
        }

        static void PlayGame(IPlayer firstPlayer, IPlayer secondPlayer)
        {
            var game = new TicTacToeGame(firstPlayer, secondPlayer);

            var result = game.Play();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Game over!");
            Console.WriteLine($"The winner is: {result.Winner}");
            Console.WriteLine(result.Board.ToString());
            Console.ResetColor();
        }
    }
}
