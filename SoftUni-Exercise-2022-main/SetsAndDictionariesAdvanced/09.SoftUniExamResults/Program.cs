using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> students = new Dictionary<string, int>();
            Dictionary<string, int> languages = new Dictionary<string, int>();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "exam finished")
            {
                string[] arr = command.Split('-');
                string userName = arr[0];

                if (arr.Length > 2)
                {
                    string language = arr[1];
                    int points = int.Parse(arr[2]);

                    if (!students.ContainsKey(userName))
                    {
                        students.Add(userName, points);
                    }
                    if (students.ContainsKey(userName) && students[userName] < points)
                    {
                        students[userName] = points;
                    }

                    if (!languages.ContainsKey(language))
                    {
                        languages.Add(language, 1);
                    }
                    else if (languages.ContainsKey(language))
                    {
                        languages[language]++;
                    }
                }

                else if (arr.Length <= 2 && arr[1] == "banned")
                {
                    students.Remove(userName);
                }
            }

            Console.WriteLine("Results:");
            var finalStudents = students.OrderByDescending(x => x.Value).ThenBy(y => y.Key).ToDictionary(x => x.Key, y => y.Value);
            foreach (var student in finalStudents)
            {
                Console.WriteLine($"{student.Key} | {student.Value}");
            }

            Console.WriteLine("Submissions:");
            var finalLanguages = languages.OrderByDescending(x => x.Value).ThenBy(y => y.Key).ToDictionary(x => x.Key, y => y.Value);
            foreach (var language in finalLanguages)
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}
