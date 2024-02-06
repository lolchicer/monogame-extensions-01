using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace MonogameTest01;

public abstract class Entity : DrawableGameComponent
{
    private Input _input;
    private Level _level;

    public Health Health { get; }
    public Spells Spells { get; }
    public Effects Effects { get; }

    public EntityDrawer EntityDrawer { get; set; }
    public Mechanics Mechanics { get; }
    public Vector2 Position => Mechanics.Position;

    public override void Update(GameTime gameTime)
    {
        Mechanics.Update(gameTime);
        Health.Update(gameTime);
        Spells.Update(gameTime);
        Effects.Update(gameTime);

        base.Update(gameTime);
    }

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void Draw(GameTime gameTime)
    {
        EntityDrawer.Draw(gameTime);

        base.Draw(gameTime);
    }

    public Entity(EntityDrawingConfig drawingConfig, Level level) : base(level.Game)
    {
        _level = level;

        Mechanics = new Mechanics(level.Game);

        _input = new Input(Mechanics);
        var friction = new Friction(Mechanics);

        foreach (var affector in new Affector[] {
            friction,
            _input,
            new Linking(new[] { friction }, Mechanics)
        }) Mechanics.Affectors.Add(affector);
        // _affectors.Add(new Test(mechanics));
        // new Collision(Mechanics, _mechanicsVelocityPoller, _mechanicsPositionPoller, _level.CollisionMeta, new Vector2() { X = 10, Y = 10 }),

        Health = new(this, Game);
        Spells = new(Game);
        Effects = new(Game);

        Spells.Value.Add(new Dropkick(level, this));

        EntityDrawer = new(drawingConfig, Mechanics.PositionPoller, _input, level.Game);
    }

    // побочные эффекты для Player
    public Entity(EntityDrawingConfig drawingConfig, Level level, Player player) : this(drawingConfig, level)
    {
        player.Inputs.Add(_input);
        player.SpellsCollections.Add(Spells);
    }
}
