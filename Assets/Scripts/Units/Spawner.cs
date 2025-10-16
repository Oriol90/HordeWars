using UnityEngine;
using System.Collections.Generic;
using System; // Necesario para usar listas

public class Spawner : MonoBehaviour
{
    public GameObject LeafArcherPrefab;
    public GameObject ArcherPrefab;
    public GameObject GirlKnightPrefab;
    private HashSet<Vector2> usedPositions = new HashSet<Vector2>(); // Para rastrear las posiciones ya ocupadas
    private Rect spawnArea;

    public void Spawn(UnitData unitData, Dictionary<UnitType, BaseStats> dictBaseStats)
    {
        InitSpawnArea(unitData.unitType);
        SpawnUnit(AsignPrefab(unitData.unitType), unitData, dictBaseStats);
    }

    private void SpawnUnit(GameObject prefabUnit, UnitData unitData, Dictionary<UnitType, BaseStats> dictBaseStats)
    {
        // Buscar una posición aleatoria disponible
        Vector2 randomPosition = GetRandomAvailablePosition();

        if (randomPosition != Vector2.zero) // Si hay una posición válida
        {
            // Instanciar la unidad en la posición calculada
            GameObject unit = Instantiate(prefabUnit, randomPosition, Quaternion.identity);

            unit = UnitFactory.SetUnitGO(unit, unitData, dictBaseStats);

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

    void InitSpawnArea(UnitType unitType)
    {
        switch (unitType)
        {
            case UnitType.GirlKnight:
                spawnArea = new Rect(GC.GIRL_KNIGHT_INITIAL_ZONE_X, GC.MAP_BOT, GC.GIRL_KNIGHT_INITIAL_WIDTH, GC.MAP_HEIGHT);
                break;

            case UnitType.LeafArcher:
                spawnArea = new Rect(GC.LEAF_ARCHER_INITIAL_ZONE_X, GC.MAP_BOT, GC.LEAF_ARCHER_INITIAL_WIDTH, GC.MAP_HEIGHT);
                break;

            case UnitType.Archer:
                spawnArea = new Rect(GC.LEAF_ARCHER_INITIAL_ZONE_X, GC.MAP_BOT, GC.LEAF_ARCHER_INITIAL_WIDTH, GC.MAP_HEIGHT);
                break;
        }
    }
    
    public GameObject AsignPrefab(UnitType unitType)
    {
        GameObject prefab = null;
        switch (unitType)
        {
            case UnitType.Archer:
                prefab = ArcherPrefab;
                break;
            case UnitType.GirlKnight:
                prefab = GirlKnightPrefab;
                break;
            case UnitType.LeafArcher:
                prefab = LeafArcherPrefab;
                break;
        }
        return prefab;
    }
}
