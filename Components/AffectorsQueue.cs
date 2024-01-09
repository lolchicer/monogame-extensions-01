using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class AffectorsQueue
{
    private IEnumerable<Affector> _affectors;
    private (
        List<Affector> First,
        List<Affector> Second,
        List<Affector> Third)
        _value = new(new(), new(), new());
    private List<Affector>[] _valueSteps;
    private MechanicsVelocityPoller _velocityPoller;

    public enum Position
    {
        First,
        Second,
        Third
    }

    // требуется алгоритм, который будет исходя из требований объектов Affector сортировать их в _value 
    public void Sort()
    {
        foreach (var affector in _affectors)
            switch (affector.QueuePosition)
            {
                case Position.First:
                    _value.First.Add(affector);
                    break;
                case Position.Second:
                    _value.First.Add(affector);
                    break;
                case Position.Third:
                    _value.First.Add(affector);
                    break;
                default:
                    break;
            }
    }

    public void Update(GameTime gameTime)
    {
        Sort();
        foreach (var valueStep in _valueSteps)
        {
            foreach (var affector in valueStep)
                affector.Update(gameTime);
            _velocityPoller.Update(gameTime);
        }
        Clear();
    }

    public void Clear()
    {
        foreach (var valueStep in _valueSteps)
            valueStep.Clear();
    }

    public AffectorsQueue(IEnumerable<Affector> affectors, MechanicsVelocityPoller velocityPoller)
    {
        _valueSteps = new[] {
            _value.First,
            _value.Second,
            _value.Third };
        
        _affectors = affectors;
        _velocityPoller = velocityPoller;
    }
}