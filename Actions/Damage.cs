using System;

namespace MonogameTest01;

public static class Damage
{
    public static Action Value(Health health, int value) =>
    () => health.Value -= value;
}
