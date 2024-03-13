using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public static class IntersectionsExtensions
{
    // насколько же эта функция хорошо читается
    public static IEnumerable<Surface> Intersections(this SurfaceQuad @this, Vector2 vector, Vector2 velocity) =>
    from surface in @this.Surfaces
    let resized = vector.Resized(surface)
    where
    (resized - vector).Length() <= velocity.Length() &&
    surface.Collides(resized)
    select surface;
}
