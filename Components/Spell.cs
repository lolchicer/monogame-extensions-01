using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonogameTest01;

public abstract class Spell
{
    private int _ammo;
    private Entity _user;
    public int Ammo { get => _ammo; set => _ammo = value; }
    public Entity User => _user;
    public abstract Keys Key { get; }
    public abstract void Use(GameTime gameTime);

    public Spell(Entity user)
    {
        _user = user;
    }
}
