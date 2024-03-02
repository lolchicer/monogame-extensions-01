namespace MonogameTest01;

// IQueued можно запихнуть в History. это – неправильно.
public interface IQueued : ICommand
{
    public IQueue.Position Position { get; }
}
