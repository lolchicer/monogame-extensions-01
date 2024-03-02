using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class History : GameComponent
{
    private IList<ICommand> _commands = new List<ICommand>();
    private void Do()
    {
        foreach (var command in _commands)
            command.Do();
    }

    public void Add(ICommand value) =>
    _commands.Add(value);

    public override void Update(GameTime gameTime)
    {
        Do();
        _commands.Clear();
    }

    public History(Game game)
    : base(game) { }
}
