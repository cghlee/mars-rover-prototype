namespace MarsRover;

internal class Plateau
{
    internal string Name { get; }
    internal PlateauSize PlateauSize { get; }
    internal List<Rover> AllRovers { get; } = new List<Rover>();

    internal Plateau(string name, PlateauSize plateauSize)
    {
        Name = name;
        PlateauSize = plateauSize;
    }

    internal void DeployNewRover()
    {
        string newRoverName = InputManager.GetInput("Give your rover a name:")!;

        RoverPosition? newRoverPosition;
        while (true)
        {
            string roverPositionInput = InputManager.GetInput("Input a rover position (for example: 1, 2, N)")!;
            newRoverPosition = InputManager.ParseRoverPosition(roverPositionInput);

            if (newRoverPosition != null)
                break;
            else
                Console.WriteLine("Invalid rover position, please try again.\n");
        }

        Rover newRover = new Rover(newRoverName, newRoverPosition);
        AllRovers.Add(newRover);

        Console.WriteLine($"{newRoverName} has landed on {Name}!");
    }
}
