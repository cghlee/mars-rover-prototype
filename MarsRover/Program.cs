namespace MarsRover;

internal class Program
{
    static void Main(string[] args)
    {
        string platString = "5 , 5";
        PlateauSize plateauSize = InputManager.ParsePlateauSize(platString);

        RoverPosition roverPosition = InputManager.ParseRoverPosition(" 1,  2, N");
        RoverPosition roverPosition2 = InputManager.ParseRoverPosition(" 3 , 3 , E");

        Rover rover = new Rover("Rich", roverPosition);
        Rover rover2 = new Rover("Neil", roverPosition2);

        List<Command> test = InputManager.ParseCommands("l f l f l f l f f");
        List<Command> test2 = InputManager.ParseCommands("F F R F F R F R R F");

        foreach (Command command in test)
        {
            if (command == Command.TurnLeft || command == Command.TurnRight)
                Console.WriteLine(rover.Rotate(command));
            else
                Console.WriteLine(rover.Move(command, plateauSize));
        }

        foreach (Command command in test2)
        {
            if (command == Command.TurnLeft || command == Command.TurnRight)
                Console.WriteLine(rover2.Rotate(command));
            else
                Console.WriteLine(rover2.Move(command, plateauSize));
        }

        Console.WriteLine(rover.RoverPosition.X);
        Console.WriteLine(rover.RoverPosition.Y);
        Console.WriteLine(rover.RoverPosition.Facing);

        Console.WriteLine(rover2.RoverPosition.X);
        Console.WriteLine(rover2.RoverPosition.Y);
        Console.WriteLine(rover2.RoverPosition.Facing);
    }
}
