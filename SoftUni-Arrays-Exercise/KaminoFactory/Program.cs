using System;
using System.Linq;

namespace KaminoFactory
{
    class Program
    {
        static void Main()
        {
            int arrayLength = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            int bestLength = 1;
            int bestStartIndex = 0;
            int bestSequenceSum = 0;
            int bestSequenceIndex = 0;
            int[] bestSequence = new int[arrayLength];

            int counter = 0;

            while (input != "Clone them!")
            {
                int[] currSequence = input
                    .Split('!', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                counter++;

                int length = 1;
                int bestCurrLength = 1;
                int start = 0;
                int currentSum = 0;

                for (int i = 0; i < currSequence.Length - 1; i++)
                {
                    if (currSequence[i] == currSequence[i + 1])
                    {
                        length++;
                    }
                    else
                    {
                        length = 1;
                    }
                    if (length > bestCurrLength)
                    {
                        bestCurrLength = length;
                        start = i;
                    }
                    currentSum += currSequence[i];
                }
                currentSum += currSequence[arrayLength - 1];

                if (bestCurrLength > bestLength)
                {
                    bestLength = bestCurrLength;
                    bestStartIndex = start;
                    bestSequenceSum = currentSum;
                    bestSequenceIndex = counter;
                    bestSequence = currSequence.ToArray();
                }
                else if (bestCurrLength == bestLength)
                {
                    if (start < bestStartIndex)
                    {
                        bestLength = bestCurrLength;
                        bestStartIndex = start;
                        bestSequenceSum = currentSum;
                        bestSequenceIndex = counter;
                        bestSequence = currSequence.ToArray();
                    }
                    else if (start == bestStartIndex)
                    {
                        if (currentSum > bestSequenceSum)
                        {
                            bestLength = bestCurrLength;
                            bestStartIndex = start;
                            bestSequenceSum = currentSum;
                            bestSequenceIndex = counter;
                            bestSequence = currSequence.ToArray();
                        }
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Best DNA sample {bestSequenceIndex} with sum: {bestSequenceSum}.");
            Console.WriteLine(string.Join(' ', bestSequence));
        }
    }
}
