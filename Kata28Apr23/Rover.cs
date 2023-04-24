using System.Diagnostics;

namespace Kata28Apr23;

public class Rover
{
    private readonly Direction _direction;

    public Rover(Position position, Direction direction)
    {
        _direction = direction;
        Position = position;
    }

    public Position Position { get; private set; }

    public void ProcessCommands(char[] commands)
    {
        
        Position = _direction switch
        {
            Direction.North => Position with { Y = Position.Y + 1 },
            Direction.East => Position with { X = Position.X + 1 },
            Direction.South => Position with { Y = Position.Y - 1 },
            Direction.West => Position with { X = Position.X - 1 },
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}