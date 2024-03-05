using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class Expose : LevelComponent
{
    private Entity _user;

    public override void Update(GameTime gameTime)
    {
        if (_user.Hit(Level))
            Level.History.Add(Death.Value());

        base.Update(gameTime);
    }

    public Expose(Entity user, Level level)
    : base(level)
    {
        _user = user;
    }
}
