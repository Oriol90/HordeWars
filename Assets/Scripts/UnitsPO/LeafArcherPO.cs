using UnityEngine;

public class LeafArcherPO : UnitPO
{
    public LeafArcherPO(int experience, BaseStats baseStats, int level, Item item) : base(experience, baseStats, level, item){
        Race = Race.Undead;
        UnitType = UnitType.LeafArcher; 
        ImageIcon = Resources.Load<Sprite>(ResourcePathDBStatic.Get(UnitType));

    }
}