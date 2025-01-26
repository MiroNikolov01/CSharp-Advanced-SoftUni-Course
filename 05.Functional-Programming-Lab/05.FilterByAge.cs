namespace _05.FiltssserBsssyAge;

class Program
{
    static void Main(string[] args)
    {
        int countPeople = int.Parse(Console.ReadLine());
        List<Student> students = new List<Student>();
        for (int i = 0; i < countPeople; i++)
        {
            string[] peopleInformation = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            students.Add(
                new Student(peopleInformation[0],
                    int.Parse(peopleInformation[1]
                    )));
        }

        string type = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());
        
        Func<Student, bool> filterAge = type switch
        {
            "older" => s => s.Age >= age,
            "younger" => s => s.Age < age,
            _ => s => true,
        };

        string selectorType = Console.ReadLine();

        Func<Student, string> filterNameOrAge = selectorType switch
        {
            "name" => s => $"{s.Name}",
            "name age" => s => $"{s.Name} - {s.Age}",
            "age" => s => $"{s.Age}",
            _ => s => null,
        };

        students
            .Where(filterAge)
            .Select(filterNameOrAge)
            .ToList()
            .ForEach(s => Console.WriteLine(s));
    }
}

public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Student(string name, int age)
    {
        Name = name;
        Age = age;
    }
}