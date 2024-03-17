namespace MonogameTest01.Directions.Onedimensional;

public enum Enum
{
    Leftwards,
    Rightwards,
    Still
}

public struct Duo : ITuple
{
    public bool Leftwards;
    public bool Rightwards;

    public void Reset()
    {
        Leftwards = false;
        Rightwards = false;
    }
}
