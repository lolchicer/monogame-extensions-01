using Microsoft.Xna.Framework;

namespace MonogameTest01;

public interface ILinkingAffector
{
    public bool Linking { get;}
    public Vector2 DestinatedVelocity { get; }
}
