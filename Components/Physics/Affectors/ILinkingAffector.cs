using Microsoft.Xna.Framework;

namespace MonogameTest01;

public interface ILinkingAffector
{
    public bool Linking();
    public Vector2 LinkVelocity { get; }
}
