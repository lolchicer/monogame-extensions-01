using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class Friction : FirstAffector
{
    private const float _speed = 3.0f;
    // возможно лишнее свойство
    private Vector2 StartVelocity => _mechanicsVelocityPoller.Velocity;
    private MechanicsVelocityPoller _mechanicsVelocityPoller;

    private void Compensate()
    {
        _mechanicsVelocityPoller.Velocity.AddNew(-(_velocity + StartVelocity));
    }

    protected override void UpdateVelocity(GameTime gameTime)
    {
        if (_mechanics.Velocity != Vector2.Zero)
        {
            var normalizedVelocity = _mechanics.Velocity;
            normalizedVelocity.Normalize();
            _velocity = (-normalizedVelocity) * _speed;

            if (StartVelocity.Length() - _speed <= 0)
                Compensate();
        }
    }

    // инстанц потребуется в дальнейшем
    public Vector2 Limit => Vector2.Zero;

    public Friction(MechanicsVelocityPoller mechanicsVelocityPoller, Mechanics mechanics, IList<Affector> manager) : base(mechanics)
    {
        // и каким образом _mechanics тут сокрыто
        // короче моногейм моументс
        _mechanicsVelocityPoller = mechanicsVelocityPoller;
    }
}