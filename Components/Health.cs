using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class Health : GameComponent
{
    public int Value { get; set; }

    public Health(Game game)
    : base(game) { }
}
