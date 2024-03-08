using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class Friction : FirstAffector, ILinkingComponent
{
    private const float _speed = 3.0f;
    // возможно лишнее свойство
    private Mechanics _mechanics;
    private Vector2 _linkingComponentVelocity;
    private Vector2 StartVelocity => _mechanics.Velocity;

    protected override void UpdateVelocity(GameTime gameTime)
    {
        if (StartVelocity != Vector2.Zero)
        {
            var normalizedVelocity = StartVelocity;
            normalizedVelocity.Normalize();
            _velocity = (-normalizedVelocity) * _speed;
        }
        
        _linkingComponentVelocity = _velocity;
    }
    // инстанц потребуется в дальнейшем
    public Vector2 DestinatedVelocity => Vector2.Zero;
    // прапрекрывапр
    public Vector2 Velocity => _linkingComponentVelocity;

    public Friction(Mechanics mechanics) : base(mechanics)
    {
        // и каким образом _mechanics тут сокрыто
        // короче моногейм моументс
        _mechanics = mechanics;
        _linkingComponentVelocity = _velocity;
    }
}