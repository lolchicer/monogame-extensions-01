using System.Linq;

namespace MonogameTest01;

public static class HitExtensions
{
    public static bool Hit(this Entity value1, Projectile value2) =>
    value2.Hitbox.Contains(value1.Position) && value2.User != value1;

    public static bool Hit(this Entity value1, Level value2) =>
    value2.Projectiles.Any(projectile => value1.Hit(projectile));
}
