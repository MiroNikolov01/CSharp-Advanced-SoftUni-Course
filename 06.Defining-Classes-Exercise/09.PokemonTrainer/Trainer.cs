namespace _09.PokemonTrainer;

public class Trainer
{
    public int NumberOfBadges { get; set; }
    public readonly List<Pokemon> Pokemons;

    public Trainer() : this (0) {}
    public Trainer(int numberOfBadges)
    {
        NumberOfBadges = numberOfBadges;
        Pokemons = new List<Pokemon>();
    }
}