using Microsoft.Xna.Framework;

namespace MonogameTest01;

public class LinkingFactory
{
    private Mechanics _mechaincs;

    public Linking New(Vector2 velocity) => new Linking(velocity, _mechaincs);

    public LinkingFactory(Mechanics mechanics)
    {
        _mechaincs = mechanics;
    }
}