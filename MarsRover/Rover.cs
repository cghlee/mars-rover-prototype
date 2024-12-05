namespace MarsRover;

internal class Rover
{
    internal string Name { get; set; }
    internal RoverPosition RoverPosition { get; set; }

    internal Rover(string name, RoverPosition roverPosition)
    {
        Name = name;
        RoverPosition = roverPosition;
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
                Compass.West => Compass.North
            };
        }
        else if (command == Command.TurnLeft)
        {
            newDirection = RoverPosition.Facing switch
            {
                Compass.North => Compass.West,
                Compass.West => Compass.South,
                Compass.South => Compass.East,
                Compass.East => Compass.North
            };
        }

        RoverPosition.Facing = newDirection;

        return newDirection;
    }
}
