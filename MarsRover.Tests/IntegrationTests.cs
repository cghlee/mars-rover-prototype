namespace MarsRover.Tests;

public class IntegrationTests
{
    [Test]
    public void MarsRover_MovesRoverCorrectlySimpleOne()
    {
        // Arrange
        string plateauSizeInput = "5, 5";
        string roverPositionInput = "1, 2, N";
        string commandInput = "l f l f l f l f f";

        int expectedX = 1;
        int expectedY = 3;
        Compass expectedFacing = Compass.North;

        // Act
        PlateauSize plateauSize = InputManager.ParsePlateauSize(plateauSizeInput);
        RoverPosition roverPosition = InputManager.ParseRoverPosition(roverPositionInput);
        List<Command> commandList = InputManager.ParseCommands(commandInput);

        Rover rover = new Rover("Rich", roverPosition);
        rover.ProcessCommands(commandList, plateauSize);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(rover.RoverPosition.X, Is.EqualTo(expectedX));
            Assert.That(rover.RoverPosition.Y, Is.EqualTo(expectedY));
            Assert.That(rover.RoverPosition.Facing, Is.EqualTo(expectedFacing));
        });
    }

    [Test]
    public void MarsRover_MovesRoverCorrectlySimpleTwo()
    {
        // Arrange
        string plateauSizeInput = "5, 5";
        string roverPositionInput = "3, 3, E";
        string commandInput = "F F R F F R F R R F";

        int expectedX = 4;
        int expectedY = 1;
        Compass expectedFacing = Compass.East;

        // Act
        PlateauSize plateauSize = InputManager.ParsePlateauSize(plateauSizeInput);
        RoverPosition roverPosition = InputManager.ParseRoverPosition(roverPositionInput);
        List<Command> commandList = InputManager.ParseCommands(commandInput);

        Rover rover = new Rover("Rich", roverPosition);
        rover.ProcessCommands(commandList, plateauSize);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(rover.RoverPosition.X, Is.EqualTo(expectedX));
            Assert.That(rover.RoverPosition.Y, Is.EqualTo(expectedY));
            Assert.That(rover.RoverPosition.Facing, Is.EqualTo(expectedFacing));
        });
    }

    [Test]
    public void MarsRover_MovesRoverCorrectlyComplex()
    {
        // Arrange
        string plateauSizeInput = "5, 5";
        string roverPositionInput = "1, 1, W";
        string commandInput = "F R F F L B B R F R R F F F F F F B L B F F L L";

        int expectedX = 3;
        int expectedY = 1;
        Compass expectedFacing = Compass.West;

        // Act
        PlateauSize plateauSize = InputManager.ParsePlateauSize(plateauSizeInput);
        RoverPosition roverPosition = InputManager.ParseRoverPosition(roverPositionInput);
        List<Command> commandList = InputManager.ParseCommands(commandInput);

        Rover rover = new Rover("Rich", roverPosition);
        rover.ProcessCommands(commandList, plateauSize);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(rover.RoverPosition.X, Is.EqualTo(expectedX));
            Assert.That(rover.RoverPosition.Y, Is.EqualTo(expectedY));
            Assert.That(rover.RoverPosition.Facing, Is.EqualTo(expectedFacing));
        });
    }
}
