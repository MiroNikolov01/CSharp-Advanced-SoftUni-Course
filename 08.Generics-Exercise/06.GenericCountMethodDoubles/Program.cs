namespace _06.GenericCountMethodDoubles;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        List<Box<double>> compareCollection = new List<Box<double>>();
        for (int i = 0; i < n; i++)
        {
            string value = Console.ReadLine();
            compareCollection.Add(new Box<double>(double.Parse(value)));
        }
        double comparisonValue = double.Parse(Console.ReadLine());
       
        Console.WriteLine(Box<double>.Compare(compareCollection, comparisonValue));
    }
}