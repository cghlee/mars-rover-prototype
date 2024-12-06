using System.Text.RegularExpressions;

namespace MarsRover;

internal static class InputManager
{
    internal static string? GetInput(string prompt)
    {
        string? userInput;
        while (true)
        {
            Console.WriteLine(prompt);

            userInput = Console.ReadLine();
            if (!String.IsNullOrEmpty(userInput))
                break;
            else
                Console.WriteLine("Invalid input, please try again.\n");
        }

        return userInput!;
    }

    internal static int GetInputFromOptions(string prompt, int[] options)
    {
        int userInput = 0;
        while (true)
        {
            Console.WriteLine(prompt);

            bool isValidInt = int.TryParse(Console.ReadLine(), out userInput);
            if (isValidInt)
                if (options.Contains(userInput))
                    break;
            else
                Console.WriteLine("Invalid input, please try again.\n");
        }

        return userInput;
    }

    internal static PlateauSize? ParsePlateauSize(string userInput)
    {
        int minimumSize = 2;

        string normalisedInput = NormaliseInput(userInput)!;

        string[] splitInput = normalisedInput.Split(' ');
        if (splitInput.Length != 2)
            return null;

        bool isNumericWidth = int.TryParse(splitInput[0], out int width);
        bool isNumericHeight = int.TryParse(splitInput[1], out int height);

        bool isValidWidth = isNumericWidth && (width >= minimumSize);
        bool isValidHeight = isNumericHeight && (height >= minimumSize);

        if (isValidWidth && isValidHeight)
            return new PlateauSize(width, height);
        else
            return null;
    }

    internal static RoverPosition? ParseRoverPosition(string userInput)
    {
        string normalisedInput = NormaliseInput(userInput)!.ToUpper();

        string[] splitInput = normalisedInput.Split(' ');
        if (splitInput.Length != 3)
            return null;

        bool isNumericXCoord = int.TryParse(splitInput[0], out int xCoord);
        bool isNumericYCoord = int.TryParse(splitInput[1], out int yCoord);

        bool isValidXCoord = isNumericXCoord && (xCoord >= 0);
        bool isValidYCoord = isNumericYCoord && (yCoord >= 0);

        string[] validDirections = ["N", "E", "S", "W"];
        bool isValidDirection = validDirections.Contains(splitInput[2]);

        if (isValidXCoord && isValidYCoord && isValidDirection)
        {
            Compass direction = ConvertStringToDirection(splitInput[2]);
            return new RoverPosition(xCoord, yCoord, direction);
        }
        else
            return null;
    }

    internal static List<Command>? ParseCommands(string userInput)
    {
        string normalisedInput = NormaliseInput(userInput)!.ToUpper();

        string[] splitInput = normalisedInput.Split(' ');

        string[] validCommands = ["F", "B", "R", "L"];
        foreach (string commandString in splitInput)
            if (!validCommands.Contains(commandString))
                return null;

        List<Command> commands = splitInput.Select(s => ConvertStringToCommand(s))
                                           .ToList();
        return commands;
    }

    private static Compass ConvertStringToDirection(string compassString)
    {
        Compass compassEnum = compassString switch
        {
            "N" => Compass.North,
            "E" => Compass.East,
            "S" => Compass.South,
            "W" => Compass.West,
            _ => Compass.North
        };
        return compassEnum;
    }

    private static Command ConvertStringToCommand(string commandString)
    {
        Command commandEnum = commandString switch
        {
            "F" => Command.MoveForward,
            "B" => Command.MoveBack,
            "R" => Command.TurnRight,
            "L" => Command.TurnLeft,
            _ => Command.MoveForward
        };
        return commandEnum;
    }

    private static string? NormaliseInput(string input)
    {
        string nonCommaInput = input.Replace(',', ' ');
        string normalisedInput = Regex.Replace(nonCommaInput, @"\s+", " ")
                                      .Trim();
        return normalisedInput;
    }
}
