using System;
using System.Linq;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class Health : GameComponent
{
    private int _value;
    private Entity _user;
    
    private event Action<int> Damage;
    private void DamageBody(int health)
    {
        _value = health;
    }
    private void Die(int health)
    {
        if (health <= 0)
            throw new NotImplementedException();
    }
    private void UseExpose(int health)
    {
        if (_user.Effects.Value.Any(effect => effect is Expose))
            throw new NotImplementedException();
    }

    public int Value
    {
        get => _value;
        set => Damage/* ладно */?.Invoke(value);
    }

    public Health(Entity user, Game game, GlobalEvents globalEvents)
    : base(game)
    {
        _user = user;
        Damage += DamageBody;
        Damage += globalEvents.Damage1;
        Damage += Die;
        Damage += UseExpose;
    }
}
