using UnityEngine;

public class ArcherPO : UnitPO
{
    public ArcherPO(int experience, BaseStats baseStats, int level, Item item) : base(experience, baseStats, level, item)
    {
        Race = Race.Human;
        UnitType = UnitType.Archer;
    }
}