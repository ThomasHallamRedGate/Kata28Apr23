namespace Kata28Apr23;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    //[TestCase(0, 0, Direction.North, new [] {'f'}, 0, 1)]
    //[TestCase(0, 0, Direction.East, new [] {'f'}, 1, 0)]
    //[TestCase(0, 0, Direction.South, new [] {'f'}, 0, -1)]
    //[TestCase(0, 0, Direction.West, new [] {'f'}, -1, 0)]
    //[TestCase(0, 0, Direction.North, new [] {'f','f','f'}, 0, 3)]
    //[TestCase(0, 0, Direction.North, new [] {'b'}, 0, -1)]
    //[TestCase(0, 0, Direction.East, new [] {'b'}, -1, 0)]
    //[TestCase(0, 0, Direction.South, new [] {'b'}, 0, 1)]
    //[TestCase(0, 0, Direction.West, new [] {'b'}, 1, 0)]
    //[TestCase(0, 0, Direction.North, new [] {'b','f','b','b'}, 0, -2)]
    //public void ProcessCommands_UpdatesPositionCorrectly(
    //    double initialLongitude, 
    //    double initialLatitude,
    //    Direction direction,
    //    char[] commands,
    //    double expectedLongitude,
    //    double expectedLatitude)
    //{
    //    var rover = new Rover(new Position(initialLongitude, initialLatitude), direction);
    //    
    //    rover.ProcessCommands(commands);
    //    
    //    Assert.That(rover.Position, Is.EqualTo(new Position(expectedLongitude, expectedLatitude)));
    //}
//
    //[TestCase(Direction.North, new [] {'l'}, Direction.West)]
    //[TestCase(Direction.North, new [] {'r'}, Direction.East)]
    //[TestCase(Direction.East, new [] {'l'}, Direction.North)]
    //[TestCase(Direction.East, new [] {'r'}, Direction.South)]
    //[TestCase(Direction.South, new [] {'l'}, Direction.East)]
    //[TestCase(Direction.South, new [] {'r'}, Direction.West)]
    //[TestCase(Direction.West, new [] {'l'}, Direction.South)]
    //[TestCase(Direction.West, new [] {'r'}, Direction.North)]
    //[TestCase(Direction.North, new [] {'r', 'r'}, Direction.South)]
    //[TestCase(Direction.North, new [] {'l', 'r', 'l'}, Direction.West)]
    //public void ProcessCommands_UpdatesDirectionCorrectly(Direction initialDirection, char[] commands, Direction expectedDirection)
    //{
    //    var rover = new Rover(new Position(0, 0), initialDirection);
    //    rover.ProcessCommands(commands);
    //    
    //    Assert.That(rover.Direction, Is.EqualTo(expectedDirection));
    //}

    //[TestCase(0, 0, Direction.North, new [] {'f', 'r', 'f', 'f', 'l', 'b'}, 2, 0, Direction.North)]
    //[TestCase(2, 3, Direction.East, new [] {'r', 'r', 'b', 'b', 'l', 'f', 'f', 'r'}, 4, 1, Direction.West)]
    [TestCase(0, 0, Direction.North, new [] {'f'}, 0, 1, Direction.North)]
    [TestCase(0, 0, Direction.North, new [] {'b'}, 0, -1, Direction.North)]
    [TestCase(0, 0, Direction.South, new [] {'f'}, 0, -1, Direction.South)]
    [TestCase(0, 0, Direction.South, new [] {'b'}, 0, 1, Direction.South)]
    
    // North Pole
    [TestCase(0, 88, Direction.North, new [] {'f'}, 0, 89, Direction.North)]
    [TestCase(0, 89, Direction.North, new [] {'f'}, 0, 90, Direction.South)]
    [TestCase(0, 90, Direction.North, new [] {'f'}, 0, 89, Direction.South)]
    [TestCase(0, 89.75, Direction.North, new [] {'f'}, 0, 89.25, Direction.South)]
    [TestCase(0, 89, Direction.North, new [] {'f', 'f'}, 0, 89, Direction.South)]
    [TestCase(0, 89, Direction.North, new [] {'f', 'b'}, 0, 89, Direction.North)]
    
    [TestCase(0, 88, Direction.South, new [] {'b'}, 0, 89, Direction.South)]
    [TestCase(0, 89, Direction.South, new [] {'b'}, 0, 90, Direction.South)]
    [TestCase(0, 90, Direction.South, new [] {'b'}, 0, 89, Direction.North)]
    [TestCase(0, 89.75, Direction.South, new [] {'b'}, 0, 89.25, Direction.North)]
    [TestCase(0, 89, Direction.South, new [] {'b', 'b'}, 0, 89, Direction.North)]
    [TestCase(0, 89, Direction.South, new [] {'b', 'f'}, 0, 89, Direction.South)]
    
    // South Pole
    [TestCase(0, -88, Direction.South, new [] {'f'}, 0, -89, Direction.South)]
    [TestCase(0, -89, Direction.South, new [] {'f'}, 0, -90, Direction.North)]
    [TestCase(0, -90, Direction.South, new [] {'f'}, 0, -89, Direction.North)]
    [TestCase(0, -89.75, Direction.South, new [] {'f'}, 0, -89.25, Direction.North)]
    [TestCase(0, -89, Direction.South, new [] {'f', 'f'}, 0, -89, Direction.North)]
    [TestCase(0, -89, Direction.South, new [] {'f', 'b'}, 0, -89, Direction.South)]
    
    [TestCase(0, -88, Direction.North, new [] {'b'}, 0, -89, Direction.North)]
    [TestCase(0, -89, Direction.North, new [] {'b'}, 0, -90, Direction.North)]
    [TestCase(0, -90, Direction.North, new [] {'b'}, 0, -89, Direction.South)]
    [TestCase(0, -89.75, Direction.North, new [] {'b'}, 0, -89.25, Direction.South)]
    [TestCase(0, -89, Direction.North, new [] {'b', 'b'}, 0, -89, Direction.South)]
    [TestCase(0, -89, Direction.North, new [] {'b', 'f'}, 0, -89, Direction.North)]
    public void ProcessCommands_UpdatesPositionAndDirectionCorrectly(
        double initialLongitude, 
        double initialLatitude,
        Direction initialDirection,
        char[] commands,
        double expectedLongitude,
        double expectedLatitude,
        Direction expectedDirection)
    {
        var rover = new Rover(new Position(initialLongitude, initialLatitude), initialDirection);
        
        rover.ProcessCommands(commands);
        
        Assert.That(rover.Position, Is.EqualTo(new Position(expectedLongitude, expectedLatitude)));
        Assert.That(rover.Direction, Is.EqualTo(expectedDirection));
    }
    
    [Test]
    public void ProcessCommands_ThrowsException_WhenCommandIsInvalid()
    {
        var rover = new Rover(new Position(0, 0), Direction.North);
        
        Assert.Throws<ArgumentOutOfRangeException>(() => rover.ProcessCommands(new [] {'x'}));
    }
}