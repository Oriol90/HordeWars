using UnityEngine;
using System.Collections.Generic;
using System; // Necesario para usar listas

public class Spawner : MonoBehaviour
{
   
    private HashSet<Vector2Int> usedPositions = new HashSet<Vector2Int>(); // Para rastrear las posiciones ya ocupadas
    private Vector2Int gridSize;
    private int zoneX;

    public void Spawn(GameObject prefabUnit, int cantidad, string unit)
    { 
        InitPositions(unit);
        for(int i = 0; i < cantidad; i++) {
             SpawnUnit(prefabUnit, gridSize, zoneX);
         }
    }

    private void  SpawnUnit(GameObject prefabUnit, Vector2Int gridSize, int zoneX){

        // Buscar una posición aleatoria disponible
        Vector2Int randomGridPosition = GetRandomAvailablePosition(gridSize, zoneX);

        if (randomGridPosition != Vector2Int.zero) // Si hay una posición válida
        {
            // Convertir la posición de la cuadrícula a coordenadas del mundo
            Vector3 spawnPosition = GridToWorld(randomGridPosition);

            // Instanciar el orco en la posición calculada
            Instantiate(prefabUnit, spawnPosition, Quaternion.identity);

            // Marcar la posición como ocupada
            usedPositions.Add(randomGridPosition);
        }
        else
        {
            Debug.LogWarning("No hay más posiciones disponibles en la cuadrícula.");
        }

    }

    private Vector2Int GetRandomAvailablePosition(Vector2Int gridSize, int zoneX)
    {
        
        // Intentar encontrar una posición libre en un máximo de 100 intentos (evita loops infinitos)
        for (int i = 0; i < 100; i++)
        {
            Vector2Int randomPosition = new Vector2Int(
                UnityEngine.Random.Range(zoneX, gridSize.x+zoneX),
                UnityEngine.Random.Range(5, gridSize.y)
            );

            // Verificar si la posición no está ocupada
            if (!usedPositions.Contains(randomPosition))
            {
                return randomPosition;
            }
        }

        return Vector2Int.zero; // Si no se encuentra ninguna posición, devolver Vector2Int.zero
    }

    void InitPositions(String unit){

        switch(unit){

            case GC.UNIT_GIRL_KNIGHT:
                gridSize = new Vector2Int(GC.GIRL_KNIGHT_INITIAL_RANGE_X, GC.GIRL_KNIGHT_INITIAL_RANGE_Y);
                zoneX = GC.GIRL_KNIGHT_INITIAL_ZONE;
                break;

            case GC.UNIT_LEAF_ARCHER:
                gridSize = new Vector2Int(GC.LEAF_ARCHER_INITIAL_RANGE_X, GC.LEAF_ARCHER_INITIAL_RANGE_Y);
                zoneX = GC.LEAF_ARCHER_INITIAL_ZONE;
                break;
        }
    }

    private Vector3 GridToWorld(Vector2Int gridPos)
    {
        // Convertir coordenadas de la cuadrícula a posiciones del mundo
        float worldX = (gridPos.x + 0.5f) * GC.CELL_SIZE;
        float worldY = (gridPos.y + 0.5f) * GC.CELL_SIZE;
        return new Vector3(worldX, worldY, 0);
    }
}
