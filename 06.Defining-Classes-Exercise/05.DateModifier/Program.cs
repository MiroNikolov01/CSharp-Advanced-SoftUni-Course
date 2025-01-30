namespace _05.DateModifier;

class Program
{
    static void Main(string[] args)
    {
        string[] firstDate = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string[] secondDate = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        (int year1, int month1, int day1) = (int.Parse(firstDate[0]),
        int.Parse(firstDate[1]),
        int.Parse(firstDate[2]));
        DateTime date1 = new DateTime(year1, month1, day1);
        
        (int year2, int month2, int day2) = (int.Parse(secondDate[0]),
            int.Parse(secondDate[1]),
            int.Parse(secondDate[2]));
        DateTime date2 = new DateTime(year2, month2, day2);

        DateModifier dateModifier = new DateModifier(date1, date2);

        TimeSpan diff = dateModifier.CalculateDateDifference();
        Console.WriteLine(Math.Abs(diff.Days));
    }
}