public class ArcherPO : UnitPO
{
    public Race Race { get; set; }
    public UnitType UnitType { get; set; }

    public ArcherPO(float experience, BaseStats baseStats) : base(experience, baseStats){
        Race = Race.Human;
        UnitType = UnitType.Archer; 
    }
}