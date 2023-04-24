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
                    switch (Direction)
                    {
                        case Direction.North:
                            Position = Position with { Latitude = Position.Latitude + 1 };
                            
                            if (Position.Latitude > 90)
                            {
                                var distanceAcrossNorthPole = Position.Latitude - 90;

                                Position = Position with { Latitude = 90 - distanceAcrossNorthPole };
                                Direction = Direction.South;
                            }
                            else if (Position.Latitude == 90)
                            {
                                Direction = Direction.South;
                            }
                            
                            break;
                        case Direction.East:
                            Position = Position with { Longitude = Position.Longitude + 1 };
                            break;
                        case Direction.South:
                            Position = Position with { Latitude = Position.Latitude - 1 };
                            
                            if (Position.Latitude < -90)
                            {
                                var distanceAcrossSouthPole = Position.Latitude + 90;

                                Position = Position with { Latitude = -90 - distanceAcrossSouthPole };
                                Direction = Direction.North;
                            }
                            else if (Position.Latitude == -90)
                            {
                                Direction = Direction.North;
                            }
                            
                            break;
                        case Direction.West:
                            Position = Position with { Longitude = Position.Longitude - 1 };
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    break;
                
                case 'b':
                    switch (Direction)
                    {
                        case Direction.North:
                            Position = Position with { Latitude = Position.Latitude - 1 };
                            
                            if (Position.Latitude < -90)
                            {
                                var distanceAcrossSouthPole = Position.Latitude + 90;

                                Position = Position with { Latitude = -90 - distanceAcrossSouthPole };
                                Direction = Direction.South;
                            }
                            else if (Position.Latitude == -90)
                            {
                                Direction = Direction.North;
                            }
                            
                            break;
                        case Direction.East:
                            Position = Position with { Longitude = Position.Longitude - 1 };
                            break;
                        case Direction.South:
                            Position = Position with { Latitude = Position.Latitude + 1 };
                            
                            if (Position.Latitude > 90)
                            {
                                var distanceAcrossNorthPole = Position.Latitude - 90;

                                Position = Position with { Latitude = 90 - distanceAcrossNorthPole };
                                Direction = Direction.North;
                            }
                            else if (Position.Latitude == 90)
                            {
                                Direction = Direction.South;
                            }
                            
                            break;
                        case Direction.West:
                            Position = Position with { Longitude = Position.Longitude + 1 };
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

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