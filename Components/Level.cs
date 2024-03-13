using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class Level : DrawableGameComponent
{
    private Queue _history = new();
    private Player _player;

    public Queue History => _history;

    public Player Player => _player;
    public List<Entity> Entities { get; } = new();
    public List<Projectile> Projectiles { get; } = new();

    public CollisionMeta CollisionMeta { get; } = new();

    protected IEnumerable<IUpdateable> Updateables()
    {
        var value = new IUpdateable[Entities.Count + Projectiles.Count];
        Array.Copy(Entities.ToArray(), 0, value, Projectiles.Count, Entities.Count);
        Array.Copy(Projectiles.ToArray(), value, Projectiles.Count);
        return value;
    }

    protected IEnumerable<IDrawable> Drawables() =>
    Entities.ToArray();

    public override void Update(GameTime gameTime)
    {
        Player.Update(gameTime);
        foreach (var updateable in Updateables())
            updateable.Update(gameTime);
        _history.Do();

        base.Update(gameTime);
    }

    public override void Draw(GameTime gameTime)
    {
        foreach (var drawable in Drawables())
            drawable.Draw(gameTime);

        base.Draw(gameTime);
    }

    public Level(Game game) : base(game)
    {
        _player = new Player(this);
    }
}
