using UnityEngine;
using System.Collections.Generic;
using System; // Necesario para usar listas

public class Spawner : MonoBehaviour
{
    private HashSet<Vector2> usedPositions = new HashSet<Vector2>(); // Para rastrear las posiciones ya ocupadas
    private Rect spawnArea;

    public void Spawn(GameObject prefabUnit, int cantidad, string unit)
    { 
        InitSpawnArea(unit);
        for(int i = 0; i < cantidad; i++) {
             SpawnUnit(prefabUnit);
         }
    }

    private void SpawnUnit(GameObject prefabUnit)
    {
        // Buscar una posición aleatoria disponible
        Vector2 randomPosition = GetRandomAvailablePosition();

        if (randomPosition != Vector2.zero) // Si hay una posición válida
        {
            // Instanciar la unidad en la posición calculada
            Instantiate(prefabUnit, randomPosition, Quaternion.identity);

            // Marcar la posición como ocupada
            usedPositions.Add(randomPosition);
        }
        else
        {
            Debug.LogWarning("No hay más posiciones disponibles en la zona de spawn.");
        }
    }

    private Vector2 GetRandomAvailablePosition()
    {
        // Intentar encontrar una posición libre en un máximo de 100 intentos (evita loops infinitos)
        for (int i = 0; i < 100; i++)
        {
            Vector2 randomPosition = new Vector2(
                UnityEngine.Random.Range(spawnArea.xMin, spawnArea.xMax),
                UnityEngine.Random.Range(spawnArea.yMin, spawnArea.yMax)
            );

            // Verificar si la posición no está ocupada
            if (!usedPositions.Contains(randomPosition))
            {
                return randomPosition;
            }
        }

        return Vector2.zero; // Si no se encuentra ninguna posición, devolver Vector2.zero
    }

    void InitSpawnArea(string unit)
    {
        switch(unit)
        {
            case GC.UNIT_GIRL_KNIGHT:
                spawnArea = new Rect(GC.GIRL_KNIGHT_INITIAL_ZONE_X, GC.MAP_BOT, GC.GIRL_KNIGHT_INITIAL_WIDTH, GC.MAP_HEIGHT);
                break;

            case GC.UNIT_LEAF_ARCHER:
                spawnArea = new Rect(GC.LEAF_ARCHER_INITIAL_ZONE_X, GC.MAP_BOT, GC.LEAF_ARCHER_INITIAL_WIDTH, GC.MAP_HEIGHT);
                break;
        }
    }
}
