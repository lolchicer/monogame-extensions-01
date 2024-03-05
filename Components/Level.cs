using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class Level : DrawableGameComponent
{
    private History _history = new();
    private Player _player;

    public History History => _history;
    
    public Player Player => _player;
    public List<Projectile> Projectiles { get; } = new();
    public List<Entity> Entities { get; } = new();
    
    protected IEnumerable<IUpdateable> Updateables()
    {
        var value = new IUpdateable[Projectiles.Count + Entities.Count];
        Array.Copy(Projectiles.ToArray(), value, Projectiles.Count);
        Array.Copy(Entities.ToArray(), 0, value, Projectiles.Count, Entities.Count);
        return value;
    }

    protected IEnumerable<IDrawable> Drawables() =>
    Entities.ToArray();

    public override void Update(GameTime gameTime)
    {
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
