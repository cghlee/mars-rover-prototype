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
            _marsManager.DisplayStatus();

            int selectedOption = GetEntrySelection();
            UIOption optionEnum = (UIOption)(selectedOption - 1);

            switch (optionEnum)
            {
                case UIOption.DisplayMap:
                    Console.WriteLine("NOT YET IMPLEMENTED!");
                    break;
                case UIOption.CommandRover:
                    Console.WriteLine("NOT YET IMPLEMENTED!");
                    break;
                case UIOption.NewRover:
                    Console.WriteLine("NOT YET IMPLEMENTED!");
                    break;
                case UIOption.GetRoverInfo:
                    Console.WriteLine("NOT YET IMPLEMENTED!");
                    break;
                case UIOption.SwitchPlateau:
                    Console.WriteLine("NOT YET IMPLEMENTED!");
                    break;
                case UIOption.NewPlateau:
                    Console.WriteLine("NOT YET IMPLEMENTED!");
                    break;
                case UIOption.Quit:
                    // Eventually add saving of data prior to quitting...?
                    isToQuit = true;
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
