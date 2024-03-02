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

    public IList<IQueued> Value { get;}
}
