using System;

namespace MonogameTest01;

public static class AccelerateTracking
{
    public static Action Value(Mechanics value, Input input) =>
    () => value.Velocity += input.Velocity;
}
