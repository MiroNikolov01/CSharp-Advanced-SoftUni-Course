namespace _02.AverageStudentGrades;

static class Program
{
    static void Main()
    {
        int countOfStudents = int.Parse(Console.ReadLine());

        Dictionary<string, List<decimal>> students = new();
        for (int i = 0; i < countOfStudents; i++)
        {
            string[] studentInformation = Console.ReadLine().Split();

            string name = studentInformation[0];
            decimal grade = decimal.Parse(studentInformation[1]);

            if (!students.ContainsKey(studentInformation[0]))
            {
                students[name] = new()
                {
                    grade
                };
                continue;
            }
            students[name].Add(grade);
        }
        foreach (var student in students)
        {
            Console.WriteLine($"{student.Key} -> {string.Join(' ', student.Value.Select(v => v.ToString("F2")))} (avg: {student.Value.Average():F2})");
        }

    }
}
 
