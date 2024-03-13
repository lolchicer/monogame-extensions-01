using System;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public static class ResizedExtensions
{
    public static Vector2 ResizedHorizontal(this Vector2 @this, float value) =>
    new()
    {
        X = value,
        Y = @this.Y * (value / @this.X)
    };

    public static Vector2 ResizedVertical(this Vector2 @this, float value) =>
    new()
    {
        X = @this.X * (value / @this.Y),
        Y = value
    };

    public static Vector2 Resized(this Vector2 @this, Surface value) =>
    value.Direction switch
    {
        Directions.Twodimensional.Enum.Leftwards or
        Directions.Twodimensional.Enum.Rightwards =>
        @this.ResizedHorizontal(value.Float),

        Directions.Twodimensional.Enum.Updwards or
        Directions.Twodimensional.Enum.Downwards =>
        @this.ResizedHorizontal(value.Float),

        _ => throw new NotImplementedException()
    };
}
