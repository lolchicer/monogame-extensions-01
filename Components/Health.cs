using System;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class Health : GameComponent
{
    private int _value;
    
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

    public int Value
    {
        get => _value;
        set => Damage/* ладно */?.Invoke(value);
    }

    public Health(Game game, GlobalEvents globalEvents)
    : base(game)
    {
        Damage += DamageBody;
        Damage += globalEvents.Damage1;
        Damage += Die;
    }
}
