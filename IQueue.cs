using System;
using System.Collections.Generic;

namespace MonogameTest01;

public interface IQueue
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
