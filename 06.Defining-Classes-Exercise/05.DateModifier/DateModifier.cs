namespace _05.DateModifier;

public class DateModifier
{
    public DateTime StartDate { get; }
    public DateTime EndDate { get; }

    public DateModifier(DateTime startDate, DateTime endDate)
    {
        StartDate = startDate;
        EndDate = endDate;
    }

    public TimeSpan CalculateDateDifference()
    {
        return EndDate - StartDate;
    }
}