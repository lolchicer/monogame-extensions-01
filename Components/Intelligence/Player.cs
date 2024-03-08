using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace MonogameTest01;

public class Player : LevelComponent
{
    public List<Input> Inputs { get; } = new();
    public List<Spells> SpellsCollections { get; } = new();

    private void SetDirections(Input value)
    {
        var keyboadrdState = Keyboard.GetState();
        var directions = new Directions.Twodimensional.Quad();

        if (keyboadrdState.IsKeyDown(Keys.A))
            directions.Leftwards = true;
        if (keyboadrdState.IsKeyDown(Keys.W))
            directions.Upwards = true;
        if (keyboadrdState.IsKeyDown(Keys.D))
            directions.Rightwards = true;
        if (keyboadrdState.IsKeyDown(Keys.S))
            directions.Downwards = true;

        value.Directions = directions;
    }

    // стоит ли писать мне в этом названии Input 🤔
    private void SetDirections()
    {
        foreach (var input in Inputs)
            SetDirections(input);
    }

    private void SetActivated(Spells value)
    {
        var keyboadrdState = Keyboard.GetState();

        foreach (var item in value.Value)
            if (keyboadrdState.IsKeyDown(item.Key))
                value.Activated.Add(item);
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

    public Player(Level level)
    : base(level) { }
}
