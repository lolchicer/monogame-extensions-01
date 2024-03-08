using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MonogameTest01;

public class Input : ThirdAffector
{
    public enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }

    private const float _speed = 2.0f;
    private Mechanics _mechanics;

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
            case Direction.Up:
                _velocity += new Vector2 { X = 0, Y = -1 };
                break;
            case Direction.Down:
                _velocity += new Vector2 { X = 0, Y = 1 };
                break;
            default:
                break;
        }
    }

    private void Accelerate(IEnumerable<Direction> directions)
    {
        foreach (var direction in directions)
            Accelerate(direction);
    }

    public List<Direction> Directions { get; } = new();
    public Vector2 Velocity => _velocity;

    protected override void UpdateVelocity(GameTime gameTime)
    {
        _velocity = Vector2.Zero;
        // крутой аирконтроль чел
        if (_mechanics.Velocity == Vector2.Zero)
        {
            Accelerate(Directions);
            if (_velocity != Vector2.Zero)
            {
                _velocity.Normalize();
                _velocity *= _speed;
            }
        }
        Directions.Clear();
    }

    public Input(Mechanics mechanics)
    : base(mechanics)
    {
        _mechanics = mechanics;
    }
}
