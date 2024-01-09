using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public abstract class Linking : ThirdAffector
{
    private IEnumerable<LinkingComponent> _components;
    private Vector2 _maxVelocity;

    public Vector2 MaxVelocity
    {
        set
        {
            if (Math.Abs(value.X) > Math.Abs(_maxVelocity.X))
                _maxVelocity.X = value.X;
            if (Math.Abs(value.Y) > Math.Abs(_maxVelocity.Y))
                _maxVelocity.Y = value.Y;
        }
    }

    protected override void UpdateVelocity(GameTime gameTime)
    {
        foreach (var component in _components)
            component.Update(gameTime);
        _velocity = _maxVelocity;
    }

    public Linking(Mechanics mechanics, IEnumerable<LinkingComponent> components)
    : base(mechanics)
    {
        _components = components;
    }
}