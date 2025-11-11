using RpgBuilder;

namespace RpgBuilder.Tests;

public class CharacterBuilderTests
{
    [Fact]
    public void Build_CanCreateBasicCharacter()
    {
        // Arrange & Act
        var character = new CharacterBuilder()
            .WithName("Test Character")
            .WithClass("Warrior")
            .WithLevel(1)
            .WithHealth(100)
            .Build();

        // Assert
        Assert.Equal("Test Character", character.Name);
        Assert.Equal("Warrior", character.Class);
        Assert.Equal(1, character.Level);
        Assert.Equal(100, character.Health);
    }

    [Fact]
    public void Build_ThrowsExceptionWhenNameNotSet()
    {
        // Arrange & Act & Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            new CharacterBuilder()
                .WithClass("Warrior")
                .Build();
        });
    }

    [Fact]
    public void Build_ThrowsExceptionWhenClassNotSet()
    {
        // Arrange & Act & Assert
        Assert.Throws<InvalidOperationException>(() =>
        {
            new CharacterBuilder()
                .WithName("Test Character")
                .Build();
        });
    }

    [Fact]
    public void WithStats_CanSetAllStatsAtOnce()
    {
        // Arrange & Act
        var character = new CharacterBuilder()
            .WithName("Test Character")
            .WithClass("Warrior")
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
    public void AddSkills_CanAddMultipleSkills()
    {
        // Arrange & Act
        var character = new CharacterBuilder()
            .WithName("Test Character")
            .WithClass("Warrior")
            .AddSkills("Swordsmanship", "Defense", "Taunt")
            .Build();

        // Assert
        Assert.Equal(3, character.Skills.Count);
        Assert.Contains("Swordsmanship", character.Skills);
        Assert.Contains("Defense", character.Skills);
        Assert.Contains("Taunt", character.Skills);
    }

    [Fact]
    public void Equip_CanAddEquipment()
    {
        // Arrange & Act
        var character = new CharacterBuilder()
            .WithName("Test Character")
            .WithClass("Warrior")
            .Equip("Weapon", "Steel Sword")
            .Equip("Armor", "Plate Armor")
            .Build();

        // Assert
        Assert.Equal(2, character.Equipment.Count);
        Assert.Equal("Steel Sword", character.Equipment["Weapon"]);
        Assert.Equal("Plate Armor", character.Equipment["Armor"]);
    }

    [Fact]
    public void Reset_CanResetBuilder()
    {
        // Arrange
        var builder = new CharacterBuilder()
            .WithName("First Character")
            .WithClass("Warrior");

        // Act
        builder.Reset();
        var character = builder
            .WithName("New Character")
            .WithClass("Mage")
            .Build();

        // Assert
        Assert.Equal("New Character", character.Name);
        Assert.Equal("Mage", character.Class);
    }

    [Fact]
    public void Build_AutoSetsHealthBasedOnLevel()
    {
        // Arrange & Act
        var character = new CharacterBuilder()
            .WithName("Test Character")
            .WithClass("Warrior")
            .WithLevel(5)
            .Build();

        // Assert
        Assert.True(character.Health > 0);
        Assert.Equal(150, character.Health); // 100 + (5 * 10)
    }
}
