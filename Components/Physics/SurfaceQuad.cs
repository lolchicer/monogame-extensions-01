using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public struct SurfaceQuad : IPushing
{
    public float Left;
    public float Top;
    public float Right;
    public float Bottom;

    public IEnumerable<Surface> SurfacesHorizontal => new Surface[]
    {
        new() { Float = Left, Direction = Directions.Twodimensional.Enum.Leftwards },
        new() { Float = Right, Direction = Directions.Twodimensional.Enum.Rightwards }
    };

    public IEnumerable<Surface> SurfacesVertical => new Surface[]
    {
        new() { Float = Top, Direction = Directions.Twodimensional.Enum.Updwards },
        new() { Float = Bottom, Direction = Directions.Twodimensional.Enum.Downwards }
    };

    public IEnumerable<Surface> Surfaces => new Surface[]
    {
        new() { Float = Left, Direction = Directions.Twodimensional.Enum.Leftwards },
        new() { Float = Top, Direction = Directions.Twodimensional.Enum.Updwards },
        new() { Float = Right, Direction = Directions.Twodimensional.Enum.Rightwards },
        new() { Float = Bottom, Direction = Directions.Twodimensional.Enum.Downwards }
    };

    public Vector2 Normal(Vector2 vector, Vector2 velocity)
    {
        var a = vector + velocity;
        var normals = new List<Vector2>();
        foreach (var surface in Surfaces)
            if (surface.Collides(a))
                normals.Add(surface.Normal(a));
            else
                normals.Add(Vector2.Zero);
        return normals.Max();
    }

    public SurfaceQuad(Vector2 vector, Vector2 hitbox)
    {
        Left = vector.X;
        Top = vector.Y;
        Right = hitbox.X;
        Bottom = hitbox.Y;
    }
}
