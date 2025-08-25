using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSelector : MonoBehaviour
{
    public Tilemap tilemap; // arrástralo desde el inspector
    public Camera mainCamera;
    public GameObject selectorPrefab;
    public LineRenderer lineRenderer;
    private GameObject selectorInstance;
    private bool unitSelected = false;
    private Vector3Int unitPos = new Vector3Int();

    void Start()
    {
        selectorInstance = Instantiate(selectorPrefab);
        selectorInstance.SetActive(false); // No visible hasta hacer clic
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Click izquierdo
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f; // MUY IMPORTANTE para evitar errores con z
            Vector3Int cellPos = tilemap.WorldToCell(mouseWorldPos);

            TileBase clickedTile = tilemap.GetTile(cellPos);

            if (clickedTile != null)
            {

                if (UnitInside(cellPos))
                {
                    unitPos = cellPos;
                    unitSelected = true;
                }
                else
                {
                    unitPos = cellPos;
                    unitSelected = true;
                }

                Debug.Log($"Has hecho click en la celda: {cellPos}, tile: {Utils.GetTileName(clickedTile.name)}");

                // Ejemplo: cambiar el color de ese tile
                Vector3 center = tilemap.GetCellCenterWorld(cellPos);
                selectorInstance.transform.position = center;
                selectorInstance.SetActive(true);
                tilemap.SetColor(cellPos, Color.red);
                /* Sustitur el tile
                    public TileBase highlightTile; // Asignado desde el Inspector
                    tilemap.SetTile(cellPos, highlightTile);
                */
            }
        }

        if (Input.GetMouseButtonDown(1) && unitSelected) // Clic derecho
        {

            Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPos = tilemap.WorldToCell(mouseWorldPos);
            cellPos.z = 0;
            MoveUnitManager.MoveUnit(unitPos, cellPos, tilemap, lineRenderer);

            if (!tilemap.HasTile(cellPos)) return;

            
        }
    }

    bool UnitInside(Vector3Int cell)
    {
        Vector3 worldPos = tilemap.GetCellCenterWorld(cell);
        Collider2D[] hits = Physics2D.OverlapCircleAll(worldPos, 0.1f);

        foreach (var hit in hits)
        {
            if (hit.CompareTag("Unidad")) // Asegúrate de asignar esta tag a tus unidades
                return true;
        }

        return false;
    }
}
