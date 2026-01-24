using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities and dequeue them
    // Expected Result: Items should be dequeued in order of highest priority (5, then 3, then 1)
    // Defect(s) Found: None - code works correctly for basic priority ordering.
    public void TestPriorityQueue_BasicPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Medium", 3);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same priority and verify FIFO order
    // Expected Result: When priorities are equal, items should be dequeued in FIFO order (First, Second, Third)
    // Defect(s) Found: None - code correctly uses '>' (not '>=') to maintain FIFO order for equal priorities.
    public void TestPriorityQueue_SamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 3);
        priorityQueue.Enqueue("Second", 3);
        priorityQueue.Enqueue("Third", 3);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Mix of items with same and different priorities
    // Expected Result: Highest priority first, then FIFO for equal priorities
    // Defect(s) Found: None - code correctly maintains FIFO order for items with equal priorities.
    public void TestPriorityQueue_MixedPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low1", 1);
        priorityQueue.Enqueue("High1", 5);
        priorityQueue.Enqueue("Medium1", 3);
        priorityQueue.Enqueue("High2", 5);
        priorityQueue.Enqueue("Medium2", 3);

        Assert.AreEqual("High1", priorityQueue.Dequeue());
        Assert.AreEqual("High2", priorityQueue.Dequeue());
        Assert.AreEqual("Medium1", priorityQueue.Dequeue());
        Assert.AreEqual("Medium2", priorityQueue.Dequeue());
        Assert.AreEqual("Low1", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None - exception handling works correctly.
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }

    [TestMethod]
    // Scenario: Enqueue items to back regardless of priority, then dequeue by priority
    // Expected Result: All items added to back, but removed by highest priority
    // Defect(s) Found: None - code correctly implements priority queue with FIFO for equal priorities.
    public void TestPriorityQueue_EnqueueToBack()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 5);
        priorityQueue.Enqueue("C", 1);
        priorityQueue.Enqueue("D", 5);

        // B and D both have priority 5, but B was added first (FIFO)
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }
}