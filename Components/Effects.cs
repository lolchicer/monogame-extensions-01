using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class Effects : GameComponent
{
    public IList<GameComponent> Value { get; } = new List<GameComponent>();

    public override void Update(GameTime gameTime)
    {
        foreach (var item in Value)
            item.Update(gameTime);

        base.Update(gameTime);
    }

    public Effects(Game game)
    : base(game) { }
}
