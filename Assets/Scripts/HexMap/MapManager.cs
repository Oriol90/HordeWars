using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    public Tilemap groundTilemap;
    public List<TileBase> tileReferences;
    private Dictionary<string, TileBase> tileDict;
    private static string mapsDirectory => Path.Combine(Application.persistentDataPath, GC.MAP_DIRECTORY);
    public static List<GroundTileData> groundTileDataList;
    public static List<FogTileData> fogTileDataList;

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
        //SaveGroundMap();
        LoadGroundMap();
    }

    private void LoadGroundMap()
    {
        string path = Path.Combine(mapsDirectory, "Map");
        string json = File.ReadAllText(path);
        groundTileDataList = JsonConvert.DeserializeObject<List<GroundTileData>>(json);

        groundTilemap.ClearAllTiles();

        tileDict = new Dictionary<string, TileBase>();
        foreach (var tile in tileReferences)
        {
            tileDict[tile.name] = tile;
        }

        foreach (var tileData in groundTileDataList)
        {
            Vector3Int pos = new Vector3Int(tileData.x, tileData.y, tileData.z);
            if (tileDict.TryGetValue(tileData.tileName, out TileBase tile))
            {
                groundTilemap.SetTile(pos, tile);
            }
        }

    }

    private void SaveGroundMap()
    {
        List<GroundTileData> data = new List<GroundTileData>();

        foreach (var pos in groundTilemap.cellBounds.allPositionsWithin)
        {
            if (groundTilemap.HasTile(pos))
            {
                TileBase tile = groundTilemap.GetTile(pos);
                data.Add(Utils.GroundTileNameToGroundTileData(tile.name, pos));
            }
        }

        if (!Directory.Exists(mapsDirectory)) Directory.CreateDirectory(mapsDirectory);

        string fullPath = Path.Combine(mapsDirectory, GC.MAP_FILE_NAME);
        string json = JsonConvert.SerializeObject(data, Formatting.Indented);

        File.WriteAllText(fullPath, json);
        Debug.Log($"[SaveGame] Guardado en: {fullPath}");
        groundTileDataList = data;
    }

    public void LoadFogMap(Dictionary<string, TileBase> tileDict, Tilemap fogTilemap)
    {
        string path = Path.Combine(mapsDirectory, GC.FOG_MAP_FILE_NAME);
        string json = File.ReadAllText(path);
        fogTileDataList = JsonConvert.DeserializeObject<List<FogTileData>>(json);

        fogTilemap.ClearAllTiles();

        foreach (var tileData in fogTileDataList)
        {
            Vector3Int pos = new Vector3Int(tileData.x, tileData.y, tileData.z);
            if (tileDict.TryGetValue(tileData.tileName, out TileBase tile))
            {
                fogTilemap.SetTile(pos, tile);
            }
        }
    }

    public void SaveFogMap(Tilemap fogTilemap)
    {
        List<FogTileData> data = new List<FogTileData>();

        foreach (var pos in fogTilemap.cellBounds.allPositionsWithin)
        {
            if (fogTilemap.HasTile(pos))
            {
                TileBase tile = fogTilemap.GetTile(pos);
                data.Add(Utils.FogTileVisibilityToFogTileData(tile.name, pos));
            }
        }

        if (!Directory.Exists(mapsDirectory)) Directory.CreateDirectory(mapsDirectory);

        string fullPath = Path.Combine(mapsDirectory, GC.FOG_MAP_FILE_NAME);
        string json = JsonConvert.SerializeObject(data, Formatting.Indented);

        File.WriteAllText(fullPath, json);
        Debug.Log($"[SaveGame] Guardado en: {fullPath}");
        fogTileDataList = data;
    }

    public static GroundTileData GetTileByCoords(Vector3Int coords)
    {
        foreach (var tile in groundTileDataList)
        {
            Vector3Int pos = new Vector3Int(tile.x, tile.y, tile.z);
            if (coords == pos)
            {
                return tile;
            }
        }
        return null;
    }
}