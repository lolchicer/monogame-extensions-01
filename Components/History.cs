using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class History : GameComponent
{
    private IList<Action> _actions = new List<Action>();
    private void Do()
    {
        foreach (var action in _actions)
            action();
    }

    public void Add(Action value) =>
    _actions.Add(value);

    public override void Update(GameTime gameTime)
    {
        Do();
        _actions.Clear();
    }

    public History(Game game)
    : base(game) { }
}
