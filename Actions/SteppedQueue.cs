using System;

namespace MonogameTest01;

public class SteppedQueue : ISteppedQueue
{
    private (
        Queue First,
        Queue Second,
        Queue Third)
        _value = (
            First: new(),
            Second: new(),
            Third: new());

    public void Add(Action value, ISteppedQueue.Position position)
    {
        switch (position)
        {
            case ISteppedQueue.Position.First:
                _value.First.Add(value);
                break;
            case ISteppedQueue.Position.Second:
                _value.Second.Add(value);
                break;
            case ISteppedQueue.Position.Third:
                _value.Third.Add(value);
                break;
            default:
                break;
        }
    }

    public void Do()
    {
        _value.First.Do();
        _value.Second.Do();
        _value.Third.Do();
    }
}
