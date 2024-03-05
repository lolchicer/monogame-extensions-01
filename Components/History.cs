using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class History
{
    private IList<Action> _actions = new List<Action>();
    
    public void Add(Action value) =>
    _actions.Add(value);

    public void Do()
    {
        foreach (var action in _actions)
            action();
        _actions.Clear();
    }

    public History() { }
}
