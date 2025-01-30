namespace _09.PredicateParty;

class Program
{
    static void Main(string[] args)
    {
        var names = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            

        string command = string.Empty;
        while ((command = Console.ReadLine()) != "Party!")
        {
            string[] tokens = command.Split();
            Func<string, bool> conditions = tokens[1] switch
            {
                "StartsWith" => n => n.StartsWith(tokens[2]),
                "EndsWith" => n => n.EndsWith(tokens[2]),
                "Length" => n => n.Length.ToString() == tokens[2],
                _ => throw new ArgumentException("Invalid command!")
            };
            List<string> peopleGoingToParty = new();
            if (tokens[0] == "Remove")
            {
                peopleGoingToParty = Remove(names, conditions);
            }
            else if (tokens[0] == "Double")
            {
                peopleGoingToParty = Double(names, conditions);
            }
            names = peopleGoingToParty.ToArray();
        }

        if (names.Length > 0)
        {
            Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
        }
        else
        {
            Console.WriteLine("Nobody is going to the party!");
        }
    }

    static List<string> Remove(string[] array, Func<string, bool> condition)
    {
        List<string> peopleGoing = new();
        for (int i = 0; i < array.Length; i++)
        {
            if (!condition(array[i]))
            {
                peopleGoing.Add(array[i]);
            }
        }
        
        return peopleGoing;
    }

    static List<string> Double(string[]array, Func<string, bool> condition)
    {
        List<string> peopleGoing = new();
        for (int i = 0; i < array.Length; i++)
        {
            if (condition(array[i])) peopleGoing.Add(array[i]);
            peopleGoing.Add(array[i]);
        }

        return peopleGoing;
    }
}