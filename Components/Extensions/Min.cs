using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public static class MinExtensions
{
    public static Vector2 Min(this IEnumerable<Vector2> @this)
    {
        var min = Vector2.Zero;

        foreach (var item in @this)
            if (min != Vector2.Min(item, min))
                min = item;
        return min;
    }
}
