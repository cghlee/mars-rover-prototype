﻿namespace MarsRover.Tests;

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

    #region Move Tests
    [Test]
    public void Move_ReturnsFalseOnOutOfBoundsForwards()
    {
        // Arrange
        PlateauSize plateauSize = new PlateauSize(5, 5);

        Rover roverNorth = new Rover("testName", new RoverPosition(4, 4, Compass.North));
        Rover roverEast = new Rover("testName", new RoverPosition(4, 4, Compass.East));
        Rover roverSouth = new Rover("testName", new RoverPosition(0, 0, Compass.South));
        Rover roverWest = new Rover("testName", new RoverPosition(0, 0, Compass.West));

        // Act
        bool forwardNorthSuccess = roverNorth.Move(plateauSize, Command.MoveForward);
        bool forwardEastSuccess = roverEast.Move(plateauSize, Command.MoveForward);
        bool forwardSouthSuccess = roverSouth.Move(plateauSize, Command.MoveForward);
        bool forwardWestSuccess = roverWest.Move(plateauSize, Command.MoveForward);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(forwardNorthSuccess, Is.EqualTo(false));
            Assert.That(forwardEastSuccess, Is.EqualTo(false));
            Assert.That(forwardSouthSuccess, Is.EqualTo(false));
            Assert.That(forwardWestSuccess, Is.EqualTo(false));
        });
    }
    [Test]
    public void Move_ReturnsFalseOnOutOfBoundsBackwards()
    {
        // Arrange
        PlateauSize plateauSize = new PlateauSize(5, 5);

        Rover roverNorth = new Rover("testName", new RoverPosition(0, 0, Compass.North));
        Rover roverEast = new Rover("testName", new RoverPosition(0, 0, Compass.East));
        Rover roverSouth = new Rover("testName", new RoverPosition(4, 4, Compass.South));
        Rover roverWest = new Rover("testName", new RoverPosition(4, 4, Compass.West));

        // Act
        bool backwardNorthSuccess = roverNorth.Move(plateauSize, Command.MoveBack);
        bool backwardEastSuccess = roverEast.Move(plateauSize, Command.MoveBack);
        bool backwardSouthSuccess = roverSouth.Move(plateauSize, Command.MoveBack);
        bool backwardWestSuccess = roverWest.Move(plateauSize, Command.MoveBack);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(backwardNorthSuccess, Is.EqualTo(false));
            Assert.That(backwardEastSuccess, Is.EqualTo(false));
            Assert.That(backwardSouthSuccess, Is.EqualTo(false));
            Assert.That(backwardWestSuccess, Is.EqualTo(false));
        });
    }
    [Test]
    public void Move_ReturnsTrueOnSuccess()
    {
        // Arrange
        PlateauSize plateauSize = new PlateauSize(5, 5);

        Rover roverNorth = new Rover("testName", new RoverPosition(0, 0, Compass.North));
        Rover roverEast = new Rover("testName", new RoverPosition(0, 0, Compass.East));
        Rover roverSouth = new Rover("testName", new RoverPosition(4, 4, Compass.South));
        Rover roverWest = new Rover("testName", new RoverPosition(4, 4, Compass.West));

        // Act
        bool forwardNorthSuccess = roverNorth.Move(plateauSize, Command.MoveForward);
        bool forwardEastSuccess = roverEast.Move(plateauSize, Command.MoveForward);
        bool forwardSouthSuccess = roverSouth.Move(plateauSize, Command.MoveForward);
        bool forwardWestSuccess = roverWest.Move(plateauSize, Command.MoveForward);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(forwardNorthSuccess, Is.EqualTo(true));
            Assert.That(forwardEastSuccess, Is.EqualTo(true));
            Assert.That(forwardSouthSuccess, Is.EqualTo(true));
            Assert.That(forwardWestSuccess, Is.EqualTo(true));
        });
    }
    #endregion
}