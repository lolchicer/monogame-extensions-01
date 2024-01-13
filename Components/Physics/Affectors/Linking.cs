using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public abstract class Linking : ThirdAffector
{
    private Vector2 ComponentVelocity(ILinkingComponent component)
    => component.DestinatedVelocity - Velocity;

    private IEnumerable<ILinkingComponent> _components;

    private IList<ILinkingComponent> Triggered() =>
    new List<ILinkingComponent>(
        from linker in _components
        where linker.Linking
        select linker);

    private ILinkingComponent First() =>
    Triggered().First(
        linker1 =>
        ComponentVelocity(linker1).Length() ==
        (
            from linker2 in Triggered()
            select ComponentVelocity(linker2).Length())
            .Max());

    private void UpdateVelocity(ILinkingComponent component, GameTime gameTime)
    => _velocity += ComponentVelocity(component);

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

    public Linking(Mechanics mechanics, IEnumerable<ILinkingComponent> components)
    : base(mechanics)
    {
        _components = components;
    }
}
