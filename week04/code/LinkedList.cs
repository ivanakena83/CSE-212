using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (head) of the list
    /// </summary>
    public void InsertHead(int value)
    {
        Node newNode = new Node(value);

        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }
    }

    /// <summary>
    /// PROBLEM 1: Insert Tail
    /// </summary>
    public void InsertTail(int value)
    {
        Node newNode = new Node(value);

        if (_tail is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Prev = _tail;
            _tail.Next = newNode;
            _tail = newNode;
        }
    }

    /// <summary>
    /// Remove the head node
    /// </summary>
    public void RemoveHead()
    {
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else if (_head is not null)
        {
            _head = _head.Next;
            _head!.Prev = null;
        }
    }

    /// <summary>
    /// PROBLEM 2: Remove Tail
    /// </summary>
    public void RemoveTail()
    {
        if (_tail is null)
            return;

        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            _tail = _tail.Prev;
            _tail!.Next = null;
        }
    }

    /// <summary>
    /// REQUIRED BY TESTS: Insert after first match
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        Node? current = _head;

        while (current is not null)
        {
            if (current.Data == value)
            {
                if (current == _tail)
                {
                    InsertTail(newValue);
                }
                else
                {
                    Node newNode = new Node(newValue);
                    newNode.Next = current.Next;
                    newNode.Prev = current;
                    current.Next!.Prev = newNode;
                    current.Next = newNode;
                }
                return;
            }
            current = current.Next;
        }
    }

    /// <summary>
    /// PROBLEM 3: Remove first occurrence
    /// </summary>
    public void Remove(int value)
    {
        Node? current = _head;

        while (current is not null)
        {
            if (current.Data == value)
            {
                if (current == _head)
                    RemoveHead();
                else if (current == _tail)
                    RemoveTail();
                else
                {
                    current.Prev!.Next = current.Next;
                    current.Next!.Prev = current.Prev;
                }
                return;
            }
            current = current.Next;
        }
    }

    /// <summary>
    /// PROBLEM 4: Replace all occurrences
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        Node? current = _head;

        while (current is not null)
        {
            if (current.Data == oldValue)
                current.Data = newValue;

            current = current.Next;
        }
    }

    /// <summary>
    /// Forward iterator
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<int> GetEnumerator()
    {
        Node? current = _head;

        while (current is not null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    /// <summary>
    /// PROBLEM 5: Reverse iterator
    /// </summary>
    public IEnumerable<int> Reverse()
    {
        Node? current = _tail;

        while (current is not null)
        {
            yield return current.Data;
            current = current.Prev;
        }
    }

    public bool HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    public bool HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }
}
