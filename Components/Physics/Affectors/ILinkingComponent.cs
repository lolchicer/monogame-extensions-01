using Microsoft.Xna.Framework;

namespace MonogameTest01;

public interface ILinkingComponent
{
    public Vector2 DestinatedVelocity { get; }
    public bool Linking { get; }
}
