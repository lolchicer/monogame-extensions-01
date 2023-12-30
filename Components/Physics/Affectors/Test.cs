using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class Test : Affector
{
    private bool _a = true;

    protected override void UpdateVelocity(GameTime gameTime)
    {
        if (_a)
        {
            _velocity = new() { X = 2.0f, Y = 0 };
            _a = false;
        }
        else
            _velocity = Vector2.Zero;
    }

    public Test(Mechanics mechanics) : base(mechanics) { }
}
