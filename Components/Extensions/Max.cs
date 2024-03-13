using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public static class MaxExtensions
{
    public static Vector2 Max(this IEnumerable<Vector2> @this)
    {
        var max = Vector2.Zero;

        foreach (var item in @this)
            if (max != Vector2.Max(item, max))
                max = item;
        return max;
    }
}
