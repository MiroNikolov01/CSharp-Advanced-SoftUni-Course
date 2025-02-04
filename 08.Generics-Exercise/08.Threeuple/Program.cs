namespace _08.Threeuple;

class Program
{
    static void Main(string[] args)
    {
        var nameAndAdress = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        Threeuple<string, string, string> firstInput;
        if (nameAndAdress.Length == 5)
        {
            firstInput = new Threeuple<string, string, string>
            (nameAndAdress[0] + " " + nameAndAdress[1],
                nameAndAdress[2],
                nameAndAdress[3] + " " + nameAndAdress[4]);
            Console.WriteLine(firstInput.ToString());
        }
        else if (nameAndAdress.Length == 4)
        {
            firstInput = new Threeuple<string, string, string>
            (nameAndAdress[0] + " " + nameAndAdress[1],
                nameAndAdress[2],
                nameAndAdress[3]);
            Console.WriteLine(firstInput.ToString());
        }

        var nameAndBeer = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        Predicate<string> drunkChecker = isDrunk => nameAndBeer[2] == "drunk";

        Threeuple<string, int, bool> secondInput = new Threeuple<string, int, bool>
        (nameAndBeer[0],
            int.Parse(nameAndBeer[1]),
            drunkChecker(nameAndBeer[2]));
        Console.WriteLine(secondInput.ToString());

        var inputNums = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        Threeuple<string, double, string> thirdInput = new Threeuple<string, double, string>
        (inputNums[0],
            double.Parse(inputNums[1]),
            inputNums[2]);

        Console.WriteLine(thirdInput.ToString());
    }
}