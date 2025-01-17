namespace _10.ForceBook;

class Program
{
    static void Main()
    {
        //Force Side
        Dictionary<string, ForceUser> forceSideMap = new(); //Force Side -> ForceUser -> Members
        string command;
        while ((command = Console.ReadLine()) != "Lumpawaroo")
        {
            bool isDelimiter = command.Contains("|");
            bool isArrow = command.Contains(" -> ");
            if (command.Contains("|"))
            {
                isDelimiter = true;
            }
            else if (command.Contains(" -> "))
            {
                isArrow = true;
            }

            string[] arguments = command.Split(new string[] { " | ", " -> " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(arg => arg.Trim())
                .ToArray();
            string forceSide = arguments[0];
            string forceUser = arguments[1];

            if (isDelimiter)
            {
                if (!forceSideMap.Values.Any(side => side.Members.Contains(forceUser)))
                {
                    //Adds the new ForceSide and memeber
                    if (!forceSideMap.ContainsKey(forceSide))
                    {
                        forceSideMap.Add(forceSide, new ForceUser());
                    }

                    forceSideMap[forceSide].Members.Add(forceUser);
                }
            }
            else if (isArrow)
            {
                if (isArrow)
                {
                    forceUser = arguments[0];
                    forceSide = arguments[1];

                    // logic if the user is already in some clan
                    
                    if (!forceSideMap.ContainsKey(forceSide))
                    {
                        forceSideMap.Add(forceSide, new ForceUser());
                    }

                    if (!forceSideMap[forceSide].Members.Contains(forceUser))
                    {
                       Program.RemoveFromOtherClan(forceSideMap, forceUser, forceSide);
                        AddMemberToForceSide(forceSideMap, forceSide, forceUser);
                    }
                   
                }
            }
        }

        foreach (var force in forceSideMap.OrderByDescending(x => x.Value.Members.Count).ThenBy(x => x.Key))
        {
            if (force.Value.Members.Count > 0)
            {
                Console.WriteLine($"Side: {force.Key}, Members: {force.Value.Members.Count}");
                foreach (var user in force.Value.Members.OrderBy(n => n))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }

    public static void AddMemberToForceSide(Dictionary<string, ForceUser> forceSideMap, string forceSide,
        string forceUser)
    {
        if (!forceSideMap.ContainsKey(forceSide))
        {
            forceSideMap.Add(forceSide, new ForceUser());
        }

        forceSideMap[forceSide].Members.Add(forceUser);
        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
    }

    static void RemoveFromOtherClan(Dictionary<string, ForceUser> forceSideMap, string forceUser, string forceSide)
    {
        foreach (var forceSideKey in forceSideMap)
        {
            if (forceSideKey.Value.Members.Contains(forceUser) &&
                forceSideKey.Key != forceSide)
            {
                forceSideMap[forceSideKey.Key].Members.Remove(forceUser);
                return;
            }
        }
    }
}

class ForceUser
{
    public HashSet<string> Members { get; set; } = new();
}