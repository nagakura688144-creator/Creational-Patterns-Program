using RpgBuilder;

namespace RpgBuilder.Tests;

public class CharacterBuilderTests
{
    [Fact]
    public void Build_基本的なキャラクターを作成できる()
    {
        // Arrange & Act
        var character = new CharacterBuilder()
            .WithName("テストキャラ")
            .WithClass("戦士")
            .WithLevel(1)
            .WithHealth(100)
            .Build();

        // Assert
        Assert.Equal("テストキャラ", character.Name);
        Assert.Equal("戦士", character.Class);
        Assert.Equal(1, character.Level);
        Assert.Equal(100, character.Health);
    }

    [Fact]
    public void Build_名前が未設定の場合_例外をスローする()
    {
        // Arrange & Act & Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            new CharacterBuilder()
                .WithClass("戦士")
                .Build();
        });
    }

    [Fact]
    public void Build_クラスが未設定の場合_例外をスローする()
    {
        // Arrange & Act & Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            new CharacterBuilder()
                .WithName("テストキャラ")
                .Build();
        });
    }

    [Fact]
    public void WithStats_ステータスを一括設定できる()
    {
        // Arrange & Act
        var character = new CharacterBuilder()
            .WithName("テストキャラ")
            .WithClass("戦士")
            .WithStats(health: 200, mana: 50, strength: 18, dexterity: 12, intelligence: 8, constitution: 16)
            .Build();

        // Assert
        Assert.Equal(200, character.Health);
        Assert.Equal(50, character.Mana);
        Assert.Equal(18, character.Strength);
        Assert.Equal(12, character.Dexterity);
        Assert.Equal(8, character.Intelligence);
        Assert.Equal(16, character.Constitution);
    }

    [Fact]
    public void AddSkills_複数のスキルを追加できる()
    {
        // Arrange & Act
        var character = new CharacterBuilder()
            .WithName("テストキャラ")
            .WithClass("戦士")
            .AddSkills("剣術", "防御", "挑発")
            .Build();

        // Assert
        Assert.Equal(3, character.Skills.Count);
        Assert.Contains("剣術", character.Skills);
        Assert.Contains("防御", character.Skills);
        Assert.Contains("挑発", character.Skills);
    }

    [Fact]
    public void Equip_装備を追加できる()
    {
        // Arrange & Act
        var character = new CharacterBuilder()
            .WithName("テストキャラ")
            .WithClass("戦士")
            .Equip("武器", "鋼の剣")
            .Equip("防具", "プレートアーマー")
            .Build();

        // Assert
        Assert.Equal(2, character.Equipment.Count);
        Assert.Equal("鋼の剣", character.Equipment["武器"]);
        Assert.Equal("プレートアーマー", character.Equipment["防具"]);
    }

    [Fact]
    public void Reset_ビルダーをリセットできる()
    {
        // Arrange
        var builder = new CharacterBuilder()
            .WithName("最初のキャラ")
            .WithClass("戦士");

        // Act
        builder.Reset();
        var character = builder
            .WithName("新しいキャラ")
            .WithClass("魔法使い")
            .Build();

        // Assert
        Assert.Equal("新しいキャラ", character.Name);
        Assert.Equal("魔法使い", character.Class);
    }

    [Fact]
    public void Build_レベルに基づいてHPが自動設定される()
    {
        // Arrange & Act
        var character = new CharacterBuilder()
            .WithName("テストキャラ")
            .WithClass("戦士")
            .WithLevel(5)
            .Build();

        // Assert
        Assert.True(character.Health > 0);
        Assert.Equal(150, character.Health); // 100 + (5 * 10)
    }
}
