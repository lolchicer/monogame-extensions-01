using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class Mechanics : GameComponent
{
    private IList<Affector> _affectors = new List<Affector>();
    private IList<IQueued> _commands = new List<IQueued>();
    private History _history;
    
    public Vector2 Velocity { get; set; } = new() { X = 0, Y = 0 };
    public Vector2 Position { get; set; } = new() { X = 0, Y = 0 };

    public IList<Affector> Affectors => _affectors;
    public IList<IQueued> Commands => _commands;

    public override void Update(GameTime gameTime)
    {
        foreach (var affector in _affectors)
            affector.Update(gameTime);

        _history.Add(new Queue { Value = _commands.ToArray() });
        _history.Add(new Move(this, Velocity));

        _commands.Clear();

        base.Update(gameTime);
    }

    public Mechanics(History history) : base(history.Game)
    {
        _history = history;
    }
}
