namespace MarsRover.Tests;

public class RoverTests
{
    #region Rotation Tests
    [Test]
    public void Rotation_TurnsRoverCorrectOnTurnRight()
    {
        // Arrange
        Rover testRoverNorth = new Rover("testName", new RoverPosition(0, 0, Compass.North));
        Rover testRoverEast = new Rover("testName", new RoverPosition(0, 0, Compass.East));
        Rover testRoverSouth = new Rover("testName", new RoverPosition(0, 0, Compass.South));
        Rover testRoverWest = new Rover("testName", new RoverPosition(0, 0, Compass.West));

        // Act
        Compass outputNorth = testRoverNorth.Rotate(Command.TurnRight);
        Compass outputEast = testRoverEast.Rotate(Command.TurnRight);
        Compass outputSouth = testRoverSouth.Rotate(Command.TurnRight);
        Compass outputWest = testRoverWest.Rotate(Command.TurnRight);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(testRoverNorth.RoverPosition.Facing, Is.EqualTo(Compass.East));
            Assert.That(testRoverEast.RoverPosition.Facing, Is.EqualTo(Compass.South));
            Assert.That(testRoverSouth.RoverPosition.Facing, Is.EqualTo(Compass.West));
            Assert.That(testRoverWest.RoverPosition.Facing, Is.EqualTo(Compass.North));
        });
    }
    [Test]
    public void Rotation_ReturnsCorrectOnTurnRight()
    {
        // Arrange
        Rover testRoverNorth = new Rover("testName", new RoverPosition(0, 0, Compass.North));
        Rover testRoverEast = new Rover("testName", new RoverPosition(0, 0, Compass.East));
        Rover testRoverSouth = new Rover("testName", new RoverPosition(0, 0, Compass.South));
        Rover testRoverWest = new Rover("testName", new RoverPosition(0, 0, Compass.West));

        // Act
        Compass outputNorth = testRoverNorth.Rotate(Command.TurnRight);
        Compass outputEast = testRoverEast.Rotate(Command.TurnRight);
        Compass outputSouth = testRoverSouth.Rotate(Command.TurnRight);
        Compass outputWest = testRoverWest.Rotate(Command.TurnRight);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(outputNorth, Is.EqualTo(Compass.East));
            Assert.That(outputEast, Is.EqualTo(Compass.South));
            Assert.That(outputSouth, Is.EqualTo(Compass.West));
            Assert.That(outputWest, Is.EqualTo(Compass.North));
        });
    }
    [Test]
    public void Rotation_TurnsRoverCorrectOnTurnLeft()
    {
        // Arrange
        Rover testRoverNorth = new Rover("testName", new RoverPosition(0, 0, Compass.North));
        Rover testRoverEast = new Rover("testName", new RoverPosition(0, 0, Compass.East));
        Rover testRoverSouth = new Rover("testName", new RoverPosition(0, 0, Compass.South));
        Rover testRoverWest = new Rover("testName", new RoverPosition(0, 0, Compass.West));

        // Act
        Compass outputNorth = testRoverNorth.Rotate(Command.TurnLeft);
        Compass outputEast = testRoverEast.Rotate(Command.TurnLeft);
        Compass outputSouth = testRoverSouth.Rotate(Command.TurnLeft);
        Compass outputWest = testRoverWest.Rotate(Command.TurnLeft);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(testRoverNorth.RoverPosition.Facing, Is.EqualTo(Compass.West));
            Assert.That(testRoverEast.RoverPosition.Facing, Is.EqualTo(Compass.North));
            Assert.That(testRoverSouth.RoverPosition.Facing, Is.EqualTo(Compass.East));
            Assert.That(testRoverWest.RoverPosition.Facing, Is.EqualTo(Compass.South));
        });
    }
    [Test]
    public void Rotation_ReturnsCorrectOnTurnLeft()
    {
        // Arrange
        Rover testRoverNorth = new Rover("testName", new RoverPosition(0, 0, Compass.North));
        Rover testRoverEast = new Rover("testName", new RoverPosition(0, 0, Compass.East));
        Rover testRoverSouth = new Rover("testName", new RoverPosition(0, 0, Compass.South));
        Rover testRoverWest = new Rover("testName", new RoverPosition(0, 0, Compass.West));

        // Act
        Compass outputNorth = testRoverNorth.Rotate(Command.TurnLeft);
        Compass outputEast = testRoverEast.Rotate(Command.TurnLeft);
        Compass outputSouth = testRoverSouth.Rotate(Command.TurnLeft);
        Compass outputWest = testRoverWest.Rotate(Command.TurnLeft);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(outputNorth, Is.EqualTo(Compass.West));
            Assert.That(outputEast, Is.EqualTo(Compass.North));
            Assert.That(outputSouth, Is.EqualTo(Compass.East));
            Assert.That(outputWest, Is.EqualTo(Compass.South));
        });
    }
    #endregion
}
