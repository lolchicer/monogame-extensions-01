using Microsoft.Xna.Framework;

namespace MonogameTest01;

public abstract class Affector : GameComponent
{
    private Mechanics _mechanics;

    protected Vector2 _velocity;

    private void Reset()
    {
        _velocity = Vector2.Zero;
    }

    protected abstract void UpdateVelocity(GameTime gameTime);

    protected abstract IQueue.Position QueuePosition { get; }

    public override void Update(GameTime gameTime)
    {
        Reset();
        UpdateVelocity(gameTime);
        _mechanics.Queue.Add(Accelerate.Value(_mechanics, _velocity), QueuePosition);

        base.Update(gameTime);
    }

    public Affector(Mechanics mechanics) : base(mechanics.Game)
    {
        _mechanics = mechanics;
    }
}