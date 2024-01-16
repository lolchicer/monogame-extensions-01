using System;
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
        if (StartVelocity != Vector2.Zero)
        {
            var normalizedVelocity = StartVelocity;
            normalizedVelocity.Normalize();
            _velocity = (-normalizedVelocity) * _speed;
        }
    }

    public bool Linking(Vector2 linkingVelocity)
    {
        var initialDifference = -(_mechanicsVelocityPoller.Velocity - _velocity - DestinatedVelocity);
        var currentDifference = _mechanicsVelocityPoller.Velocity + linkingVelocity - DestinatedVelocity;
        if (initialDifference == Vector2.Zero || currentDifference == Vector2.Zero)
            return false;
        else
        {
            initialDifference.Normalize();
            currentDifference.Normalize();
            // рпавгонеквопра
            var initialDifferenceRounded = new Vector2(Math.Sign(initialDifference.X), Math.Sign(initialDifference.Y));
            var currentDifferenceRounded = new Vector2(Math.Sign(currentDifference.X), Math.Sign(currentDifference.Y));
            return currentDifferenceRounded == initialDifferenceRounded;
        }
    }
    // инстанц потребуется в дальнейшем
    public Vector2 DestinatedVelocity => Vector2.Zero;
    // прапрекрывапр
    public new Vector2 Velocity => _velocity;

    public Friction(MechanicsVelocityPoller mechanicsVelocityPoller, Mechanics mechanics) : base(mechanics)
    {
        // и каким образом _mechanics тут сокрыто
        // короче моногейм моументс
        _mechanicsVelocityPoller = mechanicsVelocityPoller;
    }
}