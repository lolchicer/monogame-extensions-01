using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class LinkingFactory
{
    private Mechanics _mechaincs;
    private IList<Affector> _manager;
    private List<Linking> _linkings = new();

    public void AddNew(Vector2 velocity)
    {
        var value = new Linking(velocity, _mechaincs, this);
        _manager.Add(value);
        _linkings.Add(value);
    }

    public void Remove(Linking value)
    {
        _manager.Remove(value);
        _linkings.Remove(value);
    }

    public Vector2 LinkVelocity
    {
        get
        {
            var sum = Vector2.Zero;
            _linkings.ForEach(value => sum += value.LinkVelocity);
            return sum;
        }
    }

    public LinkingFactory(Mechanics mechanics, IList<Affector> manager)
    {
        _mechaincs = mechanics;
        _manager = manager;
    }
}