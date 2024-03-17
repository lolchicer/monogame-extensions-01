using System.Linq;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public static class CroppedExtensions
{
    public static Vector2 Cropped(this Surface @this, Vector2 value)
    {
        if (@this.Collides(value))
            return @this.Normal(value);
        else
            return Vector2.Zero;
    }

    public static Vector2 Cropped(this SurfaceQuad @this, Vector2 value)
    {
        if (@this.Collides(value))
            return (
                from surface in @this.Surfaces
                select surface.Normal(value)).Max();
        else
            return Vector2.Zero;
    }
}
