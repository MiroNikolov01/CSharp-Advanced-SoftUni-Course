namespace IteratorsAndComparators;

public class Book : IComparable<Book>
{
    public string Title { get; set; }
    public int Year { get; set; }
    public IEnumerable<string> Authors { get; set; }

    public Book(string title, int year, params string[] authors)
    {
        this.Title = title;
        this.Year = year;
        this.Authors = new List<string>(authors);
    }

    public int CompareTo(Book? other)
    {
        if (other is null) return -1;
        
        int yearComparison = this.Year.CompareTo(other?.Year);
        if (yearComparison != 0)
        {
            return yearComparison;
        }
        int titleComparison = this.Title.CompareTo(other?.Title);

        return titleComparison;
    }

    public override string ToString()
    {
        return $"{this.Title} - {this.Year}";
    }
}