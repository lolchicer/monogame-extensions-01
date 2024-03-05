using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class Level : DrawableGameComponent
{
    private History _history;
    private Player _player;

    public History History => _history;
    public Player Player => _player;
    public List<Projectile> Projectiles { get; } = new();
    public List<ICommand> Commands { get; } = new();
    public List<Entity> Entities { get; } = new();

    public override void Update(GameTime gameTime)
    {
        _player.Update(gameTime);
        foreach (var projectile in Projectiles.ToArray())
            projectile.Update(gameTime);
        Entities.ForEach(entity => entity.Update(gameTime));
        _history.Update(gameTime);

        base.Update(gameTime);
    }

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void Draw(GameTime gameTime)
    {
        Entities.ForEach(entity => entity.Draw(gameTime));

        base.Draw(gameTime);
    }

    public Level(Game game) : base(game)
    {
        _history = new History(game);
        _player = new Player(_history);
    }
}
