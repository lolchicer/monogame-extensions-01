using Microsoft.Xna.Framework;

namespace MonogameTest01;

public abstract class Entity : DrawableGameComponent
{
    private Level _level;
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

    public override void Draw(GameTime gameTime)
    {
        _drawer.Draw(gameTime);

        base.Draw(gameTime);
    }

    public Entity(Level level) : base(level.Game)
    {
        _level = level;

        Mechanics = new Mechanics(_level);

        _input = new Input(Mechanics);
        var friction = new Friction(Mechanics, _level);

        foreach (var affector in new Affector[] {
            _input,
            friction,
            new Linking(new[] { friction }, Mechanics)
        }) Mechanics.Affectors.Add(affector);
        // _affectors.Add(new Test(mechanics));
        // new Collision(Mechanics, _mechanicsVelocityPoller, _mechanicsPositionPoller, _level.CollisionMeta, new Vector2() { X = 10, Y = 10 }),

        Health = new(this);
        Spells = new(Game);
        Effects = new(Game);

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
