using System.Text.RegularExpressions;

namespace MarsRover;

internal static class InputManager
{
    internal static string? GetUserInput(string prompt)
    {
        Console.WriteLine(prompt);

        string? userInput = Console.ReadLine();
        if (String.IsNullOrEmpty(userInput))
            return null;

        return userInput;
    }

    internal static PlateauSize? ParsePlateauSize(string userInput)
    {
        int minimumSize = 2;

        string normalisedInput = NormaliseInput(userInput)!;

        string[] splitInput = normalisedInput.Split(' ');
        if (splitInput.Length != 2)
            return null;

        bool isNumericWidth = int.TryParse(splitInput[0], out int Width);
        bool isNumericHeight = int.TryParse(splitInput[1], out int Height);

        bool isValidWidth = isNumericWidth && (Width >= minimumSize);
        bool isValidHeight = isNumericHeight && (Height >= minimumSize);

        if (isValidWidth && isValidHeight)
            return new PlateauSize(Width, Height);
        else
            return null;
    }

    internal static RoverPosition? ParseRoverPosition(string userInput)
    {
        string normalisedInput = NormaliseInput(userInput)!;

        string[] splitInput = normalisedInput.Split(' ');
        if (splitInput.Length != 3)
            return null;

        bool isNumericXCoord = int.TryParse(splitInput[0], out int X);
        bool isNumericYCoord = int.TryParse(splitInput[1], out int Y);

        bool isValidXCoord = isNumericXCoord && (X > 0);
        bool isValidYCoord = isNumericYCoord && (Y > 0);

        string[] validDirections = Enum.GetNames(typeof(Compass));
        bool isValidDirection = validDirections.Contains(splitInput[2]);

        if (isValidXCoord && isValidYCoord && isValidDirection)
            return new RoverPosition(X, Y, splitInput[2]);
        else
            return null;
    }

    internal static List<Command>? ParseCommands(string userInput)
    {
        string normalisedInput = NormaliseInput(userInput)!;

        string[] splitInput = normalisedInput.Split(' ');

        string[] validCommands = Enum.GetNames(typeof(Command));

        foreach (string command in splitInput)
            if (!validCommands.Contains(command))
                return null;

        List<Command> commands = splitInput.Select(s => (Command)Enum.Parse(typeof(Command), s))
                                           .ToList();
        return commands;
    }

    private static string? NormaliseInput(string input)
    {
        string nonCommaInput = input.Replace(',', ' ');
        string normalisedInput = Regex.Replace(nonCommaInput, @"\s+", " ")
                                      .Trim();
        return normalisedInput;
    }
}
