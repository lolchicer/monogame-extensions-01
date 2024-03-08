using Microsoft.Xna.Framework;

namespace MonogameTest01;

public abstract class Projectile : LevelComponent
{
    private Entity _user;

    protected abstract bool Alive { get; }
    protected abstract void Action(GameTime gameTime);
    public abstract Rectangle Hitbox { get; }

    public Entity User => _user;

    public void Check()
    {
        if (!Alive)
            Level.Projectiles.Remove(this);
    }

    public override void Update(GameTime gameTime)
    {
        foreach (var entity in Level.Entities)
            if (Hitbox.Contains(entity.Mechanics.Position) && entity != _user)
                Action(gameTime);

        base.Update(gameTime);
    }

    public Projectile(Entity user)
    : base(user.Level)
    {
        _user = user;
    }
}
