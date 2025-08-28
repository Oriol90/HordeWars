using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FogManager : MonoBehaviour
{
    public Tilemap fogTilemap;
    public Tilemap groundTilemap;
    public TileBase fogTile;
    public TileBase shadowTile;
    private Vector3Int heroPos = new Vector3Int();


    void Start()
    {
        paintUnexplored();
        heroPos = GameSaveManager.LoadHeroPos();
        UpdateFog();
    }

    void Update()
    {
        Vector3Int lastHeroPos = heroPos;
        heroPos = GameSaveManager.LoadHeroPos();
        if (lastHeroPos != heroPos) UpdateFog();
        

    }

    private void UpdateFog()
    {

        heroPos = GameSaveManager.LoadHeroPos();
        List<Vector3Int> posDiscoveredList = GetNeighborsThreeLayers(heroPos);
        List<TileData> tileDataList = MapManager.tileDataList;

        List<TileData> updatedTileList = new List<TileData>();
        paintExplored(heroPos);
        paintVisible(posDiscoveredList, heroPos);
    }

    private void paintUnexplored() {

        BoundsInt bounds = groundTilemap.cellBounds;

        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);
                fogTilemap.SetTile(pos, fogTile);
            }
        }
    }

    private void paintExplored(Vector3Int heroPos) {

        //BoundsInt bounds = groundTilemap.cellBounds;

        for (int x = heroPos.x - 5; x < heroPos.x + 5; x++)
        {
            for (int y = heroPos.y - 5; y < heroPos.y + 5; y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);
                if (fogTilemap.GetTile(pos) == null) fogTilemap.SetTile(pos, shadowTile);
            }
        }
    }

    private void paintVisible(List<Vector3Int> posDiscoveredList, Vector3Int heroPos) {

        //BoundsInt bounds = groundTilemap.cellBounds;

        for (int x = heroPos.x - 4; x < heroPos.x + 4; x++)
        {
            for (int y = heroPos.y - 4; y < heroPos.y + 4; y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);
                foreach (var tile in posDiscoveredList) {
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
}