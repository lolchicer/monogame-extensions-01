using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class Mechanics : GameComponent
{
    private IList<Affector> _affectors = new List<Affector>();
    private History _history;
    private SteppedQueue _queue = new();
    
    public Vector2 Velocity { get; set; } = new() { X = 0, Y = 0 };
    public Vector2 Position { get; set; } = new() { X = 0, Y = 0 };

    public IList<Affector> Affectors => _affectors;
    public SteppedQueue Queue => _queue;

    public override void Update(GameTime gameTime)
    {
        foreach (var affector in _affectors)
            affector.Update(gameTime);

        _history.Add(() => _queue.Do());
        _history.Add(Move.Value(this, Velocity));

        base.Update(gameTime);
    }

    public Mechanics(Level level) : base(level.Game)
    {
        _history = level.History;
    }
}
