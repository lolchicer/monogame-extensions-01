using System.Linq;

namespace MonogameTest01;

public static class HitExtensions
{
    public static bool Hit(this Entity @this, Projectile value) =>
    value.Hitbox.Contains(@this.Position) && value.User != @this;

    public static bool Hit(this Entity @this, Level value) =>
    value.Projectiles.Any(projectile => @this.Hit(projectile));
}
