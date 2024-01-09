using Microsoft.Xna.Framework;

namespace MonogameTest01;

// Component от Linking. не от Game.
public abstract class LinkingComponent : GameComponent
{
    protected Vector2 _velocity;
    
    private readonly Linking _linking;

    protected abstract void UpdateVelocity(GameTime gameTime);

    public override void Update(GameTime gameTime)
    {
        _linking.MaxVelocity = _velocity;
    }

    public LinkingComponent(Linking linking, Game game)
    : base(game)
    {
        _linking = linking;
    }
}
