using Microsoft.Xna.Framework;

namespace MonogameTest01;

public interface IAffectorShiftPoller
{
    public Vector2 Velocity { get; }
    public Vector2 Position { get; }
    public Vector2 DestinatedVelocity { get; }

    public bool Triggered(Vector2 velocity) =>
    Position - Velocity == DestinatedVelocity - Velocity;
}
