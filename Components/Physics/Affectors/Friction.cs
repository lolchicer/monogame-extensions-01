using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class Friction : Affector
{
    private const float _speed = 3.0f;
    // возможно лишнее свойство
    private Vector2 StartVelocity => _mechanicsVelocityPoller.Velocity + _linkingFactory.LinkVelocity;
    private MechanicsVelocityPoller _mechanicsVelocityPoller;
    private LinkingFactory _linkingFactory;

    private void Compensate()
    {
        _linkingFactory.AddNew(-(_velocity + StartVelocity));
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

    public Friction(MechanicsVelocityPoller mechanicsVelocityPoller, Mechanics mechanics, IList<Affector> manager) : base(mechanics)
    {
        // и каким образом _mechanics тут сокрыто
        // короче моногейм моументс
        _mechanicsVelocityPoller = mechanicsVelocityPoller;
        _linkingFactory = new(mechanics, manager);
    }
}