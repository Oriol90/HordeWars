using System;

[Serializable]
public class UnitData
{
    public string unitName;
    public Race race;
    public UnitType unitType;
    public int experience;
    public Item item;

    public UnitData() { }

    public UnitData(string unitName, Race race, int experience, UnitType unitType)
    {
        this.race = race;
        this.unitType = unitType;
        this.experience = experience;
        this.unitName = unitName;
    }

    public UnitData(string unitName, Race race, int experience, UnitType unitType, Item item)
    {
        this.race = race;
        this.unitType = unitType;
        this.experience = experience;
        this.item = item;
        this.unitName = unitName;
    }

    
}