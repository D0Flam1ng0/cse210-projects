using System;
using System.Collections.Generic;

public class Spellbook
{
    private List<Spell> _spells;

    public Spellbook()
    {
        _spells = new List<Spell>();
    }

    public void AddSpell(Spell spell)
    {
        _spells.Add(spell);
    }

    public void ShowSpells()
    {
        Console.WriteLine("Spells in Book:");
        foreach (var spell in _spells)
        {
            Console.WriteLine($"- {spell.Name} (Level {spell.Level})");
        }
    }

    public void CastAll()
    {
        Console.WriteLine("\nCast Results:");
        foreach (var spell in _spells)
        {
            Console.WriteLine($"{spell.Name}: {spell.Cast()}");
        }
    }
}
