using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class Accelerate : IQueued
{
    private Mechanics _mechanics;
    private Vector2 _value;
    private IQueue.Position _position;

    public IQueue.Position Position => _position;

    public void Do()
    {
        _mechanics.Velocity += _value;
    }

    public void Undo()
    {
        _mechanics.Velocity -= _value;
    }

    public Accelerate(Mechanics mechanics, Vector2 value, IQueue.Position position)
    {
        _mechanics = mechanics;
        _value = value;
        _position = position;
    }
}
