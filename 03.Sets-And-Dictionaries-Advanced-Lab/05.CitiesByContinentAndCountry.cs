
namespace _05.CitiesByContinentAndCountry;

static class Program
{
    static void Main()
    {
        int countContinents = int.Parse(Console.ReadLine());
        Dictionary<string, Continent> continentMap = new Dictionary<string, Continent>();
        for (int i = 0; i < countContinents; i++)
        {
            string[] tokens = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string continent = tokens[0];
            string country = tokens[1];
            string city = tokens[2];

            if (!continentMap.ContainsKey(continent))
            {
                continentMap[continent] = new Continent();
            }

            continentMap[continent].AddCity(country, city);

        }
        foreach (var continent in continentMap)
        {
            Console.WriteLine($"{continent.Key}:");

            foreach (var country in continent.Value.Countries)
            {
                Console.WriteLine($" {country.Key} -> {string.Join(", ", country.Value)}");
            }
        }
    }
}
class Continent
{
    public Dictionary<string, List<string>> Countries { get; set; } = new Dictionary<string, List<string>>();
    public void AddCity( string country, string city)
    {
        if (!Countries.ContainsKey(country))
        {
            Countries.Add(country, new List<string>());
        }
        Countries[country].Add(city);
    }
}