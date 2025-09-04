using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

[Serializable]
public class UnitData
{
    [JsonConverter(typeof(StringEnumConverter))] public Race race;
    [JsonConverter(typeof(StringEnumConverter))] public UnitType unitType;
    public float experience;

    public UnitData(Race race, float experience, UnitType unitType)
    {
        this.race = race;
        this.unitType = unitType;
        this.experience = experience;
    }
}