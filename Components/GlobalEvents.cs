using System;

public class GlobalEvents
{
    public event Action<int> Damage;
    public void Damage1(int value) => Damage?.Invoke(value);

    public GlobalEvents()
    {
        
    }
}
