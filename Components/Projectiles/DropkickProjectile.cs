using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class DropkickProjectile : Projectile
{
    private int _duration = 3;

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        Level.History.Add(
            () =>
            {
                _duration--;
                Check();
            });
    }

    protected override bool Alive => _duration > 0;
    protected override void Action(GameTime gameTime)
    {
        foreach (var entity in Level.Entities)
            if (Hitbox.Contains(entity.Position))
            {
                Level.History.Add(Damage.Value(entity.Health, 1));
                Level.History.Add(EffectApply.Value(entity.Effects, new Expose(entity, Level)));
            }
    }

    public override Rectangle Hitbox =>
    new(User.Position.ToPoint(), new(32, 96));

    public DropkickProjectile(Entity user)
    : base(user) { }
}
