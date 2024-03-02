using System;
using System.Linq;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class Health : GameComponent
{
    private Entity _user;

    public int Value { get; set; }

    public override void Update(GameTime gameTime)
    {
        if (Value <= 0)
            throw new NotImplementedException();

        base.Update(gameTime);
    }

    public Health(Entity user)
    : base(user.Game)
    {
        _user = user;
    }
}
