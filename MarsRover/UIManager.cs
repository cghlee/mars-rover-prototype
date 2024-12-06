using System.Xml.Linq;

namespace MarsRover;

internal class UIManager
{
    private MarsManager _marsManager { get; }

    internal UIManager(MarsManager marsManager)
    {
        _marsManager = marsManager;
    }

    internal void Run()
    {
        if (_marsManager.AllPlateaus.Count == 0)
        {
            Console.WriteLine("Welcome to Mars!\n");
            _marsManager.ScoutNewPlateau();
        }

        bool isToQuit = false;
        while (!isToQuit)
        {
            Plateau currentPlateau = _marsManager.GetCurrentPlateau();
            _marsManager.DisplayPlateauInfo();

            int selectedOption = GetEntrySelection();
            UIOption optionEnum = (UIOption)(selectedOption - 1);

            switch (optionEnum)
            {
                case UIOption.DisplayMap:
                    Console.WriteLine("\nMap Display not yet implemented!");
                    break;

                case UIOption.CommandRover:
                    Rover? selectedRover = currentPlateau.GetSelectedRover();
                    if (selectedRover == null)
                        break;

                    // TODO: Split off both parts of the logic here, above and/or below
                    string commandInput = InputManager.GetInput("\nInput space- or comma-delimited commands [F, B, L, R] (for example: f, b, l, r)");
                    List<Command>? commandList = InputManager.ParseCommands(commandInput);
                    if (commandList == null)
                        break;

                    selectedRover.ProcessCommands(commandList, currentPlateau.PlateauSize);
                    break;

                case UIOption.NewRover:
                    currentPlateau.DeployNewRover();
                    break;

                case UIOption.GetRoverInfo:
                    Console.WriteLine($"\nAll {currentPlateau.AllRovers.Count} Rovers currently on {currentPlateau.Name}:");
                    currentPlateau.DisplayRoverInfo();
                    break;

                case UIOption.SwitchPlateau:
                    Console.WriteLine("\nPlateau Switching not yet implemented!");
                    break;

                case UIOption.NewPlateau:
                    Console.WriteLine("\nCreating New Plateaus not yet implemented!");
                    break;

                case UIOption.Quit:
                    // Eventually add saving of data prior to quitting...?
                    isToQuit = true;
                    Console.WriteLine("\nShutting down...");
                    break;

                default:
                    goto case UIOption.Quit;
            }
        }
    }

    private int GetEntrySelection()
    {
        string[] options = [
            "Display Map",
            "Command a Rover",
            "Deploy New Rover",
            "Get Rover Information",
            "Switch Plateau",
            "Scout New Plateau",
            "Quit" ];

        DisplayEntryOptions(options);

        int selectedOption = InputManager.GetInputFromOptions("Select an option from the above:",
                                                              Enumerable.Range(1, options.Length).ToArray());

        return selectedOption;
    }

    private void DisplayEntryOptions(string[] options)
    {
        Console.WriteLine("Please select an option:");

        for (int i = 0; i < options.Length; i++)
            Console.WriteLine($" {i + 1} - {options[i]}");
    }
}
