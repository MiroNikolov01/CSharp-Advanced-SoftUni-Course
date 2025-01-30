namespace _10.ThePartyReservationFilterModule;

public class Program
{
    static void Main(string[] args)
    {
        string argument = string.Empty;
        Dictionary<string, Func<string, bool>> filters = new Dictionary<string, Func<string, bool>>
        {
            ["Starts with"] = name => name.StartsWith(argument),
            ["Ends with"] = name => name.EndsWith(argument),
            ["Length"] = name => name.Length == int.Parse(argument),
            ["Contains"] = name => name.Contains(argument),
        };

        string[] partyGoers = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        List<(string Type, string Arg)> appliedFilters = new List<(string Type, string Arg)>();
        string command;
        while ((command = Console.ReadLine()) != "Print")
        {
            string[] filterData = command
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            string action = filterData[0];
            string filterType = filterData[1];
            argument = filterData[2];

            if (action == "Add filter")
            {
                appliedFilters.Add((filterType, argument));
            }
            else if (action == "Remove filter")
            {
                appliedFilters.RemoveAll(f => f.Type == filterType && f.Arg == argument);
            }
        }

        foreach (var (filterType, arg) in appliedFilters)
        {
            argument = arg;
            partyGoers = partyGoers.Where(name => !filters[filterType](name)).ToArray();
        }

        Console.WriteLine(string.Join(" ", partyGoers));
    }
}