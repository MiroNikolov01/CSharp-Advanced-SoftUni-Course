using System.Collections;

namespace IteratorsAndComparators;

public class Library : IEnumerable<Book>
{
    private readonly List<Book> _books;

    public Library(params Book[] books)
    {
        this._books = new List<Book>(books);
        this._books.Sort(new BookComparator());
    }
    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(this._books);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    private class LibraryIterator : IEnumerator<Book>
    {
        private readonly List<Book> _books;
        private int _position = -1;

        public LibraryIterator(IEnumerable<Book> books)
        {
            Reset();
            _books = new List<Book>(books);
        }

        public bool MoveNext() => ++_position < _books.Count;
        public void Reset() => _position = -1;
   
        public Book Current => _books[_position];

        object? IEnumerator.Current => this.Current;

        public void Dispose()
        {
        }
    }
}