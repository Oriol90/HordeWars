using System.Collections.Generic;
using UnityEngine;

public class InitSpawner : Spawner
{
    void Start()
    {

        List<UnitData> listUnitData = GameSaveManager.Load<List<UnitData>>(DataType.ArmyData);
        Dictionary<UnitType, BaseStats> dictBaseStats = GameSaveManager.Load<Dictionary<UnitType, BaseStats>>(DataType.BaseStats);

        foreach (var unit in listUnitData)
        {
            Spawn(unit, dictBaseStats);
        }
    }
}
