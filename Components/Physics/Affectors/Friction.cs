using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class Friction : FirstAffector, ILinkingComponent
{
    private const float _speed = 3.0f;
    // возможно лишнее свойство
    private Vector2 StartVelocity => _mechanicsVelocityPoller.Velocity;
    private MechanicsVelocityPoller _mechanicsVelocityPoller;

    protected override void UpdateVelocity(GameTime gameTime)
    {
        if (_mechanics.Velocity != Vector2.Zero)
        {
            var normalizedVelocity = _mechanics.Velocity;
            normalizedVelocity.Normalize();
            _velocity = (-normalizedVelocity) * _speed;
        }
    }

    public bool Linking
    {
        get
        {
            var initialDifference = _mechanicsVelocityPoller.Velocity - _velocity - DestinatedVelocity;
            var currentDifference = _mechanicsVelocityPoller.Velocity - DestinatedVelocity;
            initialDifference.Normalize();
            currentDifference.Normalize();
            return currentDifference == -initialDifference;
        }
    }
    // инстанц потребуется в дальнейшем
    public Vector2 DestinatedVelocity => Vector2.Zero;

    public Friction(MechanicsVelocityPoller mechanicsVelocityPoller, Mechanics mechanics, IList<Affector> manager) : base(mechanics)
    {
        // и каким образом _mechanics тут сокрыто
        // короче моногейм моументс
        _mechanicsVelocityPoller = mechanicsVelocityPoller;
    }
}