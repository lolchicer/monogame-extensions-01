using System.Linq;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public static class CollidesExtensions
{
    // ищется, сонаправлена ли нормаль "выталкивающей" стороне
    public static bool Collides(this Surface @this, Vector2 value) =>
    @this.Direction switch
    {
        Directions.Twodimensional.Enum.Leftwards => value.X - @this.Float >= 0,
        Directions.Twodimensional.Enum.Updwards => value.Y - @this.Float >= 0,
        Directions.Twodimensional.Enum.Rightwards => value.X - @this.Float <= 0,
        Directions.Twodimensional.Enum.Downwards => value.Y - @this.Float <= 0,
        _ => value.X - @this.Float <= 0
    };

    public static bool Collides(this SurfaceQuad @this, Vector2 value) =>
    @this.Surfaces.All(surface => surface.Collides(value));
}
