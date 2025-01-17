using System.Data;
using System.Net.Http.Headers;

namespace _07.TheVLogger;
internal class Program
{
    static void Main()
    {
        Dictionary<string, Vlogger> vloggerMap = new();

        bool isStatistics = false;
        while (!isStatistics)
        {
            string command = Console.ReadLine();
            string[] arguments = command
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (arguments[0] == "Statistics")
            {
                isStatistics = true;
                continue;
            }
            string vloggerName = arguments[0];

            Vlogger vlogger = new Vlogger();
            switch (arguments[1])
            {
                case "joined":
                    vlogger.AddVlogger(vloggerName, vloggerMap);
                    break;
                case "followed":
                    string followedVlogger = arguments[2];
                    vlogger.FollowVlogger(followedVlogger, vloggerName, vloggerMap);
                    break;
            }
        }

        Console.WriteLine($"The V-Logger has a total of {vloggerMap.Count} vloggers in its logs.");

        var mostFamousVlogger = vloggerMap
            .OrderByDescending(v => v.Value.Followers.Count)
            .ThenBy(v => v.Value.Following.Count)
            .FirstOrDefault();

        int count = 1;

        if (mostFamousVlogger.Value != null)
        {
            Console.WriteLine(
                $"{count}. {mostFamousVlogger.Key} : {mostFamousVlogger.Value.Followers.Count} followers, {mostFamousVlogger.Value.Following.Count} following");

            var lexicographicalOrder = mostFamousVlogger.Value.Followers.OrderBy(n => n);
            foreach (var follower in lexicographicalOrder)
            {
                Console.WriteLine($"*  {follower}");
            }
        }

        var vlogerStatistics = vloggerMap
            .OrderByDescending(v => v.Value.Followers.Count)
            .ThenBy(v => v.Value.Following.Count)
            .Where(k => k.Key != mostFamousVlogger.Key)
            .ToList();

        foreach (var statisticsVlogger in vlogerStatistics)
        {
            Console.WriteLine($"{++count}. {statisticsVlogger.Key} : {statisticsVlogger.Value.Followers.Count} followers, {statisticsVlogger.Value.Following.Count} following");
        }
    }
}
class Vlogger
{
    public HashSet<string> Followers { get; set; } = new HashSet<string>();
    public HashSet<string> Following { get; set; } = new HashSet<string>();
    public void AddVlogger(string vlogger, Dictionary<string, Vlogger> mapVloggers)
    {
        if (!mapVloggers.ContainsKey(vlogger))
        {
            mapVloggers[vlogger] = new Vlogger();
        }
    }

    public void FollowVlogger(string followedVlogger, string vlogger, Dictionary<string, Vlogger> mapVloggers)
    {

        if (mapVloggers.ContainsKey(vlogger) &&
           mapVloggers.ContainsKey(followedVlogger))
        {
            if (followedVlogger == vlogger)
            {
                return;
            }

            mapVloggers[vlogger].Following.Add(followedVlogger);
            mapVloggers[followedVlogger].Followers.Add(vlogger);
        }
    }
}