using System;

namespace MonogameTest01;

public interface IQueue
{
    public void Add(Action value);

    public void Do();
}
