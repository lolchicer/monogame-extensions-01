using Microsoft.Xna.Framework;

namespace MonogameTest01;

public static class NormalExtensions
{
    // ищется нормаль, исходящая от @this
    public static Vector2 Normal(this Surface @this, Vector2 value) =>
    @this.Direction switch
    {
        Directions.Twodimensional.Enum.Leftwards => new Vector2() { X = value.X - @this.Float, Y = 0 },
        Directions.Twodimensional.Enum.Updwards => new Vector2() { X = 0, Y = value.Y - @this.Float },
        Directions.Twodimensional.Enum.Rightwards => new Vector2() { X = value.X - @this.Float, Y = 0 },
        Directions.Twodimensional.Enum.Downwards => new Vector2() { X = 0, Y = value.Y - @this.Float },
        _ => new Vector2() { X = value.X - @this.Float, Y = 0 }
    };
}
