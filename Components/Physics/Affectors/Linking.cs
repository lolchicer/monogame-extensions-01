using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class Linking : ThirdAffector
{
    private IEnumerable<ILinkingComponent> _components;
    private MechanicsVelocityPoller _velocityPoller;

    private IList<ILinkingComponent> Triggered() =>
    new List<ILinkingComponent>(
        from linker in _components
        where linker.Linking(_velocity)
        select linker);

    private ILinkingComponent First() =>
    Triggered().First(
        linker1 =>
        linker1.DestinatedVelocity.Length() ==
        (
            from linker2 in Triggered()
            select linker2.DestinatedVelocity.Length())
            .Max());

    private void UpdateVelocity(ILinkingComponent component, GameTime gameTime)
    => _velocity += component.DestinatedVelocity - _velocityPoller.Velocity;

    private bool Unlinked() =>
    Triggered().Count > 0;

    protected override void UpdateVelocity(GameTime gameTime)
    {
        while (Unlinked())
        {
            var first = First();
            UpdateVelocity(first, gameTime);
        }
    }

    public Linking(MechanicsVelocityPoller velocityPoller, Mechanics mechanics, IEnumerable<ILinkingComponent> components)
    : base(mechanics)
    {
        _components = components;
        _velocityPoller = velocityPoller;
    }
}
