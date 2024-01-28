using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameTest01;

public enum SpriteState
{
    Idle,
    Walking
}

public enum SpriteDirection
{
    Left,
    Right
}

public class EntityDrawer : DrawableGameComponent
{
    private SpriteDirection _spriteDirection = MonogameTest01.SpriteDirection.Left;
    private EntityDrawingConfig _config;
    private MechanicsPositionPoller _mechanicsPositionPoller;
    private Input _input;
    
    // _
    private SpriteState SpriteState()
    {
        // я когда-нибудь получу по башне за поиск свойств в коллекциях
        if (_input.Velocity != new Vector2() { X = 0, Y = 0 })
            return MonogameTest01.SpriteState.Walking;
        return MonogameTest01.SpriteState.Idle;
    }

    // чё ваще
    // _spriteDirection оставлен перезаписываться
    protected SpriteDirection SpriteDirection()
    {
        _spriteDirection = _input.Velocity.X switch
        {
            < 0 => MonogameTest01.SpriteDirection.Left,
            > 0 => MonogameTest01.SpriteDirection.Right,
            _ => _spriteDirection
        };
        return _spriteDirection;
    }

    public EntityDrawingConfig Config => _config;
    public SpriteBatch SpriteBatch { get; set; }
    public Texture2D IdleTexture { get; set; }
    public IAnimation SprintingTexture { get; set; }

    public Texture2D Texture(GameTime gameTime) =>
    SpriteState() switch
    {
        MonogameTest01.SpriteState.Walking =>
        SprintingTexture.GetCurrentTexture(gameTime),
        _ => IdleTexture
    };

    public override void Draw(GameTime gameTime)
    {
        SpriteBatch.Begin();
        var texture = Texture(gameTime);

        switch (SpriteDirection())
        {
            case MonogameTest01.SpriteDirection.Left:
                SpriteBatch.Draw(texture, _mechanicsPositionPoller.Position, null, Color.White, 0,
                new() { X = 0, Y = 0 }, 1, SpriteEffects.FlipHorizontally, 1);
                break;
            default:
                SpriteBatch.Draw(texture, _mechanicsPositionPoller.Position, Color.White);
                break;
        }

        SpriteBatch.End();

        base.Draw(gameTime);
    }

    public EntityDrawer(EntityDrawingConfig config, MechanicsPositionPoller mechanicsPositionPoller, Input input, Game game) : base(game)
    {
        _config = config;
        _mechanicsPositionPoller = mechanicsPositionPoller;
        _input = input;
    }
}
