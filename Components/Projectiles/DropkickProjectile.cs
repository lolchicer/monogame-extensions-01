using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class DropkickProjectile : Projectile
{
    private History _history;
    private int _duration = 3;

    protected override bool Alive => _duration > 0;
    public override Rectangle Hitbox =>
    new(_user.Position.ToPoint(), new(32, 96));

    public override void Update(GameTime gameTime)
    {
        _duration--;

        base.Update(gameTime);
    }

    public override void Action(GameTime gameTime)
    {
        foreach (var entity in _level.Entities)
            if (Hitbox.Contains(entity.Position))
            {
                _history.Add(new Damage(entity.Health, 1));
                _history.Add(new EffectApply(entity.Effects, new Expose(entity, _level, _level.Game)));
            }
    }

    public DropkickProjectile(Entity user, Level level)
    : base(user, level)
    {
        _history = level.History;
    }
}
