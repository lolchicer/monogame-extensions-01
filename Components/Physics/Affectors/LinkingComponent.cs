using Microsoft.Xna.Framework;

namespace MonogameTest01;

// Component от Linking. не от Game.
public abstract class LinkingComponent : GameComponent
{
    private readonly Linking _linking;
    private readonly ILinkingAffector _affector;

    public Vector2 Velocity => _affector.DestinatedVelocity - _linking.Velocity;

    public bool Triggered() =>
    _affector.Linking;

    public LinkingComponent(Linking linking, ILinkingAffector affector, Mechanics mechanics)
    : base(mechanics.Game)
    {
        _linking = linking;
        _affector = affector;
    }
}
