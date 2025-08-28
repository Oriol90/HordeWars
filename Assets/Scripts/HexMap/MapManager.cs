using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.Tilemaps;
using Unity.VisualScripting;

public class MapManager : MonoBehaviour
{
    public Tilemap tilemap;
    public List<TileBase> tileReferences;
    private Dictionary<string, TileBase> tileDict;
    private static string mapsDirectory => Path.Combine(Application.persistentDataPath, GC.MAP_DIRECTORY);
    public static List<TileData> tileDataList;

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
        SaveMap();
        //LoadMap();
    }

    void FixedUpdate()
    {
        //UpdateFog();
        //LoadMap();
    }

    private void LoadMap()
    {
        string path = Path.Combine(mapsDirectory, "Map");
        string json = File.ReadAllText(path);
        tileDataList = JsonConvert.DeserializeObject<List<TileData>>(json);

        tilemap.ClearAllTiles();

        tileDict = new Dictionary<string, TileBase>();
        foreach (var tile in tileReferences)
        {
            tileDict[tile.name] = tile;
        }

        
    }

    private void SaveMap()
    {
        List<TileData> data = new List<TileData>();

        foreach (var pos in tilemap.cellBounds.allPositionsWithin)
        {
            if (tilemap.HasTile(pos))
            {
                TileBase tile = tilemap.GetTile(pos);
                data.Add(Utils.TileNameToTileData(tile.name, pos));
            }
        }

        if (!Directory.Exists(mapsDirectory)) Directory.CreateDirectory(mapsDirectory);

        string fullPath = Path.Combine(mapsDirectory, GC.MAP_FILE_NAME);
        string json = JsonConvert.SerializeObject(data, Formatting.Indented);

        File.WriteAllText(fullPath, json);
        Debug.Log($"[SaveGame] Guardado en: {fullPath}");
        tileDataList = data;
    }

    public void SaveMap(List<TileData> data)
    {
        if (!Directory.Exists(mapsDirectory)) Directory.CreateDirectory(mapsDirectory);

        string fullPath = Path.Combine(mapsDirectory, GC.MAP_FILE_NAME);
        string json = JsonConvert.SerializeObject(data, Formatting.Indented);

        File.WriteAllText(fullPath, json);
        Debug.Log($"[SaveGame] Guardado en: {fullPath}");
        tileDataList = data;
    }

    public static TileData GetTileByCoords(Vector3Int coords)
    {
        foreach (var tile in tileDataList)
        {
            Vector3Int pos = new Vector3Int(tile.x, tile.y, tile.z);
            if (coords == pos)
            {
                return tile;
            }
        }
        return null;
    }

    // private void UpdateFog()
    // {
    //     Vector3Int heroPos = GameSaveManager.LoadHeroPos();
    //     List<Vector3Int> posDiscoveredList = GetNeighborsThreeLayers(heroPos);
    //     List<TileData> updatedTileList = new List<TileData>();

    //     foreach (var tile in tileDataList)
    //     {
    //         if (tile.fogState == FogState.Visible) tile.fogState = FogState.Explored;
    //         foreach (var posDiscovered in posDiscoveredList)
    //         {
    //             Vector3Int tilePos = new Vector3Int(tile.x, tile.y, tile.z);
    //             if (posDiscovered == tilePos)
    //             {
    //                 tile.fogState = FogState.Visible;
    //             }
    //         }
    //         updatedTileList.Add(tile);
    //     }
    //     SaveMap(updatedTileList);
    // }

    
}