namespace IteratorsAndComparators;

public class BookComparator : IComparer<Book>
{
    public int Compare(Book x, Book y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if(x is null) return 1;
        if(y is null) return -1;
        
        int titleCompareValue = string.Compare(x.Title, y.Title);
        if (titleCompareValue != 0)
        {
            return titleCompareValue;
        }
        
        int yearCompareValue = -1 * Comparer<int>.Default.Compare(x.Year, y.Year);

        return yearCompareValue;
    }
}