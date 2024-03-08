namespace MonogameTest01.Directions.Twodimensional;

public enum Enum
{
    Leftwards,
    Updwards,
    Rightwards,
    Downwards
}

public struct Quad : ITuple
{
    public bool Leftwards;
    public bool Upwards;
    public bool Rightwards;
    public bool Downwards;

    public void Reset()
    {
        Leftwards = false;
        Upwards = false;
        Rightwards = false;
        Downwards = false;
    }
}
