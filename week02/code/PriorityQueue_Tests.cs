using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities
    // Expected Result: Item with highest priority is dequeued
    // Defect(s) Found:
    // Dequeue removed the first item instead of the highest priority item.
    public void TestPriorityQueue_HighestPriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 1);
        pq.Enqueue("High", 10);
        pq.Enqueue("Medium", 5);

        Assert.AreEqual("High", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same priority
    // Expected Result: Items are dequeued in FIFO order
    // Defect(s) Found:
    // FIFO order was not preserved for items with the same priority.
    public void TestPriorityQueue_FIFOWithSamePriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("First", 5);
        pq.Enqueue("Second", 5);
        pq.Enqueue("Third", 5);

        Assert.AreEqual("First", pq.Dequeue());
        Assert.AreEqual("Second", pq.Dequeue());
        Assert.AreEqual("Third", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Mix priorities and dequeue repeatedly
    // Expected Result: Highest priority dequeued first, FIFO for ties
    // Defect(s) Found:
    // Queue ordering was not correctly recalculated after each dequeue.
    public void TestPriorityQueue_MixedPriorities()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 2);
        pq.Enqueue("B", 10);
        pq.Enqueue("C", 10);
        pq.Enqueue("D", 1);

        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
        Assert.AreEqual("D", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue
    // Expected Result: InvalidOperationException with correct message
    // Defect(s) Found:
    // Incorrect exception type or message thrown.
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();

        try
        {
            pq.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}

}
