using System;

namespace MonogameTest01;

public class Death : ICommand
{
    public void Do()
    {
        throw new NotImplementedException();
    }

    public void Undo()
    {
        throw new NotImplementedException();
    }

    public Death() { }
}
