using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public abstract class Linking : ThirdAffector
{
    private IEnumerable<LinkingComponent> _components;

    private IList<LinkingComponent> Triggered() =>
    new List<LinkingComponent>(
        from linker in _components
        where linker.Triggered()
        select linker);

    private bool Unlinked() =>
    Triggered().Count > 0;

    private LinkingComponent First() =>
    Triggered().First(
        linker1 =>
        linker1.Velocity.Length() ==
        (
            from linker2 in Triggered()
            select linker2.Velocity.Length())
            .Max());

    private void UpdateLocalVelocity(LinkingComponent component, GameTime gameTime)
    => _velocity += component.Velocity;

    private void UpdateComponent(LinkingComponent component, GameTime gameTime)
    => component.Update(gameTime);

    protected override void UpdateVelocity(GameTime gameTime)
    {
        while (Unlinked())
        {
            var first = First();
            UpdateComponent(first, gameTime);
            UpdateLocalVelocity(first, gameTime);
        }
    }

    public Linking(Mechanics mechanics, IEnumerable<LinkingComponent> components)
    : base(mechanics)
    {
        _components = components;
    }
}
