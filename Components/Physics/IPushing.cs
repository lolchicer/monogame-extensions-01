using Microsoft.Xna.Framework;

namespace MonogameTest01;

public interface IPushing
{
    public Vector2 Normal(Vector2 vector, Vector2 velocity);
}
