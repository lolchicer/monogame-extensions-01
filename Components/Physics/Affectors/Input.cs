using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MonogameTest01;

public class Input : ThirdAffector
{
    private const float _minSpeed = 2.0f;
    private const float _maxSpeed = 4.0f;
    private Mechanics _mechanics;

    public Directions.Onedimensional.Duo Directions { get; set; }
    public Vector2 Velocity => _velocity;

    private void Accelerate()
    {
        if(Directions.Leftwards)
            _velocity += new Vector2 { X = -1, Y = 0 };
        if(Directions.Rightwards)
            _velocity += new Vector2 { X = 1, Y = 0 };
    }

    private void Normalize()
    {
        if (_velocity != Vector2.Zero)
        {
            _velocity.Normalize();
            _velocity *= _minSpeed;
        }
    }

    // крутой аирконтроль чел
    private void Hold()
    {
        if (_mechanics.Velocity.Length() > _maxSpeed)
            _velocity = Vector2.Zero;
    }

    protected override void UpdateVelocity(GameTime gameTime)
    {
        Accelerate();
        Normalize();
        Hold();
        Directions.Reset();
    }

    public Input(Mechanics mechanics)
    : base(mechanics)
    {
        _mechanics = mechanics;
    }
}
