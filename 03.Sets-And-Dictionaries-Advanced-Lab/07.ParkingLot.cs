namespace _07.ParkingLot;

internal class Program
{
    static void Main()
    {
        HashSet<string> carNumbers = new();

        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            string[] arguemnts = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);
            switch (arguemnts[0])
            {
                case "IN":
                    carNumbers.Add(arguemnts[1]);
                    break;
                case "OUT":
                    carNumbers.Remove(arguemnts[1]);
                    break;
            }
        }
        Console.WriteLine(carNumbers.Count > 0 ? string.Join('\n', carNumbers) : "Parking Lot is Empty");
    }
}
