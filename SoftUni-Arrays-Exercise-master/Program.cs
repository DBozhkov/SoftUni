using System;
using System.Linq;

namespace LadyBugs
{
    class Program
    {
        static void Main()
        {
            int sizeOfField = int.Parse(Console.ReadLine());

            int[] ladybugsIndex = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] field = new int[sizeOfField];
            for (int i = 0; i < ladybugsIndex.Length; i++)
            {
                int currentIndex = ladybugsIndex[i];
                if (currentIndex >= 0 && currentIndex < field.Length)
                {
                    field[currentIndex] = 1;
                }

            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] elements = command.Split();
                int ladybugIndex = int.Parse(elements[0]);
                string directions = elements[1];
                int flyLength = int.Parse(elements[2]);

                if (ladybugIndex < 0 || ladybugIndex > field.Length - 1 || field[ladybugIndex] == 0)
                {
                    continue;
                }

                field[ladybugIndex] = 0;

                if (directions == "right")
                {
                    int landIndex = ladybugIndex + flyLength;

                    if (landIndex > field.Length - 1)
                    {
                        continue;
                    }

                    if (field[landIndex] == 1)
                    {
                        while (field[landIndex] == 1)
                        {
                            landIndex += flyLength;
                            if (landIndex > field.Length - 1)
                            {
                                break;
                            }
                        }
                    }

                    if (landIndex >= 0 && landIndex <= field.Length - 1)
                    {

                        field[landIndex] = 1;

                    }
                }

                else if (directions == "left")
                {
                    int landIndex = ladybugIndex - flyLength;

                    if (landIndex < 0)
                    {
                        continue;
                    }

                    if (field[landIndex] == 1)
                    {
                        while (field[landIndex] == 1)
                        {
                            landIndex -= flyLength;
                            if (landIndex < 0)
                            {
                                break;
                            }
                        }
                    }

                    if (landIndex >= 0 && landIndex <= field.Length - 1)
                    {

                        field[landIndex] = 1;

                    }

                }
            }
            Console.WriteLine(string.Join(' ', field));

        }
    }
}
