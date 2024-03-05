using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonogameTest01;

public class Dropkick : Spell
{
    private Level _level;

    public override Keys Key => Keys.C;

    public override void Use(GameTime gameTime)
    {
        _level.History.Add(
            SummonProjectile.Value(
                _level,
                new DropkickProjectile(User, _level)));
    }

    public Dropkick(Level level, Entity user)
    : base(user)
    {
        _level = level;
    }
}
