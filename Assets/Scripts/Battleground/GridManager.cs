using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    public Tile tilePrefab; // Prefab para representar cada celda (opcional)
    public Tilemap tileMap;

    //private Tile[,] grid; // Matriz para rastrear los objetos en la cuadrícula


    void Start()
    {
        GenerateGrid();
        //InitializeMap();       
    }

    // Generar la cuadrícula
    void GenerateGrid()
    {
        for (int x = 0; x < GC.MapWidth; x++)
        {
            for (int y = 0; y <  GC.MapHeight; y++)
            {
                Vector3Int gridPosition = new Vector3Int(x, y, 0);

                // Crear un tile en la posición del mundo
                if (tilePrefab != null)
                {
                    tileMap.SetTile(gridPosition, tilePrefab);
                    GC.MapPositions[x, y] = new CellTracker(false, "", null);
                }
            }
        }
    }
}
