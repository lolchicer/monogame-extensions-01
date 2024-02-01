using Microsoft.Xna.Framework;

namespace MonogameTest01;

public abstract class Projectile : GameComponent
{
    protected Entity _user;
    protected Level _level;
    protected abstract bool Alive { get; }
    public abstract Rectangle Hitbox { get; }
    public abstract void Action(GameTime gameTime);
    public override void Update(GameTime gameTime)
    {
        if (Alive)
            foreach (var entity in _level.Entities)
                if (Hitbox.Contains(entity.Mechanics.Position) && entity != _user)
                    Action(gameTime);
        else
            _level.Projectiles.Remove(this);

        base.Update(gameTime);
    }

    public Projectile(Entity user, Level level)
    : base(level.Game)
    {
        _user = user;
        _level = level;
    }
}
