namespace MarsRover;

internal class MarsManager
{
    private int _currentPlateauIndex = 0;
    internal List<Plateau> AllPlateaus { get; } = new List<Plateau>();

    internal void ScoutNewPlateau()
    {
        string newPlateauName = InputManager.GetInput("What is the name of the plateau you are landing at?")!;

        PlateauSize? newPlateauSize;
        while (true)
        {
            string plateauSizeInput = InputManager.GetInput("Input the size of your plateau (for example: 4, 5)")!;
            newPlateauSize = InputManager.ParsePlateauSize(plateauSizeInput);

            if (newPlateauSize != null)
                break;
            else
                Console.WriteLine("\nInvalid plateau size, please try again.\n");
        }

        Plateau newPlateau = new Plateau(newPlateauName, newPlateauSize);
        AllPlateaus.Add(newPlateau);

        Console.WriteLine($"\n{newPlateauName} is now yours; new discoveries await!");
    }

    internal void DisplayPlateauInfo()
    {
        Console.WriteLine($"\n==================================================\n");

        Plateau currentPlateau = GetCurrentPlateau();
        Console.WriteLine($"You are currently on {currentPlateau.Name}.");
        Console.WriteLine($"There are {currentPlateau.AllRovers.Count} rovers on {currentPlateau.Name}.\n");
    }

    internal Plateau GetCurrentPlateau()
    {
        return AllPlateaus[_currentPlateauIndex];
    }
}
