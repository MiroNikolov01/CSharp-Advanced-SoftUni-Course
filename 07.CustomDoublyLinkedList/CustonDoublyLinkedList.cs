using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace UpgradedCustomDoublyLinkedList.NET9;

public class CustomDoublyLinkedList<T> : IEnumerable<T>
{
    private int _count;
    private Node? _head;
    private Node? _tail;
    public int Count => _count;
    private bool CountIsEmpty => this._count == 0;
    private bool HasOneElement => this._count == 1;

    public T First => CountIsEmpty ? throw new InvalidOperationException("List is empty") : this._head!.Value;
    public T Last => CountIsEmpty ? throw new InvalidOperationException("List is empty") : this._tail!.Value;

    public void AddFirst(T element)
    {
        Node newHead = new Node(element);
        if (CountIsEmpty)
        {
            this._head = this._tail = newHead;
        }
        else
        {
            newHead.Next = this._head;
            this._head!.Previous = newHead;
            this._head = newHead;
        }

        this._count++;
    }

    public void AddLast(T element)
    {
        Node newTail = new Node(element);
        if (CountIsEmpty)
        {
            this._head = this._tail = newTail;
        }
        else
        {
            newTail.Previous = this._tail;
            this._tail!.Next = newTail;
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
        if (HasOneElement)
        {
            this._head = this._tail = null;
        }
        else
        {
            this._head = this._head.Next;
            this._head!.Previous = null;
        }


        this._count--;
        return firstElement;
    }

    public T RemoveLast()
    {
        if (CountIsEmpty)
        {
            throw new InvalidOperationException("List is empty");
        }

        var lastElement = this._tail!.Value;
        if (HasOneElement)
        {
            this._tail = this._head = null;
        }
        else
        {
            this._tail = this._tail.Previous;
            this._tail = null;
        }

        this._count--;

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

    public class Node
    {
        public T Value { get; set; }
        public Node? Next { get; set; }
        public Node? Previous { get; set; }


        public Node(T value)
        {
            this.Value = value;
        }
    }

    private class CustomEnumarator : IEnumerator<T>
    {
        private Node? _current;
        private Node? _head;

        public CustomEnumarator(Node head)
        {
            _head = head;
            _current = null;
        }

        public T Current
        {
            get
            {
                if (_current == null)
                {
                    throw new InvalidOperationException("Enumeration has not started");
                }

                return _current.Value;
            }
        }

        object IEnumerator.Current => Current!;

        public bool MoveNext()
        {
            if (_head == null) return false;
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

    public T2 Max<T2>(Func<T, T2> func) where T2 : INumber<T2>, IMinMaxValue<T2>
    {
        T2 max = T2.MinValue;
        Node currentNode = this._head!;

        while (currentNode != null!)
        {
            if (max < func(currentNode.Value))
            {
                max = func(currentNode.Value);
            }

            currentNode = currentNode.Next!;
        }

        return max;
    }
    public T2 Min<T2>(Func<T, T2> func) where T2 : INumber<T2>, IMinMaxValue<T2>
    {
        T2 max = T2.MaxValue;
        Node currentNode = this._head!;

        while (currentNode != null!)
        {
            if (max > func(currentNode.Value))
            {
                max = func(currentNode.Value);
            }

            currentNode = currentNode.Next!;
        }

        return max;
    }

    public T2 Sum<T2>(Func<T, T2> func) where T2 :  INumber<T2>
    {
        T2 sum = T2.Zero;
        Node currentNode = this._head!;
        while (currentNode != null!)
        {
            sum += func(currentNode.Value);
            currentNode = currentNode.Next!;
        }
        return sum;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new CustomEnumarator(_head!);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}