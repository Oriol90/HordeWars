using System.Collections.Generic;
using UnityEngine;

public class HexMapManager : MonoBehaviour {
    public GameObject hexPrefab;
    public int width = 10;
    public int height = 10;
    public float hexWidth = 1f;
    public float hexHeight = 0.866f; // Aproximadamente altura de un hex regular

    private Dictionary<Vector2Int, GameObject> hexTiles = new();

    void Start() {
        GenerateHexMap();
    }

    void GenerateHexMap() {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                float xOffset = (y % 2 == 0) ? 0 : hexWidth / 2f;
                Vector3 pos = new Vector3(x * hexWidth + xOffset, y * (hexHeight * 0.75f), 0);
                GameObject tile = Instantiate(hexPrefab, pos, Quaternion.identity, transform);
                tile.name = $"Hex_{x}_{y}";

                var data = new HexTileData {
                    coordinates = new Vector2Int(x, y),
                    biome = "Plains", // luego lo defines aleatoriamente
                    feature = "None",
                    isDiscovered = false
                };

                // puedes guardar los datos si luego necesitas reconstruirlo
                hexTiles[new Vector2Int(x, y)] = tile;
            }
        }
    }
}
