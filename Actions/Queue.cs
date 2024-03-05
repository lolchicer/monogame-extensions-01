using System;
using System.Collections.Generic;

namespace MonogameTest01;

public class Queue : IQueue
{
    private IList<Action> _value = new List<Action>();

    public void Add(Action value)
    {
        _value.Add(value);
    }

    public void Do()
    {
        foreach (var action in _value)
            action();
        _value.Clear();
    }
}
