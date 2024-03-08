using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class Linking : SecondAffector
{
    private IEnumerable<ILinkingComponent> _components;
    private Mechanics _mechanics;

    private bool Triggered(ILinkingComponent component)
    {
        // считается скалярная разница от component.DestinatedVelocity
        var initialVelocity = (
            // скорость тела перед торможением
            _mechanics.Velocity - component.DestinatedVelocity).Length();
        var counteringVelocity = (
            // скорость для торможения тела вместе со скоростью спряжения
            _velocity + component.Velocity - component.DestinatedVelocity).Length();
        return counteringVelocity > initialVelocity;
    }

    private IList<ILinkingComponent> Triggered() =>
    new List<ILinkingComponent>(
        from linker in _components
        where Triggered(linker)
        select linker);

    private void UpdateVelocity(ILinkingComponent component)
    => _velocity += component.DestinatedVelocity - _mechanics.Velocity - component.Velocity;

    private bool Unlinked() =>
    Triggered().Count > 0;

    private ILinkingComponent First() =>
    Triggered().First(
        linker1 =>
        linker1.DestinatedVelocity.Length() ==
        (
            from linker2 in Triggered()
            select linker2.DestinatedVelocity.Length())
            .Max());

    protected override void UpdateVelocity(GameTime gameTime)
    {
        while (Unlinked())
            UpdateVelocity(First());
    }

    public Linking(IEnumerable<ILinkingComponent> components, Mechanics mechanics)
    : base(mechanics)
    {
        _components = components;
        _mechanics = mechanics;
    }
}
