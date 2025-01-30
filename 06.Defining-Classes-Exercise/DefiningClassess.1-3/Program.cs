namespace DefiningClasses;

public class StartUp
{
    static void Main(string[] args)
    {
        Family family = new Family();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] personData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Person person = new Person(personData[0], int.Parse(personData[1]));
            family.AddMember(person);
        }

        var oldest = family.ReturnOldestMember();
        Console.WriteLine(oldest.Name + " " + oldest.Age);
    }
}