using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class Mechanics : GameComponent
{
    private IList<Affector> _affectors = new List<Affector>();
    private AffectorsQueue _affectorsQueue;
    private MechanicsPositionPoller _positionPoller;
    private MechanicsVelocityPoller _velocityPoller;

    public Vector2 Velocity { get; set; } = new() { X = 0, Y = 0 };
    public Vector2 Position { get; set; } = new() { X = 0, Y = 0 };

    public IList<Affector> Affectors => _affectors;
    public MechanicsPositionPoller PositionPoller => _positionPoller;
    public MechanicsVelocityPoller VelocityPoller => _velocityPoller;

    public override void Update(GameTime gameTime)
    {
        _affectorsQueue.Update(gameTime);
        Position += Velocity;

        base.Update(gameTime);
    }

    public Mechanics(Game game) : base(game)
    {
        _affectorsQueue = new(
            Affectors,
            new MechanicsPositionPoller(this),
            new MechanicsVelocityPoller(this));
    }
}