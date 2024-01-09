using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class Collision : LinkingComponent
{
    private MechanicsVelocityPoller _mechanicsVelocityPoller;
    private MechanicsPositionPoller _mechanicsPositionPoller;
    private CollisionMeta _meta;
    
    public Vector2 Position => _mechanicsPositionPoller.Position;
    public Vector2 BoxSize { get; }

    protected override void UpdateVelocity(GameTime gameTime)
    {
        foreach (var collisionBox in _meta.GetOutside(this))
            if (collisionBox.Intersects(
                new Rectangle(
                    (_mechanicsPositionPoller.Position + _mechanicsVelocityPoller.Velocity).ToPoint(),
                    BoxSize.ToPoint())))
                _velocity = -_mechanicsVelocityPoller.Velocity;
    }

    // конструктор с побочными эффектами
    public Collision(Mechanics mechanics, MechanicsVelocityPoller mechanicsVelocityPoller, MechanicsPositionPoller mechanicsPositionPoller, CollisionMeta meta, Vector2 boxSize) : base(mechanics.Game)
    {
        meta.Collisions.Add(this);

        _mechanicsVelocityPoller = mechanicsVelocityPoller;
        _mechanicsPositionPoller = mechanicsPositionPoller;
        _meta = meta;
        BoxSize = boxSize;
    }
}