using System.Collections;

namespace _09.CustomLinkedList;

public class CustomDoublyLinkedList<T> : IEnumerable<T>
{
    private int _count;
    private Node<T>? _head;
    private Node<T>? _tail;
    public int Count => _count;
    private bool CountIsEmpty => this._count == 0;
    private bool HasOneElement => this._count == 1;

    public T First => CountIsEmpty ? throw new InvalidOperationException("List is empty") : this._head.Value;
    public T Last => CountIsEmpty ? throw new InvalidOperationException("List is empty") : this._tail.Value;


    public void AddFirst(T element)
    {
        Node<T> newHead = new Node<T>(element);
        if (CountIsEmpty)
        {
            this._head = this._tail = newHead;
        }
        else
        {
            newHead.Next = this._head;
            this._head.Previous = newHead;
            this._head = newHead;
        }

        this._count++;
    }

    public void AddLast(T element)
    {
        Node<T> newTail = new Node<T>(element);
        if (CountIsEmpty)
        {
            this._head = this._tail = newTail;
        }
        else
        {
            newTail.Previous = this._tail!;
            this._tail.Next = newTail;
            this._tail = newTail;
        }

        this._count++;
    }

    public T RemoveFirst()
    {
        if (CountIsEmpty)
        {
            throw new InvalidOperationException("List is empty");
        }

        var firstElement = this._head!.Value;
        this._count--;
        if (HasOneElement)
        {
            this._head = this._tail = null;
        }
        else
        {
            this._head = this._head.Next;
            this._head.Previous = null;
        }


        return firstElement;
    }

    public T RemoveLast()
    {
        if (CountIsEmpty)
        {
            throw new InvalidOperationException("List is empty");
        }

        var lastElement = this._tail.Value;
        this._count--;
        if (HasOneElement)
        {
            this._head = this._tail = null;
        }
        else
        {
            this._tail = this._tail.Previous;
            this._tail.Next = null;
        }


        return lastElement;
    }

    public void ForEach(Action<T> action)
    {
        var currentNode = this._head;
        while (currentNode != null)
        {
            action(currentNode.Value);
            currentNode = currentNode.Next;
        }
    }

    public T[] ToArray()
    {
        T[] array = new T[this._count];
        int counter = 0;
        var currentNode = this._head;
        while (currentNode != null)
        {
            array[counter++] = currentNode.Value;
            currentNode = currentNode.Next;
        }

        return array;
    }

    public bool Contains(T element)
    {
        var currentNode = this._head;
        while (currentNode != null)
        {
            if (EqualityComparer<T>.Default.Equals(currentNode.Value, element))
            {
                return true;
            }

            currentNode = currentNode.Next;
        }

        return false;
    }


    private class Node<T>
    {
        public T Value { get; set; }
        public Node<T>? Next { get; set; }
        public Node<T>? Previous { get; set; }


        public Node(T value)
        {
            this.Value = value;
        }
    }

    private class CustomEnumarator : IEnumerator<T>
    {
        private Node<T>? _current;
        private Node<T> _head;

        public CustomEnumarator(Node<T> head)
        {
            _head = head;
            _current = null;
        }

        public T Current => _current.Value ?? throw new InvalidOperationException("list is empty!");

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (_current == null)
            {
                _current = _head;
            }
            else
            {
                _current = _current.Next;
            }

            return _current != null;
        }

        public void Reset()
        {
            _current = null;
        }

        public void Dispose()
        {
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new CustomEnumarator(_head);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}