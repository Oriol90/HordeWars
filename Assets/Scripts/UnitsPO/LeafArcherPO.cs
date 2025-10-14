using UnityEngine;

public class LeafArcherPO : UnitPO
{
    public LeafArcherPO(string unitName, int experience, BaseStats baseStats, int level, Item item) : base(unitName, experience, baseStats, level, item, Gender.Male){
        Race = Race.Undead;
        UnitType = UnitType.LeafArcher; 
    }
}