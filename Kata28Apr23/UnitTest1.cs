namespace Kata28Apr23;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase(0, 0, Direction.North, new [] {'f'}, 0, 1)]
    [TestCase(0, 0, Direction.East, new [] {'f'}, 1, 0)]
    [TestCase(0, 0, Direction.South, new [] {'f'}, 0, -1)]
    [TestCase(0, 0, Direction.West, new [] {'f'}, -1, 0)]
    public void ProcessCommands_UpdatesPositionCorrectly(
        double initialX, 
        double initialY,
        Direction direction,
        char[] commands,
        double expectedX,
        double expectedY)
    {
        var rover = new Rover(new Position(initialX, initialY), direction);
        
        rover.ProcessCommands(commands);
        
        Assert.That(rover.Position, Is.EqualTo(new Position(expectedX, expectedY)));
    }
}