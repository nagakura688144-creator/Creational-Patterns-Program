using RpgBuilder;

Console.WriteLine("===== RPG Builder Pattern Demo =====\n");

// Create a warrior character
var warrior = new CharacterBuilder()
    .WithName("Arthur")
    .WithClass("Warrior")
    .WithLevel(10)
    .WithStats(health: 200, mana: 50, strength: 18, dexterity: 12, intelligence: 8, constitution: 16)
    .AddSkills("Swordsmanship", "Defense", "Taunt")
    .Equip("Weapon", "Steel Sword")
    .Equip("Armor", "Plate Armor")
    .Equip("Shield", "Steel Shield")
    .Build();

Console.WriteLine(warrior);

// Create a mage character
var mage = new CharacterBuilder()
    .WithName("Merlina")
    .WithClass("Mage")
    .WithLevel(15)
    .WithStats(health: 80, mana: 200, strength: 6, dexterity: 10, intelligence: 20, constitution: 8)
    .AddSkills("Fireball", "Ice Bolt", "Lightning", "Teleport")
    .Equip("Weapon", "Magic Staff")
    .Equip("Armor", "Robe")
    .Build();

Console.WriteLine(mage);

// Create a rogue character
var rogue = new CharacterBuilder()
    .WithName("Silver")
    .WithClass("Rogue")
    .WithLevel(8)
    .WithHealth(120)
    .WithMana(60)
    .WithStrength(12)
    .WithDexterity(20)
    .WithIntelligence(14)
    .WithConstitution(10)
    .AddSkill("Stealth")
    .AddSkill("Lockpicking")
    .AddSkill("Poison Attack")
    .Equip("Weapon", "Dagger")
    .Equip("Armor", "Leather Armor")
    .Build();

Console.WriteLine(rogue);

Console.WriteLine("\n===== Demo Complete =====");
