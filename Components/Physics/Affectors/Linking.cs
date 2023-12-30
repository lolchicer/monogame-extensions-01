using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class Linking : Affector
{
    private Vector2 _linkVelocity;
    
    protected override void UpdateVelocity(GameTime gameTime)
    {
        _velocity = _linkVelocity;
    }

    public Vector2 LinkVelocity => _linkVelocity;

    public Linking(Vector2 velocity, Mechanics mechanics)
    : base(mechanics)
    {
        _linkVelocity = velocity;
    }
}