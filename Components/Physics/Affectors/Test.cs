using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class Test : Affector
{
    private bool _a = true;

    protected override void UpdateVelocity(GameTime gameTime)
    {
        if (_a)
        {
            _velocity = new() { X = 6.0f, Y = 0 };
            _a = false;
        }
    }

    public Test(Mechanics mechanics) : base(mechanics) { }
}
