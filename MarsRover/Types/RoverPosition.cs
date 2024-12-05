namespace MarsRover;

internal class RoverPosition
{
    internal int X { get; set; }
    internal int Y { get; set; }
    internal Compass Facing { get; set; }

    internal RoverPosition(int x, int y, Compass facing)
    {
        X = x;
        Y = y;
        Facing = facing;
    }
}
