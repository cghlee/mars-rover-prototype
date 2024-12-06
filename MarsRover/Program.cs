namespace MarsRover;

internal class Program
{
    static void Main(string[] args)
    {
        MarsManager marsManager = new();
        UIManager uiManager = new(marsManager);

        uiManager.Run();


        //string plateauSizeInput = "5 , 5";
        //PlateauSize? plateauSize = InputManager.ParsePlateauSize(plateauSizeInput);

        //string roverPositionInput = " 1,  2, N";
        //RoverPosition? roverPosition = InputManager.ParseRoverPosition(roverPositionInput);

        //List<Command>? test = InputManager.ParseCommands("l f l f l f l f f");

        //Rover rover = new Rover("Rich", roverPosition);

        //rover.ProcessCommands(test, plateauSize);

        //Console.WriteLine(rover.RoverPosition.X);
        //Console.WriteLine(rover.RoverPosition.Y);
        //Console.WriteLine(rover.RoverPosition.Facing);
    }
}
