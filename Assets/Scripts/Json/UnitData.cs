using System;

[Serializable]
public class UnitData
{
    public Race race;
    public UnitType unitType;
    public float experience;

    public UnitData(Race race, float experience, UnitType unitType)
    {
        this.race = race;
        this.unitType = unitType;
        this.experience = experience;
    }
}