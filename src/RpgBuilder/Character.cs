namespace RpgBuilder;

/// <summary>
/// RPGキャラクターを表すクラス
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
        var skills = Skills.Any() ? string.Join(", ", Skills) : "なし";
        var equipment = Equipment.Any() 
            ? string.Join(", ", Equipment.Select(e => $"{e.Key}: {e.Value}"))
            : "なし";

        return $"""
            ===== キャラクター情報 =====
            名前: {Name}
            クラス: {Class}
            レベル: {Level}
            HP: {Health}
            MP: {Mana}
            筋力: {Strength}
            敏捷: {Dexterity}
            知力: {Intelligence}
            体力: {Constitution}
            スキル: {skills}
            装備: {equipment}
            ============================
            """;
    }
}

