using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace MonogameTest01;

public class CollisionMeta
{
    public List<Collision> Collisions { get; } = new();

    public IEnumerable<Rectangle> GetOutside(Collision excludedCollision)
    {
        return from collision in Collisions
               where collision != excludedCollision
               select new Rectangle(
                collision.Position.ToPoint(),
                collision.BoxSize.ToPoint());
    }
}