using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class Collision : ILinkingComponent
{
    private Mechanics _mechanics;
    private CollisionMeta _meta;

    public Mechanics Mechanics => _mechanics;
    public Vector2 DestinatedVelocity =>
    _meta.Normal(this);

    public Vector2 Velocity => Vector2.Zero;

    // конструктор с побочными эффектами
    public Collision(Mechanics mechanics, CollisionMeta meta)
    {
        _mechanics = mechanics;
        _meta = meta;

        meta.Collisions.Add(this);
    }
}
