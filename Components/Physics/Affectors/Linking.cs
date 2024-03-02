using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class Linking : SecondAffector
{
    private IEnumerable<ILinkingComponent> _components;
    private Mechanics _previous;

    private bool Asdf(ILinkingComponent component)
    {
        var initialDifference = (_previous.Velocity - component.Velocity - component.DestinatedVelocity).Length();
        var currentDifference = (_velocity + component.Velocity - component.DestinatedVelocity).Length();
        return currentDifference > initialDifference;
    }

    private IList<ILinkingComponent> Triggered() =>
    new List<ILinkingComponent>(
        from linker in _components
        where Asdf(linker)
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
    => _velocity += component.DestinatedVelocity - _previous.Velocity;

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

    public Linking(IEnumerable<ILinkingComponent> components, Mechanics mechanics)
    : base(mechanics)
    {
        _components = components;
        _previous = mechanics;
    }
}
