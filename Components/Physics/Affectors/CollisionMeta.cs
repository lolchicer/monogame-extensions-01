using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class CollisionMeta
{
    public IList<Collision> Collisions { get; } = new List<Collision>();

    public Vector2 Normal(Collision excludedCollision)
    {
        return (
            from collision in Collisions
            where collision != excludedCollision
            select collision.Mechanics.Normal(
                excludedCollision.Mechanics.Position,
                excludedCollision.Mechanics.Velocity)).Max();
    }
}
