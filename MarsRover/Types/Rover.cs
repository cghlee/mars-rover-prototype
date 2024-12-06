namespace MarsRover;

internal class Rover
{
    internal string Name { get; }
    internal RoverPosition RoverPosition { get; set; }

    internal Rover(string name, RoverPosition roverPosition)
    {
        Name = name;
        RoverPosition = roverPosition;
    }

    internal void ProcessCommands(List<Command> commands, PlateauSize plateauSize)
    {
        foreach (Command command in commands)
        {
            if (command is Command.MoveForward or Command.MoveBack)
                Move(command, plateauSize);
            else
                Rotate(command);
        }

        string roverPositionInfo = GetRoverInfo();
        Console.WriteLine($"\n{Name} is now at {roverPositionInfo}");
    }

    internal string GetRoverInfo()
    {
        string enumName = Enum.GetName(typeof(Compass), RoverPosition.Facing)!;
        string roverPositionInfo = $"(X = {RoverPosition.X}, Y = {RoverPosition.Y}, facing {enumName})";

        return roverPositionInfo;
    }

    internal Compass Rotate(Command command)
    {
        Compass newDirection = Compass.North;

        if (command == Command.TurnRight)
        {
            newDirection = RoverPosition.Facing switch
            {
                Compass.North => Compass.East,
                Compass.East => Compass.South,
                Compass.South => Compass.West,
                Compass.West => Compass.North,
                _ => Compass.North
            };
        }
        else if (command == Command.TurnLeft)
        {
            newDirection = RoverPosition.Facing switch
            {
                Compass.North => Compass.West,
                Compass.West => Compass.South,
                Compass.South => Compass.East,
                Compass.East => Compass.North,
                _ => Compass.North
            };
        }

        RoverPosition.Facing = newDirection;

        return newDirection;
    }

    internal bool Move(Command command, PlateauSize plateauSize)
    {
        int xMax = plateauSize.Width - 1;
        int xMin = 0;

        int yMax = plateauSize.Height - 1;
        int yMin = 0;

        if (command == Command.MoveForward)
        {
            switch (RoverPosition.Facing)
            {
                case Compass.North:
                    if ((RoverPosition.Y + 1) > yMax)
                        return false;
                    else
                        RoverPosition.Y++; return true;
                case Compass.South:
                    if ((RoverPosition.Y - 1) < yMin)
                        return false;
                    else
                        RoverPosition.Y--; return true;
                case Compass.East:
                    if ((RoverPosition.X + 1) > xMax)
                        return false;
                    else
                        RoverPosition.X++; return true;
                case Compass.West:
                    if ((RoverPosition.X - 1) < xMin)
                        return false;
                    else
                        RoverPosition.X--; return true;
                default:
                    return false;
            }
        }
        else
        {
            switch (RoverPosition.Facing)
            {
                case Compass.North:
                    if ((RoverPosition.Y - 1) < yMin)
                        return false;
                    else
                        RoverPosition.Y--; return true;
                case Compass.South:
                    if ((RoverPosition.Y + 1) > yMax)
                        return false;
                    else
                        RoverPosition.Y++; return true;
                case Compass.East:
                    if ((RoverPosition.X - 1) < xMin)
                        return false;
                    else
                        RoverPosition.X--; return true;
                case Compass.West:
                    if ((RoverPosition.X + 1) > xMax)
                        return false;
                    else
                        RoverPosition.X++; return true;
                default:
                    return false;
            }
        }
    }
}
