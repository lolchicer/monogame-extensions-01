using Microsoft.Xna.Framework;

namespace MonogameTest01;

public interface ILinkingComponent
{
    public Vector2 DestinatedVelocity { get; }
    public Vector2 Velocity { get; }
    public bool Linking(Vector2 linkingVelocity);
}
