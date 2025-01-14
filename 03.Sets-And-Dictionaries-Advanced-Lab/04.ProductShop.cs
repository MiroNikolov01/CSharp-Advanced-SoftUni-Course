using System.Security.Cryptography;

namespace _04.ProductShop;

static class Program
{
    /*
lidl, juice, 2.30 
fantastico, apple, 1.20 
kaufland, banana, 1.10 
fantastico, grape, 2.20 
Revision 
     */
    static void Main()
    {
        SortedDictionary<string, Dictionary<string, double>> shopMap = new();
        string command;
        while ((command = Console.ReadLine()) != "Revision")
        {
            string[] tokens = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);

            string shop = tokens[0];
            string product = tokens[1];
            double price = double.Parse(tokens[2]);

            if (!shopMap.ContainsKey(shop))
            {
                shopMap[shop] = new();
            }
            shopMap[shop].Add(product, price);
        }
        foreach (var shop in shopMap)
        {
            Console.WriteLine($"{shop.Key}->");
            foreach (var product in shop.Value)
            {
                Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
            }
        }
    }
}
