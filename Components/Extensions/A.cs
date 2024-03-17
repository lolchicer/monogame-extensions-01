using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public static class AExtensions
{
    public static Vector2 A(this Vector2 @this, IEnumerable<Surface> surfaces)
    {
        var aTuples =
        from item in surfaces
        select (
            Surface: item,
            Length: @this.Resized(item).Length()
        );

        var aLenghts = new List<(
            float Length,
            List<Surface> Surfaces
        )>(
        from item in aTuples
        select (
            item.Length,
            Surfaces: new List<Surface>()
        ));

        foreach (var item1 in aLenghts.ToArray())
            foreach (var item2 in aLenghts.ToArray())
                if (item1.Length == item2.Length)
                    aLenghts.Remove(item1);
        
        foreach (var (Surface, Length) in aTuples)
            aLenghts.First(length => length.Length == Length).Surfaces.Add(Vector.Surface);
        
        
    }
}