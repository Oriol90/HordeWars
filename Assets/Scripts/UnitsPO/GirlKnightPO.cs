public class GirlKnightPO : UnitPO
{
    public Race Race { get; set; }
    public UnitType UnitType { get; set; }

    public GirlKnightPO(float experience, BaseStats baseStats) : base(experience, baseStats){
        Race = Race.Human;
        UnitType = UnitType.GirlKnight; 
    }
}