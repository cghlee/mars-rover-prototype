namespace MarsRover;

internal class RoverPosition
{
    internal int X { get; set; }
    internal int Y { get; set; }
    internal Compass Facing { get; set; }

    internal RoverPosition(int x, int y, string facing)
    {
        X = x;
        Y = y;

        Facing = (Compass)Enum.Parse(typeof(Compass), facing.ToUpper());
    }
}
