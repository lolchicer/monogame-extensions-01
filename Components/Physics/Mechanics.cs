using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class Mechanics : LevelComponent, IPushing
{
    private IList<Affector> _affectors = new List<Affector>();
    private Queue _history;
    private SteppedQueue _queue = new();
    
    public Vector2 Velocity { get; set; } = new() { X = 0, Y = 0 };
    public Vector2 Position { get; set; } = new() { X = 0, Y = 0 };
    public Vector2 Hitbox { get; set; } = new() { X = 0, Y = 0 };

    public IList<Affector> Affectors => _affectors;
    public SteppedQueue Queue => _queue;

    public override void Update(GameTime gameTime)
    {
        foreach (var affector in _affectors)
            affector.Update(gameTime);

        _history.Add(() => _queue.Do());
        _history.Add(() => Position += Velocity);

        base.Update(gameTime);
    }

    public Vector2 Normal(Vector2 vector, Vector2 velocity) =>
    new SurfaceQuad(Position, Hitbox).Normal(vector, velocity);

    public Mechanics(Level level)
    : base(level)
    {
        _history = level.History;
    }
}
