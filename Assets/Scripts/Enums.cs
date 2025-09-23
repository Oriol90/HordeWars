using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

[JsonConverter(typeof(StringEnumConverter))] public enum FogState
{
    Unexplored,
    Explored,
    Visible
}

[JsonConverter(typeof(StringEnumConverter))] public enum Biome
{
    Beach,
    Forrest,
    Grass,
    Mountain,
    River,
    Sea
}

[JsonConverter(typeof(StringEnumConverter))] public enum DataType
{
    ArmyData,
    BaseStats,
    FogTileData,
    GameData,
    GroundTileData,
    HeroData,
    PlayerData,
    TalentData,
    TokenData,
    InstructorData
}

[JsonConverter(typeof(StringEnumConverter))] public enum UnitType
{
    GirlKnight,
    LeafArcher,
    Archer,
    Felipe
}

[JsonConverter(typeof(StringEnumConverter))] public enum Race
{
    Human,
    Undead,
    Beast,
    Orc,
    Elf
}

[JsonConverter(typeof(StringEnumConverter))] public enum Rarity
{
    Common,
    Uncommon,
    Superior,
    Rare,
    Epic,
    Celestial
}

[JsonConverter(typeof(StringEnumConverter))] public enum Mastery
{
    None,
    FireArrows,
    DefenseAura,
    Healing,
    SwiftStrike,
    PoisonedBlades,
    FrostArrows,
    ShieldBash,
    Whirlwind,
    Snipe,
    Taunt,
    Cleave,
    PiercingShot,
    Enrage,
    Regeneration,
    Vampirism,
    Evasion,
    Counterattack,
    StunningBlow,
    FrostArmor,
    Fireball
}