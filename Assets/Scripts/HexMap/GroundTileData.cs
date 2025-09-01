using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

[System.Serializable]
public class GroundTileData {
    public string tileName;
    [JsonConverter(typeof(StringEnumConverter))] public Biome biome;
    public string feature;
    public int cost;
    public int x;
    public int y;
    public int z;
}