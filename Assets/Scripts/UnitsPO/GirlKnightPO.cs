public class GirlKnightPO : UnitPO
{
    public GirlKnightPO(float experience, BaseStats baseStats) : base(experience, baseStats){
        Race = Race.Human;
        UnitType = UnitType.GirlKnight; 
    }
}