namespace _07.Tuple;

class Program
{
    static void Main(string[] args)
    {
        var nameAndAdress = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
        Tuple<string, string> firstInput = new Tuple<string, string>
        (nameAndAdress[0] + " " + nameAndAdress[1], nameAndAdress[2]);
        
        Console.WriteLine(firstInput.ToString());
    
        var nameAndBeer = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        Tuple<string, int> secondInput = new Tuple<string, int>
            (nameAndBeer[0], int.Parse(nameAndBeer[1]));
        
        Console.WriteLine(secondInput.ToString());

        var inputNums = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        Tuple<int, double> thirdInput = new Tuple<int, double>
            (int.Parse(inputNums[0]), double.Parse(inputNums[1]));

        Console.WriteLine(thirdInput.ToString());
    }
}