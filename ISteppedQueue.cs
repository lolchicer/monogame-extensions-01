using System;

namespace MonogameTest01;

public interface ISteppedQueue
{
    public enum Position
    {
        First,
        Second,
        Third
    }

    public void Add(Action value, Position position);

    public void Do();
}
