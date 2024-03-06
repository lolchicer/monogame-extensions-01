using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public static class FullExtensions
{
    public static IEnumerable<IUpdateable> UpdateablesFull(this IParent value)
    {
        var updateables = new List<IUpdateable>();

        foreach (var updateable in value.Updateables)
            updateables.Add(updateable);
        foreach (var parent in value.Parents)
            foreach (var updateable in parent.UpdateablesFull())
                updateables.Add(updateable);
        
        return updateables;
    }

    public static IEnumerable<IDrawable> DrawablesFull(this IParent value)
    {
        var drawables = new List<IDrawable>();

        foreach (var drawable in value.Drawables)
            drawables.Add(drawable);
        foreach (var parent in value.Parents)
            foreach (var drawable in parent.DrawablesFull())
                drawables.Add(drawable);
        
        return drawables;
    }

    public static IEnumerable<IParent> ParentsFull(this IParent value)
    {
        var parents = new List<IParent>();

        foreach (var parent in value.Parents)
            parents.Add(parent);
        foreach (var parent in value.Parents)
            foreach (var subparent in parent.ParentsFull())
                parents.Add(subparent);
        
        return parents;
    }
}
