using UnityEngine;
using UnityEngine.Tilemaps;

public class CellPainter : MonoBehaviour
{
    public Tilemap tilemap; // Asigna el Tilemap en el Inspector

    public void PaintCell(Vector3Int gridPosition, Color visitedColor)
    {
        if (tilemap == null)
        {
            Debug.LogError("Tilemap no asignado. Asegúrate de asignarlo en el Inspector.");
            return;
        }

        if (tilemap.HasTile(gridPosition))
        {
            tilemap.SetColor(gridPosition, visitedColor);
        }
        else
        {
            Debug.LogWarning($"No se encontró ningún Tile en la posición {gridPosition}.");
        }
    }
}
