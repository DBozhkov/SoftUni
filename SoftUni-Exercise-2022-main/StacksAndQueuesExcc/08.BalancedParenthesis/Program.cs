using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.BalancedParentheses
{
    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();
            Stack<char> parentheses = new Stack<char>();
            bool isBalanced = true;

            foreach (char symbol in text)
            {
                if (symbol == '(' || symbol == '{' || symbol == '[')
                {
                    parentheses.Push(symbol);
                }
                else
                {
                    if (!parentheses.Any())
                    {
                        isBalanced = false;
                        break;
                    }
                    char current = parentheses.Pop();
                    bool isRound = current == '(' && symbol == ')';
                    bool isCurly = current == '{' && symbol == '}';
                    bool isSquared = current == '[' && symbol == ']';

                    if (!isRound && !isCurly && !isSquared)
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }
            Console.WriteLine(isBalanced ? "YES" : "NO");
        }
    }
}
