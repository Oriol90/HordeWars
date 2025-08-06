using UnityEngine;

[System.Serializable]
public class HexTileData
{
    public Vector2Int coordinates;
    public string biome;
    public string feature; // "None", "Cave", "EnemyArmy", "Camp", etc.
    public bool isDiscovered;
    public float cost;
}
