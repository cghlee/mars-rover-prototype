namespace MarsRover.Tests;

public class InputParserTests
{
    #region ParsePlateauSize Tests
    [Test]
    public void ParsePlateauSize_ReturnsNullOnNullInput()
    {
        // Arrange
        string? input = null;
        PlateauSize? expected = null;

        // Act
        PlateauSize? result = InputParser.ParsePlateauSize(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void ParsePlateauSize_ReturnsNullOnEmptyInput()
    {
        // Arrange
        string? input = "";
        PlateauSize? expected = null;

        // Act
        PlateauSize? result = InputParser.ParsePlateauSize(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void ParsePlateauSize_ReturnsNullOnSingleSpaceInput()
    {
        // Arrange
        string? input = " ";
        PlateauSize? expected = null;

        // Act
        PlateauSize? result = InputParser.ParsePlateauSize(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void ParsePlateauSize_ReturnsNullOnTooShortInput()
    {
        // Arrange
        string? input = "1";
        PlateauSize? expected = null;

        // Act
        PlateauSize? result = InputParser.ParsePlateauSize(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void ParsePlateauSize_ReturnsNullOnTooLongInput()
    {
        // Arrange
        string? input = "1 2 3";
        PlateauSize? expected = null;

        // Act
        PlateauSize? result = InputParser.ParsePlateauSize(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void ParsePlateauSize_ReturnsNullOnExtraLongInput()
    {
        // Arrange
        string? input = "1 2 3 4 5 6";
        PlateauSize? expected = null;

        // Act
        PlateauSize? result = InputParser.ParsePlateauSize(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void ParsePlateauSize_ReturnsNullOnNonNumberFirst()
    {
        // Arrange
        string? input = "F 2";
        PlateauSize? expected = null;

        // Act
        PlateauSize? result = InputParser.ParsePlateauSize(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void ParsePlateauSize_ReturnsNullOnNonNumberSecond()
    {
        // Arrange
        string? input = "1 F";
        PlateauSize? expected = null;

        // Act
        PlateauSize? result = InputParser.ParsePlateauSize(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void ParsePlateauSize_ReturnsNullOnZeroFirst()
    {
        // Arrange
        string? input = "0 2";
        PlateauSize? expected = null;

        // Act
        PlateauSize? result = InputParser.ParsePlateauSize(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void ParsePlateauSize_ReturnsNullOnZeroSecond()
    {
        // Arrange
        string? input = "2 0";
        PlateauSize? expected = null;

        // Act
        PlateauSize? result = InputParser.ParsePlateauSize(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void ParsePlateauSize_ReturnsNullOnNegativeFirst()
    {
        // Arrange
        string? input = "-1 2";
        PlateauSize? expected = null;

        // Act
        PlateauSize? result = InputParser.ParsePlateauSize(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void ParsePlateauSize_ReturnsNullOnNegativeSecond()
    {
        // Arrange
        string? input = "3 -2";
        PlateauSize? expected = null;

        // Act
        PlateauSize? result = InputParser.ParsePlateauSize(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void ParsePlateauSize_ReturnsObjectSimpleSingleSpaceDelimited()
    {
        // Arrange
        string? input = "2 2";
        PlateauSize? expected = new PlateauSize(2, 2);

        // Act
        PlateauSize? result = InputParser.ParsePlateauSize(input);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Width, Is.EqualTo(expected.Width));
            Assert.That(result.Height, Is.EqualTo(expected.Height));
        });
    }
    [Test]
    public void ParsePlateauSize_ReturnsObjectComplexSingleSpaceDelimited()
    {
        // Arrange
        string? input = "12 27";
        PlateauSize? expected = new PlateauSize(12, 27);

        // Act
        PlateauSize? result = InputParser.ParsePlateauSize(input);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Width, Is.EqualTo(expected.Width));
            Assert.That(result.Height, Is.EqualTo(expected.Height));
        });
    }
    [Test]
    public void ParsePlateauSize_ReturnsObjectSimpleMultipleSpaceDelimited()
    {
        // Arrange
        string? input = "3   3";
        PlateauSize? expected = new PlateauSize(3, 3);

        // Act
        PlateauSize? result = InputParser.ParsePlateauSize(input);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Width, Is.EqualTo(expected.Width));
            Assert.That(result.Height, Is.EqualTo(expected.Height));
        });
    }
    [Test]
    public void ParsePlateauSize_ReturnsObjectComplexMultipleSpaceDelimited()
    {
        // Arrange
        string? input = "27   72";
        PlateauSize? expected = new PlateauSize(27, 72);

        // Act
        PlateauSize? result = InputParser.ParsePlateauSize(input);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Width, Is.EqualTo(expected.Width));
            Assert.That(result.Height, Is.EqualTo(expected.Height));
        });
    }
    [Test]
    public void ParsePlateauSize_ReturnsObjectSimpleCommaDelimited()
    {
        // Arrange
        string? input = "2,2";
        PlateauSize? expected = new PlateauSize(2, 2);

        // Act
        PlateauSize? result = InputParser.ParsePlateauSize(input);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Width, Is.EqualTo(expected.Width));
            Assert.That(result.Height, Is.EqualTo(expected.Height));
        });
    }
    [Test]
    public void ParsePlateauSize_ReturnsObjectComplexCommaDelimited()
    {
        // Arrange
        string? input = "12,27";
        PlateauSize? expected = new PlateauSize(12, 27);

        // Act
        PlateauSize? result = InputParser.ParsePlateauSize(input);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Width, Is.EqualTo(expected.Width));
            Assert.That(result.Height, Is.EqualTo(expected.Height));
        });
    }
    [Test]
    public void ParsePlateauSize_ReturnsObjectSimpleCommaSpaceDelimited()
    {
        // Arrange
        string? input = "2, 2";
        PlateauSize? expected = new PlateauSize(2, 2);

        // Act
        PlateauSize? result = InputParser.ParsePlateauSize(input);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Width, Is.EqualTo(expected.Width));
            Assert.That(result.Height, Is.EqualTo(expected.Height));
        });
    }
    [Test]
    public void ParsePlateauSize_ReturnsObjectComplexCommaSpaceDelimited()
    {
        // Arrange
        string? input = "12, 27";
        PlateauSize? expected = new PlateauSize(12, 27);

        // Act
        PlateauSize? result = InputParser.ParsePlateauSize(input);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Width, Is.EqualTo(expected.Width));
            Assert.That(result.Height, Is.EqualTo(expected.Height));
        });
    }
    [Test]
    public void ParsePlateauSize_ReturnsObjectSimpleMultipleCommaSpaceDelimited()
    {
        // Arrange
        string? input = "3  , 3";
        PlateauSize? expected = new PlateauSize(3, 3);

        // Act
        PlateauSize? result = InputParser.ParsePlateauSize(input);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Width, Is.EqualTo(expected.Width));
            Assert.That(result.Height, Is.EqualTo(expected.Height));
        });
    }
    [Test]
    public void ParsePlateauSize_ReturnsObjectComplexMultipleCommaSpaceDelimited()
    {
        // Arrange
        string? input = "27 ,  72";
        PlateauSize? expected = new PlateauSize(27, 72);

        // Act
        PlateauSize? result = InputParser.ParsePlateauSize(input);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Width, Is.EqualTo(expected.Width));
            Assert.That(result.Height, Is.EqualTo(expected.Height));
        });
    }
    [Test]
    public void ParsePlateauSize_ReturnsObjectPrependedSpaces()
    {
        // Arrange
        string? input = "  2 2";
        PlateauSize? expected = new PlateauSize(2, 2);

        // Act
        PlateauSize? result = InputParser.ParsePlateauSize(input);

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Width, Is.EqualTo(expected.Width));
            Assert.That(result.Height, Is.EqualTo(expected.Height));
        });
    }
    [Test]
    public void ParsePlateauSize_ReturnsObjectPostpendedSpaces()
    {
        // Arrange
        string? input = "2 2  ";
        PlateauSize? expected = new PlateauSize(2, 2);

        // Act
        PlateauSize? result = InputParser.ParsePlateauSize(input);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Width, Is.EqualTo(expected.Width));
            Assert.That(result.Height, Is.EqualTo(expected.Height));
        });
    }
    #endregion

    #region ParseRoverPosition Tests
    [Test]
    public void ParseRoverPosition_ReturnsNullOnNullInput()
    {
        // Arrange
        string? input = null;
        RoverPosition? expected = null;

        // Act
        RoverPosition? result = InputParser.ParseRoverPosition(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void ParseRoverPosition_ReturnsNullOnEmptyInput()
    {
        // Arrange
        string? input = "";
        RoverPosition? expected = null;

        // Act
        RoverPosition? result = InputParser.ParseRoverPosition(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void ParseRoverPosition_ReturnsNullOnSingleSpaceInput()
    {
        // Arrange
        string? input = " ";
        RoverPosition? expected = null;

        // Act
        RoverPosition? result = InputParser.ParseRoverPosition(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void ParseRoverPosition_ReturnsNullOnTooShortInput()
    {
        // Arrange
        string? input = "1 2";
        RoverPosition? expected = null;

        // Act
        RoverPosition? result = InputParser.ParseRoverPosition(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void ParseRoverPosition_ReturnsNullOnTooLongInput()
    {
        // Arrange
        string? input = "1 2 N 4";
        RoverPosition? expected = null;

        // Act
        RoverPosition? result = InputParser.ParseRoverPosition(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void ParseRoverPosition_ReturnsNullOnExtraLongInput()
    {
        // Arrange
        string? input = "1 2 N 4 5 6 7";
        RoverPosition? expected = null;

        // Act
        RoverPosition? result = InputParser.ParseRoverPosition(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void ParseRoverPosition_ReturnsNullOnZeroXInput()
    {
        // Arrange
        string? input = "0 2 N";
        RoverPosition? expected = null;

        // Act
        RoverPosition? result = InputParser.ParseRoverPosition(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void ParseRoverPosition_ReturnsNullOnZeroYInput()
    {
        // Arrange
        string? input = "1 0 N";
        RoverPosition? expected = null;

        // Act
        RoverPosition? result = InputParser.ParseRoverPosition(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void ParseRoverPosition_ReturnsNullOnNegativeXInput()
    {
        // Arrange
        string? input = "-1 2 N";
        RoverPosition? expected = null;

        // Act
        RoverPosition? result = InputParser.ParseRoverPosition(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void ParseRoverPosition_ReturnsNullOnNegativeYInput()
    {
        // Arrange
        string? input = "1 -2 N";
        RoverPosition? expected = null;

        // Act
        RoverPosition? result = InputParser.ParseRoverPosition(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void ParseRoverPosition_ReturnsNullOnInvalidDirection()
    {
        // Arrange
        string? input = "1 2 F";
        RoverPosition? expected = null;

        // Act
        RoverPosition? result = InputParser.ParseRoverPosition(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void ParseRoverPosition_ReturnsObjectSimpleDirectionUpper()
    {
        // Arrange
        string? input = "1 2 N";
        RoverPosition? expected = new RoverPosition(1, 2, "N");

        // Act
        RoverPosition? result = InputParser.ParseRoverPosition(input);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.X, Is.EqualTo(expected.X));
            Assert.That(result.Y, Is.EqualTo(expected.Y));
            Assert.That(result.Facing, Is.EqualTo(expected.Facing));
        });
    }
    [Test]
    public void ParseRoverPosition_ReturnsObjectSimpleDirectionLower()
    {
        // Arrange
        string? input = "1 2 N";
        RoverPosition? expected = new RoverPosition(1, 2, "n");

        // Act
        RoverPosition? result = InputParser.ParseRoverPosition(input);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.X, Is.EqualTo(expected.X));
            Assert.That(result.Y, Is.EqualTo(expected.Y));
            Assert.That(result.Facing, Is.EqualTo(expected.Facing));
        });
    }
    [Test]
    public void ParseRoverPosition_ReturnsObjectComplex()
    {
        // Arrange
        string? input = "12 27 N";
        RoverPosition? expected = new RoverPosition(12, 27, "N");

        // Act
        RoverPosition? result = InputParser.ParseRoverPosition(input);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.X, Is.EqualTo(expected.X));
            Assert.That(result.Y, Is.EqualTo(expected.Y));
            Assert.That(result.Facing, Is.EqualTo(expected.Facing));
        });
    }
    #endregion

    #region ParseCommands Tests
    [Test]
    public void ParseCommands_ReturnsNullOnNullInput()
    {
        // Arrange
        string? input = null;
        List<Command>? expected = null;

        // Act
        List<Command>? result = InputParser.ParseCommands(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void ParseCommands_ReturnsNullOnEmptyInput()
    {
        // Arrange
        string? input = "";
        List<Command>? expected = null;

        // Act
        List<Command>? result = InputParser.ParseCommands(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void ParseCommands_ReturnsNullOnSingleSpaceInput()
    {
        // Arrange
        string? input = " ";
        List<Command>? expected = null;

        // Act
        List<Command>? result = InputParser.ParseCommands(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void ParseCommands_ReturnsNullOnNumericInputs()
    {
        // Arrange
        string? input = "1 2 3";
        List<Command>? expected = null;

        // Act
        List<Command>? result = InputParser.ParseCommands(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void ParseCommands_ReturnsObjectSimpleSpaceDelimited()
    {
        // Arrange
        string? input = "L F R";
        List<Command>? expected = [Command.L, Command.F, Command.R];

        // Act
        List<Command>? result = InputParser.ParseCommands(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void ParseCommands_ReturnsObjectComplexSpaceDelimited()
    {
        // Arrange
        string? input = "L F R R F L F F F";
        List<Command>? expected = [Command.L, Command.F, Command.R,
                                   Command.R, Command.F, Command.L,
                                   Command.F, Command.F, Command.F];

        // Act
        List<Command>? result = InputParser.ParseCommands(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void ParseCommands_ReturnsObjectSimpleCommaDelimited()
    {
        // Arrange
        string? input = "L,F,R";
        List<Command>? expected = [Command.L, Command.F, Command.R];

        // Act
        List<Command>? result = InputParser.ParseCommands(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void ParseCommands_ReturnsObjectComplexCommaDelimited()
    {
        // Arrange
        string? input = "L,F,R,R,F,L,F,F,F";
        List<Command>? expected = [Command.L, Command.F, Command.R,
                                   Command.R, Command.F, Command.L,
                                   Command.F, Command.F, Command.F];

        // Act
        List<Command>? result = InputParser.ParseCommands(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void ParseCommands_ReturnsObjectSimpleCommaSpaceDelimited()
    {
        // Arrange
        string? input = "L, F, R";
        List<Command>? expected = [Command.L, Command.F, Command.R];

        // Act
        List<Command>? result = InputParser.ParseCommands(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    [Test]
    public void ParseCommands_ReturnsObjectComplexCommaSpaceDelimited()
    {
        // Arrange
        string? input = "L, F, R, R, F, L, F, F, F";
        List<Command>? expected = [Command.L, Command.F, Command.R,
                                   Command.R, Command.F, Command.L,
                                   Command.F, Command.F, Command.F];

        // Act
        List<Command>? result = InputParser.ParseCommands(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
    #endregion
}
