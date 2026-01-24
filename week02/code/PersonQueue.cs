using System.Collections.Generic;

public class PersonQueue
{
    private Queue<Person> _queue = new Queue<Person>();

    public int Length => _queue.Count;

    public void Enqueue(Person person)
    {
        _queue.Enqueue(person);
    }

    public Person Dequeue()
    {
        return _queue.Dequeue();
    }
}
