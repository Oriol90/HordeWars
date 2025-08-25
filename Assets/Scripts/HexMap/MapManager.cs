using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    public Tilemap tilemap;
    public List<TileBase> tileReferences;
    private Dictionary<string, TileBase> tileDict;
    private static string mapsDirectory => Path.Combine(Application.persistentDataPath, GC.MAP_DIRECTORY);

    void Awake()
    {
        tileDict = new Dictionary<string, TileBase>();
        foreach (var tile in tileReferences)
        {
            tileDict[tile.name] = tile;
        }
    }

    void Start()
    {
        //SaveMap();
        LoadMap();
    }

    private void LoadMap()
    {
        string path = Path.Combine(mapsDirectory, "Map");
        string json = File.ReadAllText(path);
        List<TileData> data = JsonConvert.DeserializeObject<List<TileData>>(json);

        tilemap.ClearAllTiles();

        tileDict = new Dictionary<string, TileBase>();
        foreach (var tile in tileReferences)
        {
            tileDict[tile.name] = tile;
        }

        foreach (var tileData in data)
        {
            Vector3Int pos = new Vector3Int(tileData.x, tileData.y, tileData.z);
            if (tileDict.TryGetValue(tileData.tileName, out TileBase tile))
            {
                tilemap.SetTile(pos, tile);
            }
        }
    }
    
    public void SaveMap()
    {
        List<TileData> data = new List<TileData>();

        foreach (var pos in tilemap.cellBounds.allPositionsWithin)
        {
            if (tilemap.HasTile(pos))
            {
                TileBase tile = tilemap.GetTile(pos);
                data.Add(new TileData
                {
                    x = pos.x,
                    y = pos.y,
                    z = pos.z,
                    tileName = tile.name
                });
            }
        }

        if (!Directory.Exists(mapsDirectory))
            Directory.CreateDirectory(mapsDirectory);

        string fullPath = Path.Combine(mapsDirectory, GC.MAP_FILE_NAME);
        string json = JsonConvert.SerializeObject(data, Formatting.Indented);

        File.WriteAllText(fullPath, json);
        Debug.Log($"[SaveGame] Guardado en: {fullPath}");
    }
}