using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

[System.Serializable]
public class FogTileData {
    public string tileName;
    [JsonConverter(typeof(StringEnumConverter))] public FogState fogState;
    public int x;
    public int y;
    public int z;
}