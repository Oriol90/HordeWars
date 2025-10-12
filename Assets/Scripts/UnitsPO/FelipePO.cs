using UnityEngine;

public class FelipePO : UnitPO
{
    public FelipePO(int experience, BaseStats baseStats, int level, Item item) : base(experience, baseStats, level, item)
    {
        Race = Race.Human;
        UnitType = UnitType.Felipe; 
    }
}