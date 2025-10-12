using UnityEngine;

public class GirlKnightPO : UnitPO
{
    public GirlKnightPO(int experience, BaseStats baseStats, int level, Item item) : base(experience, baseStats, level, item){
        Race = Race.Human;
        UnitType = UnitType.GirlKnight; 
    }
}