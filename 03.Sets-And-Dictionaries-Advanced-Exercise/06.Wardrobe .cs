using System.Reflection.Metadata;

namespace _06.Wardrobe;
internal class Program
{
    static void Main()
    {
        Dictionary<string, Wardrobe> clothesMap = new();
        int numberOfLines = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfLines; i++)
        {
            string[] arguments = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

            string[] clothes = arguments[1].Split(',');

            string color = arguments[0];

            if (!clothesMap.ContainsKey(color))
            {
                clothesMap.Add(color, new Wardrobe());
            }

            for (int j = 0; j < clothes.Length; j++)
            {
                if (clothesMap.ContainsKey(color))
                {
                    if (!clothesMap[color].Clothes.ContainsKey(clothes[j]))
                    {
                        clothesMap[color].Clothes.Add(clothes[j], 0);
                    }
                    clothesMap[color].Clothes[clothes[j]]++;
                }
            }
        }
        string[] clothesSearch = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string clothesColor = clothesSearch[0];
        string clothesType = clothesSearch[1];

        foreach (var clothes in clothesMap)
        {
            Console.WriteLine($"{clothes.Key} clothes:");

            foreach (var item in clothes.Value.Clothes)
            {
                if (clothesColor == clothes.Key && clothesType == item.Key)
                {
                    Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                }
                else
                {
                    Console.WriteLine($"* {item.Key} - {item.Value}");
                }
            }
        }
    }
}
public class Wardrobe
{
    public Dictionary<string, int> Clothes { get; set; } = new();
}