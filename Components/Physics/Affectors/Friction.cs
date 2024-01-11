using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class Friction : FirstAffector, ILinkingAffector
{
    private const float _speed = 3.0f;
    private bool _linking = false;
    // возможно лишнее свойство
    private Vector2 StartVelocity => _mechanicsVelocityPoller.Velocity;
    private MechanicsVelocityPoller _mechanicsVelocityPoller;

    private void Compensate()
    {
        _linking = true;
    }

    protected override void UpdateVelocity(GameTime gameTime)
    {
        _linking = false;
        if (_mechanics.Velocity != Vector2.Zero)
        {
            var normalizedVelocity = _mechanics.Velocity;
            normalizedVelocity.Normalize();
            _velocity = (-normalizedVelocity) * _speed;

            if (StartVelocity.Length() - _speed <= 0)
                Compensate();
        }
    }

    public bool Linking => _linking; 

    // инстанц потребуется в дальнейшем
    public Vector2 Limit => Vector2.Zero;

    public Friction(MechanicsVelocityPoller mechanicsVelocityPoller, Mechanics mechanics, IList<Affector> manager) : base(mechanics)
    {
        // и каким образом _mechanics тут сокрыто
        // короче моногейм моументс
        _mechanicsVelocityPoller = mechanicsVelocityPoller;
    }
}