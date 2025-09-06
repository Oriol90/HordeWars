public class ArcherPO : UnitPO
{
    public ArcherPO(float experience, BaseStats baseStats) : base(experience, baseStats)
    {
        Race = Race.Human;
        UnitType = UnitType.Archer;
    }
}