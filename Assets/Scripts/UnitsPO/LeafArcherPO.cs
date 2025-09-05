public class LeafArcherPO : UnitPO
{
    public Race Race { get; set; }
    public UnitType UnitType { get; set; }

    public LeafArcherPO(float experience, BaseStats baseStats) : base(experience, baseStats){
        Race = Race.Undead;
        UnitType = UnitType.LeafArcher; 
    }
}