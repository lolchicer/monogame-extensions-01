using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonogameTest01;

public class DropkickProjectile : Projectile
{
    private int _duration = 3;
    protected override bool Alive
    {
        get
        {
            _duration--;
            return _duration > 0;
        }
    }
    public override Rectangle Hitbox =>
    new(_user.Position.ToPoint(), new(32, 96));
    public override void Action(GameTime gameTime)
    {
        throw new System.NotImplementedException();
    }

    public DropkickProjectile(Entity user, Level level)
    : base(user, level) { }
}
