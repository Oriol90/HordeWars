using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    private static string mapsDirectory => Path.Combine(Application.persistentDataPath, GC.MAP_DIRECTORY);
    public Tilemap groundTilemap;
    public Tilemap fogTilemap;
    public List<TileBase> tileReferences;
    private Dictionary<string, TileBase> tileDict;
    private Dictionary<string, TileBase> fogTileDict;
    public static List<GroundTileData> groundTileDataList;
    public static List<FogTileData> fogTileDataList;
    public TileBase fogTile;
    public TileBase shadowTile;
    private Vector3Int heroPos = new Vector3Int();

    void Awake()
    {
        fogTileDict = new Dictionary<string, TileBase>();
        fogTileDict[fogTile.name] = fogTile;
        fogTileDict[shadowTile.name] = shadowTile;

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
        heroPos = GameSaveManager.LoadHeroPos();
        paintUnexplored();
        LoadFogMap(fogTileDict, fogTilemap);
        UpdateFog();
    }

    void Update()
    {
        Vector3Int lastHeroPos = heroPos;
        heroPos = GameSaveManager.LoadHeroPos();
        if (lastHeroPos != heroPos) UpdateFog();
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

    private void UpdateFog()
    {

        heroPos = GameSaveManager.LoadHeroPos();
        List<Vector3Int> posDiscoveredList = GetNeighborsThreeLayers(heroPos);
        List<GroundTileData> tileDataList = MapManager.groundTileDataList;

        List<GroundTileData> updatedTileList = new List<GroundTileData>();
        paintExplored(heroPos);
        paintVisible(posDiscoveredList, heroPos);
    }

    private void paintUnexplored()
    {
        for (int x = GC.TILEMAP_X_MIN; x < GC.TILEMAP_X_MAX; x++)
        {
            for (int y = GC.TILEMAP_Y_MIN; y < GC.TILEMAP_Y_MAX; y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);
                fogTilemap.SetTile(pos, fogTile);
            }
        }
    }

    private void paintExplored(Vector3Int heroPos)
    {
        for (int x = heroPos.x - 5; x < heroPos.x + 5; x++)
        {
            for (int y = heroPos.y - 5; y < heroPos.y + 5; y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);
                if (fogTilemap.GetTile(pos) == null) fogTilemap.SetTile(pos, shadowTile);
            }
        }
    }

    private void paintVisible(List<Vector3Int> posDiscoveredList, Vector3Int heroPos)
    {

        for (int x = heroPos.x - 4; x < heroPos.x + 4; x++)
        {
            for (int y = heroPos.y - 4; y < heroPos.y + 4; y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);
                foreach (var tile in posDiscoveredList)
                {
                    Vector3Int tilePos = new Vector3Int(tile.x, tile.y, 0);
                    if (pos == tilePos) fogTilemap.SetTile(pos, null);
                }

            }
        }
    }

    private List<Vector3Int> GetNeighborsThreeLayersPair = new List<Vector3Int>
    {
        new Vector3Int(1, 0, 0), new Vector3Int(0, 1, 0), new Vector3Int(-1, 1, 0),
        new Vector3Int(-1, 0, 0), new Vector3Int(-1, -1, 0), new Vector3Int(0, -1, 0),
        new Vector3Int(2, 0, 0), new Vector3Int(1, 1, 0), new Vector3Int(1, 2, 0),
        new Vector3Int(0, 2, 0), new Vector3Int(-1, 2, 0), new Vector3Int(-2, 1, 0),
        new Vector3Int(-2, 0, 0), new Vector3Int(-2, -1, 0), new Vector3Int(-1, -2, 0),
        new Vector3Int(0, -2, 0), new Vector3Int(1, -2, 0), new Vector3Int(1, -1, 0),
        new Vector3Int(3, 0, 0), new Vector3Int(2, 1, 0), new Vector3Int(2, 2, 0),
        new Vector3Int(1, 3, 0), new Vector3Int(0, 3, 0), new Vector3Int(-1, 3, 0),
        new Vector3Int(-2, 3, 0), new Vector3Int(-2, 2, 0), new Vector3Int(-3, 1, 0),
        new Vector3Int(-3, 0, 0), new Vector3Int(-3, -1, 0), new Vector3Int(-2, -2, 0),
        new Vector3Int(-2, -3, 0), new Vector3Int(-1, -3, 0), new Vector3Int(0, -3, 0),
        new Vector3Int(1, -3, 0), new Vector3Int(2, -2, 0), new Vector3Int(2, -1, 0),
        new Vector3Int(0, 0, 0)
    };

    private List<Vector3Int> GetNeighborsThreeLayersOdd = new List<Vector3Int>
    {

        new Vector3Int(1, 0, 0), new Vector3Int(0, 1, 0), new Vector3Int(-1, 1, 0),
        new Vector3Int(-1, 0, 0), new Vector3Int(-1, -1, 0), new Vector3Int(0, -1, 0),
        new Vector3Int(2, 0, 0), new Vector3Int(1, 1, 0), new Vector3Int(1, 2, 0),
        new Vector3Int(0, 2, 0), new Vector3Int(-1, 2, 0), new Vector3Int(-2, 1, 0),
        new Vector3Int(-2, 0, 0), new Vector3Int(-2, -1, 0), new Vector3Int(-1, -2, 0),
        new Vector3Int(0, -2, 0), new Vector3Int(1, -2, 0), new Vector3Int(1, -1, 0),
        new Vector3Int(3, 0, 0), new Vector3Int(2, 1, 0), new Vector3Int(2, 2, 0),
        new Vector3Int(1, 3, 0), new Vector3Int(0, 3, 0), new Vector3Int(-1, 3, 0),
        new Vector3Int(2, 3, 0), new Vector3Int(-2, 2, 0), new Vector3Int(3, 1, 0),
        new Vector3Int(-3, 0, 0), new Vector3Int(3, -1, 0), new Vector3Int(-2, -2, 0),
        new Vector3Int(2, -3, 0), new Vector3Int(-1, -3, 0), new Vector3Int(0, -3, 0),
        new Vector3Int(1, -3, 0), new Vector3Int(2, -2, 0), new Vector3Int(2, -1, 0),
        new Vector3Int(2, 2, 0), new Vector3Int(3, 0, 0), new Vector3Int(2, -2, 0),
        new Vector3Int(0, 0, 0)
    };

    private List<Vector3Int> GetNeighborsThreeLayers(Vector3Int heroPos)
    {
        List<Vector3Int> neighborsThreeLayers = new();
        List<Vector3Int> HexNeighborsThreeLayers = heroPos.y % 2 == 0 ? GetNeighborsThreeLayersPair : GetNeighborsThreeLayersOdd;

        foreach (var offset in HexNeighborsThreeLayers)
        {
            neighborsThreeLayers.Add(heroPos + offset);
        }
        return neighborsThreeLayers;
    }

    public void GoToBattle()
    {
        SceneManager.LoadScene(GC.SCENE_BATTLEGROUND);
    }

}