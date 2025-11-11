using RpgBuilder;

Console.WriteLine("===== RPG Builder パターン デモ =====\n");

// 戦士キャラクターを作成
var warrior = new CharacterBuilder()
    .WithName("アーサー")
    .WithClass("戦士")
    .WithLevel(10)
    .WithStats(health: 200, mana: 50, strength: 18, dexterity: 12, intelligence: 8, constitution: 16)
    .AddSkills("剣術", "防御", "挑発")
    .Equip("武器", "鋼の剣")
    .Equip("防具", "プレートアーマー")
    .Equip("盾", "鋼の盾")
    .Build();

Console.WriteLine(warrior);

// 魔法使いキャラクターを作成
var mage = new CharacterBuilder()
    .WithName("メルリナ")
    .WithClass("魔法使い")
    .WithLevel(15)
    .WithStats(health: 80, mana: 200, strength: 6, dexterity: 10, intelligence: 20, constitution: 8)
    .AddSkills("ファイアボール", "アイスボルト", "ライトニング", "テレポート")
    .Equip("武器", "魔法の杖")
    .Equip("防具", "ローブ")
    .Build();

Console.WriteLine(mage);

// 盗賊キャラクターを作成
var rogue = new CharacterBuilder()
    .WithName("シルバー")
    .WithClass("盗賊")
    .WithLevel(8)
    .WithHealth(120)
    .WithMana(60)
    .WithStrength(12)
    .WithDexterity(20)
    .WithIntelligence(14)
    .WithConstitution(10)
    .AddSkill("隠密")
    .AddSkill("開錠")
    .AddSkill("毒攻撃")
    .Equip("武器", "ダガー")
    .Equip("防具", "レザーアーマー")
    .Build();

Console.WriteLine(rogue);

Console.WriteLine("\n===== デモ終了 =====");
