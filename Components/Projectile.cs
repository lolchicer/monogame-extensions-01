using Microsoft.Xna.Framework;

namespace MonogameTest01;

public abstract class Projectile : LevelComponent
{
    private Entity _user;
    
    protected abstract bool Alive { get; }
    protected abstract void Action(GameTime gameTime);
    public abstract Rectangle Hitbox { get; }

    public Entity User => _user;
    
    public override void Update(GameTime gameTime)
    {
        if (Alive)
            foreach (var entity in Level.Entities)
                if (Hitbox.Contains(entity.Mechanics.Position) && entity != _user)
                    Action(gameTime);
                else { }
        else
            Level.Projectiles.Remove(this);

        base.Update(gameTime);
    }

    public Projectile(Entity user)
    : base(user.Level)
    {
        _user = user;
    }
}
