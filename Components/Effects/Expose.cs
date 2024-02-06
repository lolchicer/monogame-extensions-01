using System;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class Expose : GameComponent
{
    private Entity _user;
    private Level _level;

    public override void Update(GameTime gameTime)
    {
        if (_user.Hit(_level))
            throw new NotImplementedException();

        base.Update(gameTime);
    }

    public Expose(Entity user, Level level, Game game)
    : base(game)
    {
        _user = user;
        _level = level;
    }
}
