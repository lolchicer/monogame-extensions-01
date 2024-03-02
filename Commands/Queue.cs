using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class Queue : ICommand, IQueue
{
    private IList<IQueued> _value;

    private (
        IList<IQueued> First,
        IList<IQueued> Second,
        IList<IQueued> Third)
        ValueSorted()
    {
        var value = (
            First: new List<IQueued>(),
            Second: new List<IQueued>(),
            Third: new List<IQueued>());

        foreach (var affector in _value)
            switch (affector.Position)
            {
                case IQueue.Position.First:
                    value.First.Add(affector);
                    break;
                case IQueue.Position.Second:
                    value.Second.Add(affector);
                    break;
                case IQueue.Position.Third:
                    value.Third.Add(affector);
                    break;
                default:
                    break;
            }
        
        return value;
    }

    public IList<IQueued> Value
    {
        get => _value;
        set => _value = value;
    }

    private void Do(IEnumerable<IQueued> step)
    {
        foreach (var command in step)
            command.Do();
    }

    private void Undo(IEnumerable<IQueued> step)
    {
        foreach (var command in step)
            command.Undo();
    }

    public void Do()
    {
        var value = ValueSorted();
        Do(value.First);
        Do(value.Second);
        Do(value.Third);
    }

    public void Undo()
    {
        var value = ValueSorted();
        Undo(value.First);
        Undo(value.Second);
        Undo(value.Third);
    }

    public Queue() { }
}
