using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameTest01;

public enum SpriteState
{
    Idle,
    Walking
}

public class EntityDrawer : DrawableGameComponent
{
    private Entity _entity;
    private Directions.Onedimensional.Enum _spriteDirection= Directions.Onedimensional.Enum.Leftwards;
    
    private SpriteState SpriteState()
    {
        if (_entity.Input.Velocity != new Vector2() { X = 0, Y = 0 })
            return MonogameTest01.SpriteState.Walking;
        return MonogameTest01.SpriteState.Idle;
    }

    // чё ваще
    protected Directions.Onedimensional.Enum SpriteDirection()
    {
        _spriteDirection = _entity.Input.Velocity.X switch
        {
            < 0 => Directions.Onedimensional.Enum.Leftwards,
            > 0 => Directions.Onedimensional.Enum.Rightwards,
            _ => _spriteDirection
        };
        return _spriteDirection;
    }
    
    public SpriteBatch SpriteBatch { get; set; }
    public Texture2D IdleTexture { get; set; }
    public IAnimation SprintingTexture { get; set; }

    public EntityDrawingConfig Config => _entity.DrawingConfig;

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
            case Directions.Onedimensional.Enum.Leftwards:
                SpriteBatch.Draw(texture, _entity.Position, null, Color.White, 0,
                new() { X = 0, Y = 0 }, 1, SpriteEffects.FlipHorizontally, 1);
                break;
            default:
                SpriteBatch.Draw(texture, _entity.Position, Color.White);
                break;
        }

        SpriteBatch.End();

        base.Draw(gameTime);
    }

    public EntityDrawer(Entity entity) : base(entity.Game)
    {
        _entity = entity;
    }
}
