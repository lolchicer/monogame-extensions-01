using Microsoft.Xna.Framework;

namespace MonogameTest01;

// желательно избавиться от этого класса
public class MechanicsPositionPoller : GameComponent
{
    private Mechanics _mechanics;
    private Vector2 _position;

    public override void Update(GameTime gameTime)
    {
        _position = _mechanics.Position;
    }

    public Vector2 Position => _position;

    public MechanicsPositionPoller(Mechanics mechanics)
    : base(mechanics.Game)
    {
        _mechanics = mechanics;
        // не знаю правильно ли это
        _position = mechanics.Velocity;
    }
}
