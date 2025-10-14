using UnityEngine;

public class FelipePO : UnitPO
{
    public FelipePO(string unitName, int experience, BaseStats baseStats, int level, Item item) : base(unitName, experience, baseStats, level, item, Gender.Male)
    {
        Race = Race.Human;
        UnitType = UnitType.Felipe; 
    }
}