namespace MarsRover;

internal class Program
{
    static void Main(string[] args)
    {
        string? input = "27 ,  72";

        // Act
        PlateauSize? result = InputParser.ParsePlateauSize(input);
    }
}
