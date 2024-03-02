namespace MonogameTest01;

public class Cast : ICommand
{
    private Spells _spells;
    private Spell _spell;

    public void Do()
    {
        _spells.Activated.Add(_spell);
    }

    public void Undo()
    {
        _spells.Activated.Remove(_spell);
    }

    public Cast(Spells spells, Spell spell)
    {
        _spells = spells;
        _spell = spell;
    }
}
