using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class MechanicsVelocityPoller : GameComponent
{
    private Mechanics _mechanics;
    private Vector2 _velocity;

    public override void Update(GameTime gameTime)
    {
        _velocity = _mechanics.Velocity;
    }

    public Vector2 Velocity => _velocity;

    public MechanicsVelocityPoller(Mechanics mechanics)
    : base(mechanics.Game)
    {
        _mechanics = mechanics;
        // не знаю правильно ли это
        _velocity = mechanics.Velocity;
    }
}
