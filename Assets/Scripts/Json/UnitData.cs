using System;

[Serializable]
public class UnitData
{
    public Race race;
    public UnitType unitType;
    public int experience;
    public Item item;

    public UnitData() { }

    public UnitData(Race race, int experience, UnitType unitType)
    {
        this.race = race;
        this.unitType = unitType;
        this.experience = experience;
    }

    public UnitData(Race race, int experience, UnitType unitType, Item item)
    {
        this.race = race;
        this.unitType = unitType;
        this.experience = experience;
        this.item = item;
    }

    
}