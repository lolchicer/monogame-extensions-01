using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace MonogameTest01;

public class Input : Affector
{
    public enum Direction
    {
        Up,
        Left,
        Down,
        Right
    }

    private const float _speed = 0.5f;

    private MechanicsVelocityPoller _mechanicsVelocityPoller;

    private void Accelerate(Direction direction)
    {
        switch (direction)
        {
            case Direction.Up:
                _velocity += new Vector2 { X = 0, Y = -1 };
                break;
            case Direction.Left:
                _velocity += new Vector2 { X = -1, Y = 0 };
                break;
            case Direction.Down:
                _velocity += new Vector2 { X = 0, Y = 1 };
                break;
            case Direction.Right:
                _velocity += new Vector2 { X = 1, Y = 0 };
                break;
            default:
                break;
        }

        /* if (_mechanicsVelocityPoller.Velocity != Vector2.Zero)
            // крутой аирконтроль чел
            _velocity = new();
        else
        { */
            _velocity.Normalize();
            _velocity *= _speed;
        // }
    }

    private void Accelerate(IEnumerable<Direction> directions)
    {
        foreach (var direction in directions)
            Accelerate(direction);
    }

    public List<Direction> Directions { get; } = new();

    protected override void UpdateVelocity(GameTime gameTime)
    {
        _velocity = Vector2.Zero;
        Accelerate(Directions);
        Directions.Clear();
    }

    public Input(MechanicsVelocityPoller mechanicsVelocityPoller, Mechanics mechanics) : base(mechanics)
    {
        _mechanicsVelocityPoller = mechanicsVelocityPoller;
    }
}