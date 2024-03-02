using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class Move : ICommand
{
    private Mechanics _mechanics;
    private Vector2 _value;

    public void Do()
    {
        _mechanics.Position += _value;
    }

    public void Undo()
    {
        _mechanics.Position -= _value;
    }

    public Move(Mechanics mechanics, Vector2 value)
    {
        _mechanics = mechanics;
        _value = value;
    }
}
