public class LeafArcherPO : UnitPO
{
    public LeafArcherPO(float experience, BaseStats baseStats) : base(experience, baseStats){
        Race = Race.Undead;
        UnitType = UnitType.LeafArcher; 
    }
}