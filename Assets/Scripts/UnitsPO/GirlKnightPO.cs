using UnityEngine;

public class GirlKnightPO : UnitPO
{
    public GirlKnightPO(string unitName, int experience, BaseStats baseStats, int level, Item item) : base(unitName, experience, baseStats, level, item, Gender.Female){
        Race = Race.Human;
        UnitType = UnitType.GirlKnight; 
    }
}