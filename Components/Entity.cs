using System;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public abstract class Entity : LevelComponent, IDrawable
{
    private Input _input;
    private EntityDrawer _drawer;

    public Mechanics Mechanics { get; }
    public Health Health { get; }
    public Spells Spells { get; }
    public Effects Effects { get; }

    public Input Input => _input;
    public Vector2 Position => Mechanics.Position;
    
    public EntityDrawer Drawer => _drawer;
    public abstract EntityDrawingConfig DrawingConfig { get; }
    
    public override void Update(GameTime gameTime)
    {
        Mechanics.Update(gameTime);
        Health.Update(gameTime);
        Spells.Update(gameTime);
        Effects.Update(gameTime);

        base.Update(gameTime);
    }

    // сомнительно но оукэээй
    public void Draw(GameTime gameTime) 
    => _drawer.Draw(gameTime);
    public int DrawOrder =>
    _drawer.DrawOrder;
    public event EventHandler<EventArgs> DrawOrderChanged
    {
        add => _drawer.DrawOrderChanged += value;
        remove => _drawer.DrawOrderChanged += value;
    }
    public bool Visible =>
    _drawer.Visible;
    public event EventHandler<EventArgs> VisibleChanged
    {
        add => _drawer.VisibleChanged += value;
        remove => _drawer.VisibleChanged += value;
    }

    public Entity(Level level)
    : base(level)
    {
        Mechanics = new(level);

        _input = new Input(Mechanics);
        var friction = new Friction(Mechanics);

        foreach (var affector in new Affector[] {
            _input,
            friction,
            new Linking(new[] { friction }, Mechanics)
        }) Mechanics.Affectors.Add(affector);
        // _affectors.Add(new Test(mechanics));
        // new Collision(Mechanics, _mechanicsVelocityPoller, _mechanicsPositionPoller, _level.CollisionMeta, new Vector2() { X = 10, Y = 10 }),

        Health = new(this);
        Spells = new(level);
        Effects = new(level);

        Spells.Value.Add(new Dropkick(level, this));

        _drawer = new(this);
    }

    // побочные эффекты для Player
    public Entity(Level level, Player player) : this(level)
    {
        player.Inputs.Add(_input);
        player.SpellsCollections.Add(Spells);
    }
}
