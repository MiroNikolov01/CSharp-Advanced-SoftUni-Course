namespace _09.PokemonTrainer;

public class Program
{
    static void Main()
    {
        Dictionary<string, Trainer> trainers = ReadData();

        string element;
        while ((element = Console.ReadLine()) != "End")
        {
            foreach (var trainer in trainers)
            {
                if (trainer.Value.Pokemons.Any(x => x.Element == element))
                {
                    trainer.Value.NumberOfBadges++;
                }
                else
                {
                    trainer.Value.Pokemons.ForEach(p => p.Health -= 10);
                    trainer.Value.Pokemons.RemoveAll(x => x.Health <= 0);
                }
            }
        }
        
        foreach (var trainerValue in trainers.OrderByDescending(p => p.Value.NumberOfBadges))
        {
            Console.WriteLine($"{trainerValue.Key} {trainerValue.Value.NumberOfBadges} {trainerValue.Value.Pokemons.Count}");
        }
    }
    static Dictionary<string, Trainer> ReadData()
    {
        Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();
        string command;
        while ((command = Console.ReadLine()) != "Tournament")
        {
            string[] data = command.Split(' '
                , StringSplitOptions.RemoveEmptyEntries);

            string trainerName = data[0];
            string pokemonName = data[1];
            string pokemonElement = data[2];
            int pokemonHealth = int.Parse(data[3]);

            Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

            if (trainers.ContainsKey(trainerName) == false)
            {
                trainers[trainerName] = new Trainer();
            }
            trainers[trainerName].Pokemons.Add(pokemon);
        }
        return trainers;
    }
}