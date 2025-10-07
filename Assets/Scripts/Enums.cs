using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

[JsonConverter(typeof(StringEnumConverter))] 
public enum FogState
{
    Unexplored,
    Explored,
    Visible
}

[JsonConverter(typeof(StringEnumConverter))] 
public enum Biome
{
    Beach,
    Forrest,
    Grass,
    Mountain,
    River,
    Sea
}

[JsonConverter(typeof(StringEnumConverter))] 
public enum DataType
{
    ArmyData,
    ArmoryData,
    BaseStats,
    ItemData,
    FogTileData,
    GameData,
    GroundTileData,
    HeroData,
    PlayerData,
    TalentData,
    TokenData,
    InstructorData
}

[JsonConverter(typeof(StringEnumConverter))] 
public enum UnitType
{
    GirlKnight,
    LeafArcher,
    Archer,
    Felipe
}

[JsonConverter(typeof(StringEnumConverter))] 
public enum Race
{
    Human,
    Undead,
    Beast,
    Orc,
    Elf
}

[JsonConverter(typeof(StringEnumConverter))] 
public enum Rarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Mythic,
    Celestial
}

[JsonConverter(typeof(StringEnumConverter))]
public enum Mastery
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

[JsonConverter(typeof(StringEnumConverter))]
public enum Stat
{
    Health,
    Attack,
    AttackSpeed,
    Defense,
    DarkResist,
    MoveSpeed,
    BoneCost,
    LightCost,
    Faith
}

[JsonConverter(typeof(StringEnumConverter))]
public enum Effect
{
    None,
    Burn,
    Freeze,
    Poison,
    Stun,
    HealOverTime,
    DamageOverTime,
    IncreaseStat,
    DecreaseStat,
    DefenseBoost,
    AttackBoost,
    HealthBoost,
    ManaBoost,
    SpellPowerBoost
}

[JsonConverter(typeof(StringEnumConverter))]
public enum Item
{
    None,
    WoodenSword,
    IronShield,
    MagicWand,
    Sword,
    Bow,
    Staff,
    Shield,
    Helmet,
    Armor,
    Boots,
    Ring,
    Amulet
}
