using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class LevelComponent : GameComponent
{
    private Level _level;

    public Level Level => _level;

    public LevelComponent(Level level)
    : base(level.Game)
    {
        _level = level;
    }
}
