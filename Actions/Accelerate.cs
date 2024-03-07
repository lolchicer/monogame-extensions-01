using System;

namespace MonogameTest01;

public static class Accelerate
{
    public static Action Value(Mechanics value, Affector input) =>
    () => value.Velocity += input.Velocity;
}
