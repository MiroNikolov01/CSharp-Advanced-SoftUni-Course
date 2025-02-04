namespace _05.GenericCountMethodStrings;

class Program
{
    static void Main()
    {
       int n = int.Parse(Console.ReadLine());
       List<Box<string>> compareCollection = new List<Box<string>>();
       for (int i = 0; i < n; i++)
       {
           string value = Console.ReadLine();
           compareCollection.Add(new Box<string>(value));
       }
       string comparisonValue = Console.ReadLine();
       
       Console.WriteLine(Box<string>.Compare(compareCollection, comparisonValue));
    }
}