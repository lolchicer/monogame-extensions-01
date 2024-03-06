using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class Level : DrawableGameComponent
{
    private Queue _history = new();
    private Player _player;

    public Queue History => _history;

    public Player Player => _player;
    public IList<Projectile> Projectiles { get; } = new List<Projectile>();
    public IList<Entity> Entities { get; } = new List<Entity>();

    protected IEnumerable<IUpdateable> Updateables
    {
        get
        {
            var value = new IUpdateable[Projectiles.Count + Entities.Count];
            Array.Copy(Projectiles.ToArray(), value, Projectiles.Count);
            Array.Copy(Entities.ToArray(), 0, value, Projectiles.Count, Entities.Count);
            return value;
        }
    }
    protected IEnumerable<IDrawable> Drawables =>
    Entities.ToArray();
    protected IEnumerable<IParent> Parents
    {
        get
        {
            var value = new IParent[Projectiles.Count + Entities.Count];
            Array.Copy(Projectiles.ToArray(), value, Projectiles.Count);
            Array.Copy(Entities.ToArray(), 0, value, Projectiles.Count, Entities.Count);
            return value;
        }
    }

    public override void Update(GameTime gameTime)
    {
        foreach (var updateable in Updateables)
            updateable.Update(gameTime);
        _history.Do();

        base.Update(gameTime);
    }

    public override void Draw(GameTime gameTime)
    {
        foreach (var drawable in Drawables)
            drawable.Draw(gameTime);

        base.Draw(gameTime);
    }

    public Level(Game game) : base(game)
    {
        _player = new Player(this);
    }
}
