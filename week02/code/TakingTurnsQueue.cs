using System;
using System.Collections.Generic;

public class PriorityQueue
{
    private class QueueItem
    {
        public string Value { get; }
        public int Priority { get; }

        public QueueItem(string value, int priority)
        {
            Value = value;
            Priority = priority;
        }
    }

    private List<QueueItem> _items = new List<QueueItem>();

    public void Enqueue(string value, int priority)
    {
        _items.Add(new QueueItem(value, priority));
    }

    public string Dequeue()
    {
        if (_items.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        int highestPriorityIndex = 0;

        for (int i = 1; i < _items.Count; i++)
        {
            if (_items[i].Priority > _items[highestPriorityIndex].Priority)
            {
                highestPriorityIndex = i;
            }
        }

        string value = _items[highestPriorityIndex].Value;
        _items.RemoveAt(highestPriorityIndex);
        return value;
    }
}

}
