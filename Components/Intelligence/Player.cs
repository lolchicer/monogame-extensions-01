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

        var directions = new List<Input.Direction>();

        if (keyboadrdState.IsKeyDown(Keys.A))
            directions.Add(Input.Direction.Left);
        if (keyboadrdState.IsKeyDown(Keys.D))
            directions.Add(Input.Direction.Right);
        if (keyboadrdState.IsKeyDown(Keys.W))
            directions.Add(Input.Direction.Up);
        if (keyboadrdState.IsKeyDown(Keys.S))
            directions.Add(Input.Direction.Down);

        value.Directions.AddRange(directions);
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
