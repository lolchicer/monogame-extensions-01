using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class Friction : Affector
{
    private const float _speed = 3;
    // возможно лишнее свойство
    private Vector2 StartVelocity
    {
        get
        {
            var linkingsVelocitiesSum = _mechanicsVelocityPoller.Velocity;
            foreach (var linking in _affectingLinkings)
                linkingsVelocitiesSum += linking.LinkVelocity;
            return linkingsVelocitiesSum;
        }
    }
    private MechanicsVelocityPoller _mechanicsVelocityPoller;
    private LinkingFactory _linkingFactory;
    private List<Linking> _linkings = new();
    private List<Linking> _affectingLinkings = new();

    private void Compensate()
    {
        _linkings.Add(_linkingFactory.New(-(_velocity + StartVelocity)));
    }

    protected override void UpdateVelocity(GameTime gameTime)
    {
        foreach (var linking in _linkings.ToArray())
        {
            linking.Update(gameTime);
            _linkings.Remove(linking);
            _affectingLinkings.Add(linking);
        }

        if (StartVelocity != Vector2.Zero)
        {
            var normalizedVelocity = StartVelocity;
            normalizedVelocity.Normalize();
            _velocity = (-normalizedVelocity) * _speed;

            if (StartVelocity.Length() - _speed <= 0)
                Compensate();
        }

        _affectingLinkings.Clear();
    }

    public Friction(MechanicsVelocityPoller mechanicsVelocityPoller, Mechanics mechanics) : base(mechanics)
    {
        // и каким образом _mechanics тут сокрыто
        // короче моногейм моументс
        _mechanicsVelocityPoller = mechanicsVelocityPoller;
        _linkingFactory = new(mechanics);
    }
}