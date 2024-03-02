namespace MonogameTest01;

public class Damage : ICommand
{
    private Health _health;
    private int _value;

    public void Do()
    {
        _health.Value -= _value;
    }

    public void Undo()
    {
        _health.Value += _value;
    }

    public Damage(Health health, int value)
    {
        _health = health;
        _value = value;
    }
}
