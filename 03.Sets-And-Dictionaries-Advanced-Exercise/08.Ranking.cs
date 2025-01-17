namespace _08.Ranking;
internal class Program
{
    static void Main()
    {
        Contest contests = new Contest();
        Dictionary<string, Participant> participantsMap = new Dictionary<string, Participant>();

        //Reading and adding contests
        string inputContests;
        while ((inputContests = Console.ReadLine()) != "end of contests")
        {
            string[] tokens = inputContests
                .Split(':', StringSplitOptions.RemoveEmptyEntries);
            string contestName = tokens[0];
            string contestPassword = tokens[1];

            contests.AddContest(contestName, contestPassword);
        }

        //Reading and adding users
        string inputParticipants;
        while ((inputParticipants = Console.ReadLine()) != "end of submissions")
        {
            string[] arguments = inputParticipants
                .Split("=>", StringSplitOptions.RemoveEmptyEntries);

            string contest = arguments[0];
            string password = arguments[1];
            string username = arguments[2];
            int points = int.Parse(arguments[3]);

            Participant participant = new Participant();

            if (contests.Contests.ContainsKey(contest) && contests.Contests[contest] == password)
            {
                participant.RegisterOrUpdateParticipant(participantsMap, username, contest, points);
            }
        }
        var bestCandidate = participantsMap
            .OrderByDescending(u => u.Value.TotalPoints)
            .FirstOrDefault();

        Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {bestCandidate.Value.TotalPoints} points.");

        Console.WriteLine("Ranking:");
        foreach (var student in participantsMap.OrderBy(n => n.Key)) // Sorting by Name
        {
            Console.WriteLine($"{student.Key}"); 

            foreach (var contest in student.Value.Contests.OrderByDescending(v => v.Value)) // Sorting by contest points
            {
                Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
            }
        }
    }
}
class Contest
{
    //Adding contests
    public Dictionary<string, string> Contests { get; set; } = new();
    public void AddContest(string contest, string password)
    {
        if (!Contests.ContainsKey(contest))
        {
            Contests.Add(contest, password);
        }
    }
}
class Participant
{
    public int TotalPoints { get; set; }
    public Dictionary<string, int> Contests { get; set; } = new();

    public void RegisterOrUpdateParticipant(Dictionary<string, Participant> participantMap, string participant, string contest, int points)
    {

        if (!participantMap.ContainsKey(participant))
        {
            participantMap.Add(participant, new Participant());
        }

        if (participantMap[participant].Contests.ContainsKey(contest))
        {
            //Updating contest points only if the points are greater than the previous
            if (participantMap[participant].Contests[contest] < points)
            {
                participantMap[participant].TotalPoints += points - participantMap[participant].Contests[contest];
                participantMap[participant].Contests[contest] = points;
            }
        }
        else
        {
            participantMap[participant].Contests.Add(contest, points);
            participantMap[participant].TotalPoints += points;
        }
    }
}

