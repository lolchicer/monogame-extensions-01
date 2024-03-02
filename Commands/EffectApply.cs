using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class EffectApply : ICommand
{
    private Effects _effects;
    private GameComponent _effect;

    public void Do()
    {
        _effects.Value.Add(_effect);
    }

    public void Undo()
    {
        _effects.Value.Remove(_effect);
    }

    public EffectApply(Effects effects, GameComponent effect)
    {
        _effects = effects;
        _effect = effect;
    }
}
