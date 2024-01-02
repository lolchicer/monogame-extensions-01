using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class Linking : Affector
{
    private Vector2 _linkVelocity;
    private LinkingFactory _linkingFactory;
    private const int _initialDelay = 2;
    private int _delay = _initialDelay;

    private void Accelerate()
    {
        _velocity = _linkVelocity * _initialDelay;
    }

    protected override void UpdateVelocity(GameTime gameTime)
    {
        switch (_delay)
        {
            case > 1:
                _delay--;
                break;
            case 1:
                _delay--;
                Accelerate();
                break;
            case 0:
                Accelerate();
                _velocity = -_velocity;
                _linkingFactory.Remove(this);
                break;
            default:
                break;
        }
    }

    public Vector2 LinkVelocity => _linkVelocity;

    public Linking(Vector2 velocity, Mechanics mechanics, LinkingFactory linkingFactory)
    : base(mechanics)
    {
        _linkVelocity = velocity;
        _linkingFactory = linkingFactory;
    }
}