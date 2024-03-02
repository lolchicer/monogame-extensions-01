namespace MonogameTest01;

public class SummonProjectile : ICommand
{
    private Level _level;
    private Projectile _projectile;

    public void Do()
    {
        _level.Projectiles.Add(_projectile);
    }

    public void Undo()
    {
        _level.Projectiles.Remove(_projectile);
    }

    public SummonProjectile(Level level, Projectile projectile)
    {
        _level = level;
        _projectile = projectile;
    }
}
