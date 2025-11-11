namespace RpgBuilder;

/// <summary>
/// Represents an RPG character
/// </summary>
public class Character
{
    public string Name { get; set; } = string.Empty;
    public string Class { get; set; } = string.Empty;
    public int Level { get; set; }
    public int Health { get; set; }
    public int Mana { get; set; }
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Intelligence { get; set; }
    public int Constitution { get; set; }
    public List<string> Skills { get; set; } = new();
    public Dictionary<string, string> Equipment { get; set; } = new();

    public override string ToString()
    {
        var skills = Skills.Any() ? string.Join(", ", Skills) : "None";
        var equipment = Equipment.Any() 
            ? string.Join(", ", Equipment.Select(e => $"{e.Key}: {e.Value}"))
            : "None";

        return $"""
            ===== Character Information =====
            Name: {Name}
            Class: {Class}
            Level: {Level}
            HP: {Health}
            MP: {Mana}
            Strength: {Strength}
            Dexterity: {Dexterity}
            Intelligence: {Intelligence}
            Constitution: {Constitution}
            Skills: {skills}
            Equipment: {equipment}
            ===================================
            """;
    }
}

