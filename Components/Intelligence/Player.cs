using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MonogameTest01;

public class Player : GameComponent
{
    public List<Input> Inputs { get; } = new();
    public List<Spells> SpellsCollections { get; } = new();

    // стоит ли писать мне в этом названии Input 🤔
    private void SetDirections()
    {
        var keyboadrdState = Keyboard.GetState();

        var directions = new List<Input.Direction>();

        if (keyboadrdState.IsKeyDown(Keys.A))
            directions.Add(Input.Direction.Left);
        if (keyboadrdState.IsKeyDown(Keys.D))
            directions.Add(Input.Direction.Right);

        Inputs.ForEach(input => input.Directions.AddRange(directions));
    }

    private void SetActivated(Spells spells)
    {
        var keyboadrdState = Keyboard.GetState();

        var activated = new List<Spell>();
        foreach (var spell in spells.Value)
            if (keyboadrdState.IsKeyDown(spell.Key))
                activated.Add(spell);
        
        spells.Activated = activated;
    }

    private void SetActivated()
    {
        foreach (var spells in SpellsCollections)
            SetActivated(spells);
    }

    public override void Update(GameTime gameTime)
    {
        SetDirections();
        SetActivated();

        base.Update(gameTime);
    }

    public Player(Game game) : base(game) { }
}