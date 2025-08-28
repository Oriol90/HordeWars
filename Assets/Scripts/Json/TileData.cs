using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

[System.Serializable]
public class TileData {
    public string tileName;
    [JsonConverter(typeof(StringEnumConverter))] public Biome biome;
    public string feature;
    [JsonConverter(typeof(StringEnumConverter))]public FogState fogState;
    public int cost;
    public int x;
    public int y;
    public int z;
}