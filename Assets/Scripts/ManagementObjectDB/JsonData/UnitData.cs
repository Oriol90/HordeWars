using System;

public class UnitData :IElementDB
{
    public Guid id { get; set; } = Guid.NewGuid();
    public string unitName { get; set; }
    public Gender gender { get; set; }
    public Race race { get; set; }
    public UnitType unitType { get; set; }
    public int level { get; set; }
    public int experience { get; set; }
    public BaseStats baseStats { get; set; }
    //public UnitStats stats { get; set; }
    public Item equippedItem { get; set; }
    public Rarity avgRarity { get; set; }

    public UnitData() {}

    protected UnitData(int experience, Item equippedItem)
    {
        this.experience = experience;
        level = Utils.ExperienceToLevel(experience);
        baseStats = BaseStatsDBStatic.GetBaseStatsByUnitType(unitType);
        //stats = new UnitStats(baseStats, level);
        this.equippedItem = equippedItem;
        avgRarity = Utils.CalculateAverageRarityUnit(level, ItemDBStatic.Get(equippedItem).Rarity);
    }

    public string GetInfo()
    {
        return LocalizationManager.GetText(TextKeys.UNITDATA_INFO, unitType, level, experience,
            baseStats.health[level - 1], baseStats.attack[level - 1], baseStats.attackSpeed[level - 1],
            baseStats.defense[level - 1], baseStats.darkResist[level - 1], baseStats.moveSpeed[level - 1], baseStats.faith);
    }
}