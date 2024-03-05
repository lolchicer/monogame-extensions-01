using System;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public static class Move
{
    public static Action Value(Mechanics mechanics, Vector2 value) =>
    () => mechanics.Position += value;
}
