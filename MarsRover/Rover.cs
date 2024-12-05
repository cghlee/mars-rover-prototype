namespace MarsRover;

internal class Rover
{
    string Name { get; set; }
    RoverPosition RoverPosition { get; set; }

    internal Rover(string name, RoverPosition roverPosition)
    {
        Name = name;
        RoverPosition = roverPosition;
    }

    //internal Compass Rotate(Command command)
    //{
    //    if (command == Command.TurnRight)
    //    {
    //        Compass newDirection = RoverPosition.Facing switch
    //        {
    //            Compass.N => 
    //        };
    //    }
    //}
}
