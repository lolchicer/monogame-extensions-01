using System;

namespace MonogameTest01;

public static class SummonProjectile
{
    public static Action Value(Level level, Projectile projectile) =>
    () => level.Projectiles.Add(projectile);
}
