using System;

public class UnitPO
{
    public Race Race { get; set; }
    public UnitType UnitType { get; set; }
    public float Experience { get; set; }
    public int Level { get; set; }
    public BaseStats BaseStats { get; set; }
    public UnitStats Stats { get; set; }

    protected UnitPO(float experience, BaseStats baseStats)
    {
        Experience = experience;
        Level = (int)Math.Floor(experience);

        BaseStats = baseStats;
        Stats = new UnitStats(baseStats, Level);
    }
}