using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

[Serializable]
public class ArmyData
{
    [JsonConverter(typeof(StringEnumConverter))] public UnitType unitType;
    public int quantity;
}