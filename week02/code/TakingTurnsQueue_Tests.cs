using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class TakingTurnsQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with the following people and turns: Bob (2), Tim (5), Sue (3)
    // Expected Result: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
    // Defect(s) Found:
    // Players with remaining turns were not re-enqueued correctly.
    public void TestTakingTurnsQueue_FiniteRepetition()
    {
        var bob = new Person("Bob", 2);
        var tim = new Person("Tim", 5);
        var sue = new Person("Sue", 3);

        Person[] expectedResult = new Person[]
        {
            bob, tim, sue, bob, tim, sue, tim, sue, tim, tim
        };

        var players = new TakingTurnsQueue();
        players.AddPerson(bob.Name, bob.Turns);
        players.AddPerson(tim.Name, tim.Turns);
        players.AddPerson(sue.Name, sue.Turns);

        int i = 0;
        while (players.Length > 0)
        {
            var person = players.GetNextPerson();
            Assert.AreEqual(expectedResult[i].Name, person.Name);
            i++;
        }
    }

    [TestMethod]
    // Scenario: Add player midway
    // Expected Result: Order preserved correctly
    // Defect(s) Found:
    // Queue order broke when adding mid-execution.
    public void TestTakingTurnsQueue_AddPlayerMidway()
    {
        var bob = new Person("Bob", 2);
        var tim = new Person("Tim", 5);
        var sue = new Person("Sue", 3);
        var george = new Person("George", 3);

        Person[] expectedResult = new Person[]
        {
            bob, tim, sue, bob, tim, sue, tim,
            george, sue, tim, george, tim, george
        };

        var players = new TakingTurnsQueue();
        players.AddPerson(bob.Name, bob.Turns);
        players.AddPerson(tim.Name, tim.Turns);
        players.AddPerson(sue.Name, sue.Turns);

        int i = 0;
        for (; i < 5; i++)
        {
            Assert.AreEqual(expectedResult[i].Name, players.GetNextPerson().Name);
        }

        players.AddPerson("George", 3);

        while (players.Length > 0)
        {
            Assert.AreEqual(expectedResult[i].Name, players.GetNextPerson().Name);
            i++;
        }
    }

    [TestMethod]
    // Scenario: Infinite turns (0)
    // Expected Result: Infinite player never removed
    // Defect(s) Found:
    // Infinite turns were modified incorrectly.
    public void TestTakingTurnsQueue_ForeverZero()
    {
        var bob = new Person("Bob", 2);
        var tim = new Person("Tim", 0);
        var sue = new Person("Sue", 3);

        Person[] expectedResult = new Person[]
        {
            bob, tim, sue, bob, tim, sue, tim, sue, tim, tim
        };

        var players = new TakingTurnsQueue();
        players.AddPerson(bob.Name, bob.Turns);
        players.AddPerson(tim.Name, tim.Turns);
        players.AddPerson(sue.Name, sue.Turns);

        for (int i = 0; i < 10; i++)
        {
            Assert.AreEqual(expectedResult[i].Name, players.GetNextPerson().Name);
        }
    }

    [TestMethod]
    // Scenario: Infinite turns (negative)
    // Expected Result: Treated same as zero
    // Defect(s) Found:
    // Negative turns not treated as infinite.
    public void TestTakingTurnsQueue_ForeverNegative()
    {
        var tim = new Person("Tim", -3);
        var sue = new Person("Sue", 3);

        Person[] expectedResult = new Person[]
        {
            tim, sue, tim, sue, tim, sue, tim, tim, tim, tim
        };

        var players = new TakingTurnsQueue();
        players.AddPerson(tim.Name, tim.Turns);
        players.AddPerson(sue.Name, sue.Turns);

        for (int i = 0; i < 10; i++)
        {
            Assert.AreEqual(expectedResult[i].Name, players.GetNextPerson().Name);
        }
    }

    [TestMethod]
    // Scenario: Empty queue
    // Expected Result: Exception thrown
    // Defect(s) Found:
    // Exception was missing or message incorrect.
    public void TestTakingTurnsQueue_Empty()
    {
        var players = new TakingTurnsQueue();

        Assert.ThrowsException<InvalidOperationException>(
            () => players.GetNextPerson()
        );
    }
}
