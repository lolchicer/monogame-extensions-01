using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class Friction : Affector
{
    private const float _speed = 2;
    private List<Linking> _linkings = new();

    protected override void UpdateVelocity(GameTime gameTime)
    {
        foreach (var linking in _linkings)
        {
            linking.Update(gameTime);
            _linkings.Remove(linking);
        }

        if (_mechanics.Velocity.Length() == 0)
            return;
        else
        {
            var normalizedVelocity = _mechanics.Velocity;
            normalizedVelocity.Normalize();
            _velocity = -normalizedVelocity * _speed;

            if (_mechanics.Velocity.Length() - _speed <= 0)
                _linkings.Add(new Linking(-(_mechanics.Velocity - _velocity), _mechanics));
        }
    }

    public Friction(Mechanics mechanics) : base(mechanics) { }
}