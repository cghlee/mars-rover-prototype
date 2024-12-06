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
        string newRoverName = InputManager.GetInput("\nGive your new Rover a name:")!;

        RoverPosition? newRoverPosition;
        while (true)
        {
            string roverPositionInput = InputManager.GetInput("Input the Rover's landing position (for example: 1, 2, N)")!;
            newRoverPosition = InputManager.ParseRoverPosition(roverPositionInput);

            if (newRoverPosition != null)
                break;
            else
                Console.WriteLine("Invalid Rover position, please try again.\n");
        }

        Rover newRover = new Rover(newRoverName, newRoverPosition);
        AllRovers.Add(newRover);

        Console.WriteLine($"\n{newRoverName} has landed on {Name}!");
    }

    internal void DisplayRoverInfo()
    {
        for (int i = 0; i < AllRovers.Count; i++)
        {
            string roverPositionInfo = AllRovers[i].GetRoverInfo();

            Console.WriteLine($" ({i + 1}) - {AllRovers[i].Name}, at {roverPositionInfo}");
        }
    }

    internal Rover? GetSelectedRover()
    {
        if (AllRovers.Count == 0)
        {
            Console.WriteLine($"\nYou have not yet deployed a rover onto {Name}!");
            return null;
        }
            
        Console.WriteLine($"\nSelect a Rover on {Name} to command:");
        DisplayRoverInfo();

        int selectedRoverNumber = InputManager.GetInputFromOptions("", Enumerable.Range(1, AllRovers.Count).ToArray());
        return AllRovers[selectedRoverNumber - 1];
    }
}
