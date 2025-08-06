using UnityEngine;
using UnityEngine.Tilemaps;

public class AlgoritmoDiamondSquare : MonoBehaviour
{
    float[,] map;
    public int sizeXY = 257; // Debe ser (2^n) + 1
    public Tilemap tilemap;
    public Tile[] tiles;
    public float[] levels;

    void Start()
    {
        GenerateMap();
        SmoothMap();
        ApplyTiles();
    }

    void GenerateMap()
    {
        map = new float[sizeXY, sizeXY];
        int size = sizeXY - 1;
        map[0, 0] = Random.Range(0f, 1f);
        map[0, size] = Random.Range(0f, 1f);
        map[size, 0] = Random.Range(0f, 1f);
        map[size, size] = Random.Range(0f, 1f);

        float roughness = 0.5f;
        for (int length = size; length > 1; length /= 2, roughness /= 2.0f)
        {
            int half = length / 2;
            for (int x = 0; x < size; x += length)
            {
                for (int y = 0; y < size; y += length)
                {
                    float avg = (map[x, y] + map[x + length, y] + map[x, y + length] + map[x + length, y + length]) / 4.0f;
                    map[x + half, y + half] = avg + Random.Range(-roughness, roughness);
                }
            }

            for (int x = 0; x < size; x += half)
            {
                for (int y = (x + half) % length; y < size; y += length)
                {
                    float avg = (map[(x - half + size) % size, y] +
                                 map[(x + half) % size, y] +
                                 map[x, (y + half) % size] +
                                 map[x, (y - half + size) % size]) / 4.0f;
                    map[x, y] = avg + Random.Range(-roughness, roughness);
                }
            }
        }
    }

    void SmoothMap()
    {
        float[,] smoothedMap = new float[sizeXY, sizeXY];
        for (int x = 1; x < sizeXY - 1; x++)
        {
            for (int y = 1; y < sizeXY - 1; y++)
            {
                float sum = 0f;
                sum += map[x - 1, y - 1];
                sum += map[x, y - 1];
                sum += map[x + 1, y - 1];
                sum += map[x - 1, y];
                sum += map[x, y];
                sum += map[x + 1, y];
                sum += map[x - 1, y + 1];
                sum += map[x, y + 1];
                sum += map[x + 1, y + 1];
                smoothedMap[x, y] = sum / 9f;
            }
        }
        map = smoothedMap;
    }

    void ApplyTiles()
    {
        for (int x = 0; x < sizeXY; x++)
        {
            for (int y = 0; y < sizeXY; y++)
            {
                float height = map[x, y];
                TileBase tile = GetTileForHeight(height);
                tilemap.SetTile(new Vector3Int(x, y, 0), tile);
            }
        }
    }

    TileBase GetTileForHeight(float height)
    {
        for (int i = 0; i < levels.Length; i++)
        {
            if (height < levels[i])
            {
                return tiles[i];
            }
        }
        return tiles[tiles.Length - 1];
    }
}