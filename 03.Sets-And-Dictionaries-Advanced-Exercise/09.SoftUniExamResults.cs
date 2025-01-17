using System.Reflection.PortableExecutable;

namespace _09.SoftUniExamResults;

class Program
{
    static void Main()
    {
        string command;
        Dictionary<string, int> studentResults = new(); // Student -> Points
        Dictionary<string, int> languageCount = new(); // Language -> Count

        while ((command = Console.ReadLine()) != "exam finished")
        {
            string[] arguments = command
                .Split("-", StringSplitOptions.RemoveEmptyEntries);
            string student = arguments[0];

            if (arguments.Length == 3) // Adding students and languages to the dictionaryes
            {
                string language = arguments[1];
                int points = int.Parse(arguments[2]);
                
                AddStudents(studentResults, student, points);
                AddLanguages(languageCount, language);
            }
            else if (arguments.Length < 3) // Banning student
            {
                if (studentResults.ContainsKey(student))
                {
                    studentResults.Remove(student);
                }
            }
        }

        Console.WriteLine("Results:");
        foreach (var (student, points) in studentResults.OrderByDescending(student => student.Value).ThenBy(n => n.Key))
        {
            Console.WriteLine($"{student} | {points}");
        }

        Console.WriteLine("Submissions:");
        foreach (var (language, count) in
                 languageCount.OrderByDescending(language => language.Value).ThenBy(n => n.Key))
        {
            Console.WriteLine($"{language} - {count}");
        }
    }

    static void AddStudents(Dictionary<string, int> studentResults, string student, int points)
    {
        if (!studentResults.ContainsKey(student))
        {
            studentResults.Add(student, points);
        }

        if (studentResults[student] < points)
        {
            studentResults[student] = points;
        }
    }

    static void AddLanguages(Dictionary<string, int> languageCount, string language)
    {
        if (!languageCount.ContainsKey(language))
        {
            languageCount.Add(language, 0);
        }

        languageCount[language]++;
    }
}