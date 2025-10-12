using UnityEngine;

public class UnitPO
{
    public Race Race { get; set; }
    public UnitType UnitType { get; set; }
    public int Experience { get; set; }
    public int Level { get; set; }
    public BaseStats BaseStats { get; set; }
    public UnitStats Stats { get; set; }
    public Item EquippedItem { get; set; }    

    protected UnitPO(int experience, BaseStats baseStats, int level, Item equippedItem)
    {
        Experience = experience;
        Level = level;
        BaseStats = baseStats;
        Stats = new UnitStats(baseStats, Level);
        EquippedItem = equippedItem;
    }

    public string GetInfo()
    {
        return $"Level: {Level}\n" +
               $"Experience: {Experience}\n" +
               $"Health: {Stats.Health}\n" +
               $"Attack: {Stats.Attack}\n" +
               $"Attack Speed: {Stats.AttackSpeed}\n" +
               $"Defense: {Stats.Defense}\n" +
               $"Dark Resist: {Stats.DarkResist}\n" +
               $"Move Speed: {Stats.MoveSpeed}\n" +
               $"Faith: {Stats.Faith}\n";
    }
}