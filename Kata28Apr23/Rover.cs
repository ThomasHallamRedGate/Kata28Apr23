namespace Kata28Apr23;

public class Rover
{
    public Direction Direction { get; private set; }

    public Rover(Position position, Direction direction)
    {
        Direction = direction;
        Position = position;
    }

    public Position Position { get; private set; }

    public void ProcessCommands(char[] commands)
    {
        foreach (var command in commands)
        {
            switch (command)
            {
                case 'f':
                    Position = Direction switch
                    {
                        Direction.North => Position with { Latitude = Position.Latitude + 1 },
                        Direction.East => Position with { Longitude = Position.Longitude + 1 },
                        Direction.South => Position with { Latitude = Position.Latitude - 1 },
                        Direction.West => Position with { Longitude = Position.Longitude - 1 },
                        _ => throw new ArgumentOutOfRangeException()
                    };
                    break;
                
                case 'b':
                    Position = Direction switch
                    {
                        Direction.North => Position with { Latitude = Position.Latitude - 1 },
                        Direction.East => Position with { Longitude = Position.Longitude - 1 },
                        Direction.South => Position with { Latitude = Position.Latitude + 1 },
                        Direction.West => Position with { Longitude = Position.Longitude + 1 },
                        _ => throw new ArgumentOutOfRangeException()
                    };
                    break;
                
                case 'l':
                    Direction = Direction switch
                    {
                        Direction.North => Direction.West,
                        Direction.East => Direction.North,
                        Direction.South => Direction.East,
                        Direction.West => Direction.South,
                        _ => throw new ArgumentOutOfRangeException()
                    };
                    break;
                
                case 'r':
                    Direction = Direction switch
                    {
                        Direction.North => Direction.East,
                        Direction.East => Direction.South,
                        Direction.South => Direction.West,
                        Direction.West => Direction.North,
                        _ => throw new ArgumentOutOfRangeException()
                    };
                    break;
                
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}