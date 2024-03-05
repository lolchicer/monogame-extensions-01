using System;
using System.Collections.Generic;

namespace MonogameTest01;

public class Queue : IQueue
{
    private (
        IList<Action> First,
        IList<Action> Second,
        IList<Action> Third)
        _value = (
            First: new List<Action>(),
            Second: new List<Action>(),
            Third: new List<Action>());

    public void Add(Action value, IQueue.Position position)
    {
        switch (position)
        {
            case IQueue.Position.First:
                _value.First.Add(value);
                break;
            case IQueue.Position.Second:
                _value.Second.Add(value);
                break;
            case IQueue.Position.Third:
                _value.Third.Add(value);
                break;
            default:
                break;
        }
    }

    private void Do(IList<Action> step)
    {
        foreach (var action in step)
            action();
        step.Clear();
    }

    public void Do()
    {
        Do(_value.First);
        Do(_value.Second);
        Do(_value.Third);
    }

    public Queue() { }
}
