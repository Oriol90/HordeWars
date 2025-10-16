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

    public UnitData() {}

    protected UnitData(int experience, Item equippedItem)
    {
        this.experience = experience;
        level = Utils.ExperienceToLevel(experience);
        baseStats = BaseStatsDBStatic.GetBaseStatsByUnitType(unitType);
        //stats = new UnitStats(baseStats, level);
        this.equippedItem = equippedItem;

    }

    public string GetInfo()
    {
        return
            $"Class: {unitType}\n" +
            $"Level: {level}\n" +
            $"Experience: {experience}\n" +
            $"Health: {baseStats.health[level - 1]}\n" +
            $"Attack: {baseStats.attack[level - 1]}\n" +
            $"Attack Speed: {baseStats.attackSpeed[level - 1]}\n" +
            $"Defense: {baseStats.defense[level - 1]}\n" +
            $"Dark Resist: {baseStats.darkResist[level - 1]}\n" +
            $"Move Speed: {baseStats.moveSpeed[level - 1]}\n" +
            $"Faith: {baseStats.faith}\n";
    }
}