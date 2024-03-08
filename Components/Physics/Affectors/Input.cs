using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MonogameTest01;

public class Input : ThirdAffector
{
    public enum Direction
    {
        Left,
        Right
    }

    private const float _minSpeed = 2.0f;
    private const float _maxSpeed = 4.0f;
    private Mechanics _mechanics;

    public List<Direction> Directions { get; } = new();
    public Vector2 Velocity => _velocity;

    private void Accelerate(Direction direction)
    {
        switch (direction)
        {
            case Direction.Left:
                _velocity += new Vector2 { X = -1, Y = 0 };
                break;
            case Direction.Right:
                _velocity += new Vector2 { X = 1, Y = 0 };
                break;
            default:
                break;
        }
    }

    private void Accelerate()
    {
        foreach (var direction in Directions)
            Accelerate(direction);
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
        Directions.Clear();
    }

    public Input(Mechanics mechanics)
    : base(mechanics)
    {
        _mechanics = mechanics;
    }
}
