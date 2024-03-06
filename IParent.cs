using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public interface IParent
{
    public IEnumerable<IUpdateable> Updateables { get; }
    public IEnumerable<IDrawable> Drawables { get; }
    public IEnumerable<IParent> Parents { get; }
}
