using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class Spells : GameComponent
{
    public IList<Spell> Value { get; } = new List<Spell>();
    public IList<Spell> Activated { get; set; } = new List<Spell>();

    public override void Update(GameTime gameTime)
    {
        foreach (var item in Activated)
            item.Use(gameTime);

        Activated.Clear();
        
        base.Update(gameTime);
    }

    public Spells(Game game)
    : base(game) { }
}
