using Microsoft.Xna.Framework;

namespace MonogameTest01;

public interface ICommand
{
    public void Do();
    public void Undo();
}
