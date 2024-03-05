using System;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public static class EffectApply
{
    public static Action Value(Effects effects, GameComponent effect) =>
    () => effects.Value.Add(effect);
}
