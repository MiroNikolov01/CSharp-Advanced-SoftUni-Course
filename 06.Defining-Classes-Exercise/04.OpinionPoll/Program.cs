using DefiningClasses;

public class Program
{
    static void Main(string[] args)
    {
        List<Person> people = new List<Person>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] personData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Person person = new Person(personData[0], int.Parse(personData[1]));
            people.Add(person);
        }

        Func<Person, bool> ageFilter = person => person.Age > 30;
        foreach (var person in people.Where(ageFilter).OrderBy(n => n.Name))
        {
            Console.WriteLine(person.Name + " - " + person.Age);
        }
    }
}