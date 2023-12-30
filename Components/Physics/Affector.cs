using Microsoft.Xna.Framework;

namespace MonogameTest01;

public abstract class Affector : GameComponent
{
    private Mechanics _mechanics;
    
    protected Vector2 _velocity;
    
    protected abstract void UpdateVelocity(GameTime gameTime);

    // пока неясно как надо ли использовать Mechanics целиком
    public Vector2 Velocity => _velocity;

    public override void Update(GameTime gameTime)
    {
        _velocity = Vector2.Zero;
        UpdateVelocity(gameTime);
        _mechanics.Velocity += _velocity;

        base.Update(gameTime);
    }

    public Affector(Mechanics mechanics) : base(mechanics.Game)
    {
        _mechanics = mechanics;
    }
}