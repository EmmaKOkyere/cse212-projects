using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write test cases and record any defects found.
// Fix the code being tested to match requirements and make all tests pass.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three items with different priorities: A (1), B (5), C (3).
    // Dequeue all three items.
    // Expected Result: B, C, A
    // Defect(s) Found:
    public void TestPriorityQueue_1()
    {
        var queue = new PriorityQueue();

        queue.Enqueue("A", 1);
        queue.Enqueue("B", 5);
        queue.Enqueue("C", 3);

        Assert.AreEqual("B", queue.Dequeue());
        Assert.AreEqual("C", queue.Dequeue());
        Assert.AreEqual("A", queue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add items with equal highest priorities and verify FIFO order.
    // Add First (5), Second (5), and Third (3).
    // Expected Result: First, Second, Third
    // Defect(s) Found:
    public void TestPriorityQueue_2()
    {
        var queue = new PriorityQueue();

        queue.Enqueue("First", 5);
        queue.Enqueue("Second", 5);
        queue.Enqueue("Third", 3);

        Assert.AreEqual("First", queue.Dequeue());
        Assert.AreEqual("Second", queue.Dequeue());
        Assert.AreEqual("Third", queue.Dequeue());

        try
        {
            queue.Dequeue();
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
    }
}