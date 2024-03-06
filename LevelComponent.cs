using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public abstract class LevelComponent : GameComponent, IParent
{
    private Level _level;

    public Level Level => _level;

    public abstract IEnumerable<IUpdateable> Updateables { get; }
    public abstract IEnumerable<IDrawable> Drawables { get; }
    public abstract IEnumerable<IParent> Parents { get; }

    public LevelComponent(Level level)
    : base(level.Game)
    {
        _level = level;
    }
}
