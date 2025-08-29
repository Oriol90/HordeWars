using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileSelector : MonoBehaviour
{
    public Tilemap tilemap; 
    public Camera mainCamera;
    public GameObject bordeArcoiris;
    public LineRenderer lineRenderer;
    private GameObject selectorInstance;
    public GameObject hero;

    void Start()
    {
        selectorInstance = Instantiate(bordeArcoiris);
        selectorInstance.SetActive(false); 
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f; // MUY IMPORTANTE para evitar errores con z
            Vector3Int cellPos = tilemap.WorldToCell(mouseWorldPos);

            TileBase clickedTile = tilemap.GetTile(cellPos);

            if (clickedTile != null)
            {
                Debug.Log($"Has hecho click en la celda: {cellPos}");

                Vector3 center = tilemap.GetCellCenterWorld(cellPos);
                selectorInstance.transform.position = center;
                selectorInstance.SetActive(true);
            }
        }

        if (Input.GetMouseButtonDown(1)) // Clic derecho
        {

            Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPos = tilemap.WorldToCell(mouseWorldPos);
            cellPos.z = 0;
            MoveUnitManager.MoveUnit(cellPos, tilemap, lineRenderer);

            if (!tilemap.HasTile(cellPos)) return;

            
        }
    }
}
