namespace RpgBuilder;

/// <summary>
/// Builderパターンを実装したキャラクタービルダー
/// </summary>
public class CharacterBuilder
{
    private Character _character = new();

    /// <summary>
    /// キャラクターの名前を設定
    /// </summary>
    public CharacterBuilder WithName(string name)
    {
        _character.Name = name;
        return this;
    }

    /// <summary>
    /// キャラクターのクラスを設定
    /// </summary>
    public CharacterBuilder WithClass(string characterClass)
    {
        _character.Class = characterClass;
        return this;
    }

    /// <summary>
    /// キャラクターのレベルを設定
    /// </summary>
    public CharacterBuilder WithLevel(int level)
    {
        _character.Level = level;
        return this;
    }

    /// <summary>
    /// ステータスを一括設定
    /// </summary>
    public CharacterBuilder WithStats(int health, int mana, int strength, int dexterity, int intelligence, int constitution)
    {
        _character.Health = health;
        _character.Mana = mana;
        _character.Strength = strength;
        _character.Dexterity = dexterity;
        _character.Intelligence = intelligence;
        _character.Constitution = constitution;
        return this;
    }

    /// <summary>
    /// HPを設定
    /// </summary>
    public CharacterBuilder WithHealth(int health)
    {
        _character.Health = health;
        return this;
    }

    /// <summary>
    /// MPを設定
    /// </summary>
    public CharacterBuilder WithMana(int mana)
    {
        _character.Mana = mana;
        return this;
    }

    /// <summary>
    /// 筋力を設定
    /// </summary>
    public CharacterBuilder WithStrength(int strength)
    {
        _character.Strength = strength;
        return this;
    }

    /// <summary>
    /// 敏捷を設定
    /// </summary>
    public CharacterBuilder WithDexterity(int dexterity)
    {
        _character.Dexterity = dexterity;
        return this;
    }

    /// <summary>
    /// 知力を設定
    /// </summary>
    public CharacterBuilder WithIntelligence(int intelligence)
    {
        _character.Intelligence = intelligence;
        return this;
    }

    /// <summary>
    /// 体力を設定
    /// </summary>
    public CharacterBuilder WithConstitution(int constitution)
    {
        _character.Constitution = constitution;
        return this;
    }

    /// <summary>
    /// スキルを追加
    /// </summary>
    public CharacterBuilder AddSkill(string skill)
    {
        _character.Skills.Add(skill);
        return this;
    }

    /// <summary>
    /// 複数のスキルを追加
    /// </summary>
    public CharacterBuilder AddSkills(params string[] skills)
    {
        _character.Skills.AddRange(skills);
        return this;
    }

    /// <summary>
    /// 装備を追加
    /// </summary>
    public CharacterBuilder Equip(string slot, string item)
    {
        _character.Equipment[slot] = item;
        return this;
    }

    /// <summary>
    /// キャラクターを構築
    /// </summary>
    public Character Build()
    {
        // 必須項目の検証
        if (string.IsNullOrWhiteSpace(_character.Name))
        {
            throw new InvalidOperationException("キャラクター名は必須です。");
        }

        if (string.IsNullOrWhiteSpace(_character.Class))
        {
            throw new InvalidOperationException("クラスは必須です。");
        }

        // レベルに基づいてステータスを自動調整（オプション）
        if (_character.Level > 0 && _character.Health == 0)
        {
            _character.Health = 100 + (_character.Level * 10);
        }

        return _character;
    }

    /// <summary>
    /// ビルダーをリセット
    /// </summary>
    public CharacterBuilder Reset()
    {
        _character = new Character();
        return this;
    }
}

