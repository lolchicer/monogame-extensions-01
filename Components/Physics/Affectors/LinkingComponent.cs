using Microsoft.Xna.Framework;

namespace MonogameTest01;

// Component от Linking. не от Game.
public abstract class LinkingComponent : GameComponent
{
    protected Vector2 _velocity;
    
    private readonly Linking _linking;
    private readonly ILinkingAffector _affector;
    private readonly Mechanics _mechanics;

    public Vector2 Velocity => _velocity;

    public override void Update(GameTime gameTime)
    {
        _mechanics.Velocity += _affector.LinkVelocity;
    }

    public bool Triggered() =>
    _affector.Linking();

    public LinkingComponent(Linking linking, ILinkingAffector affector, Mechanics mechanics)
    : base(mechanics.Game)
    {
        _linking = linking;
        _affector = affector;
        _mechanics = mechanics;
    }
}
